using System.IO;

namespace TLVanced
{
    public static class GameValueIniStore
    {
        public static Dictionary<string, string> ReadKeyValues(string path)
        {
            var map = new Dictionary<string, string>(StringComparer.Ordinal);
            if (!File.Exists(path))
                return map;

            foreach (var raw in File.ReadAllLines(path))
            {
                var line = raw.Trim();
                if (line.Length == 0 || line[0] == ';' || line[0] == '#')
                    continue;

                var eq = line.IndexOf('=');
                if (eq <= 0)
                    continue;

                var key = line[..eq].Trim();
                var val = line[(eq + 1)..].Trim();
                map[key] = val;
            }

            return map;
        }

        public static void WriteKeyValues(string path, IReadOnlyDictionary<string, string> updates)
        {
            var lines = File.Exists(path)
                ? File.ReadAllLines(path).ToList()
                : new List<string>();

            bool LineKey(string line, out string? key)
            {
                key = null;
                var t = line.Trim();
                if (t.Length == 0 || t[0] == ';' || t[0] == '#')
                    return false;
                var eq = t.IndexOf('=');
                if (eq <= 0)
                    return false;
                key = t[..eq].Trim();
                return true;
            }

            foreach (var kv in updates)
            {
                var found = -1;
                for (var i = 0; i < lines.Count; i++)
                {
                    if (!LineKey(lines[i], out var k) || k == null)
                        continue;
                    if (!string.Equals(k, kv.Key, StringComparison.Ordinal))
                        continue;
                    found = i;
                    break;
                }

                var newLine = $"{kv.Key}={kv.Value}";
                if (found >= 0)
                    lines[found] = newLine;
                else
                    lines.Add(newLine);
            }

            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllLines(path, lines);
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

        public static string FormatBool(bool v) => v ? "true" : "false";
    }
}
