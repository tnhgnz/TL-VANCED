using System.Text;
using System.IO;

namespace TLVanced
{
    public static class InputIniSettingsStore
    {
        private const string SectionMarker = "[/Script/Engine.InputSettings]";

        public static bool SectionHeaderEquals(string line)
        {
            var t = line.Trim();
            return t.StartsWith('[') && t.EndsWith(']') &&
                   t.Contains("Engine", StringComparison.OrdinalIgnoreCase) &&
                   t.Contains("InputSettings", StringComparison.OrdinalIgnoreCase);
        }

        public static Dictionary<string, string> ReadInputSection(string path, out bool sectionExists)
        {
            sectionExists = false;
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (!File.Exists(path))
                return map;

            var lines = File.ReadAllLines(path);
            for (var i = 0; i < lines.Length; i++)
            {
                if (!SectionHeaderEquals(lines[i]))
                    continue;

                sectionExists = true;
                for (var j = i + 1; j < lines.Length; j++)
                {
                    var trimmed = lines[j].Trim();
                    if (trimmed.Length > 0 && trimmed[0] == '[')
                        break;
                    if (string.IsNullOrWhiteSpace(trimmed) || trimmed[0] == ';' || trimmed[0] == '#')
                        continue;

                    var eq = trimmed.IndexOf('=');
                    if (eq <= 0)
                        continue;

                    var key = trimmed[..eq].Trim();
                    var val = trimmed[(eq + 1)..].Trim();
                    map[key] = val;
                }

                break;
            }

            return map;
        }

        public static bool ParseBool(string? raw, bool fallback)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return fallback;
            if (bool.TryParse(raw, out var b))
                return b;
            if (int.TryParse(raw, out var n))
                return n != 0;
            return fallback;
        }

        public static string FormatBool(bool v) => v ? "True" : "False";

        public static void SaveInputSection(string path, IReadOnlyDictionary<string, string> uiValues)
        {
            var merged = ReadInputSection(path, out _);

            foreach (var def in InputMouseOptionDefinition.All)
            {
                if (!uiValues.TryGetValue(def.IniKey, out var raw))
                    continue;
                var v = raw.Trim();
                if (v.Length == 0 || v == "*")
                    merged.Remove(def.IniKey);
                else
                    merged[def.IniKey] = v;
            }

            var lines = File.Exists(path)
                ? File.ReadAllLines(path).ToList()
                : new List<string>();

            var start = -1;
            var endExclusive = lines.Count;

            for (var i = 0; i < lines.Count; i++)
            {
                if (!SectionHeaderEquals(lines[i]))
                    continue;
                start = i;
                for (var j = i + 1; j < lines.Count; j++)
                {
                    var t = lines[j].Trim();
                    if (t.Length > 0 && t[0] == '[')
                    {
                        endExclusive = j;
                        break;
                    }
                }

                break;
            }

            if (start >= 0)
                lines.RemoveRange(start, endExclusive - start);

            var insertAt = start >= 0 ? start : lines.Count;
            var sb = new StringBuilder();
            sb.AppendLine(SectionMarker);

            foreach (var def in InputMouseOptionDefinition.All)
            {
                if (!merged.TryGetValue(def.IniKey, out var val))
                    continue;
                sb.AppendLine($"{def.IniKey}={val}");
            }

            foreach (var kv in merged.OrderBy(x => x.Key, StringComparer.OrdinalIgnoreCase))
            {
                if (InputMouseOptionDefinition.All.Any(d =>
                        string.Equals(d.IniKey, kv.Key, StringComparison.OrdinalIgnoreCase)))
                    continue;
                sb.AppendLine($"{kv.Key}={kv.Value}");
            }

            var blockLines = sb.ToString().TrimEnd('\r', '\n').Split(["\r\n", "\n"], StringSplitOptions.None);
            lines.InsertRange(insertAt, blockLines);

            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllLines(path, lines);
        }
    }
}
