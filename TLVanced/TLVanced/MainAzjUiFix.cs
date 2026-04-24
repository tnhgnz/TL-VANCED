using Newtonsoft.Json;
using System.IO;

namespace TLVanced
{
    public static class MainAzjUiFix
    {
        private const string HiddenAlign = "LeftTop";
        private const double Offscreen = -1000d;

        public static bool TryReadDocument(string path, out AzulejoLayoutDocument? document, out string? error)
        {
            document = null;
            error = null;
            try
            {
                var json = File.ReadAllText(path);
                document = JsonConvert.DeserializeObject<AzulejoLayoutDocument>(json);
                if (document == null)
                {
                    error = "Не удалось разобрать JSON.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static bool AreBadDialogsHidden(AzulejoLayoutDocument document)
        {
            foreach (var key in Utils.BadComponents.Keys)
            {
                var t = FindTransform(document, key);
                if (t == null || !IsHiddenOffscreen(t))
                    return false;
            }

            return true;
        }

        public static void ApplyHideBadDialogs(AzulejoLayoutDocument document)
        {
            document.Payload ??= new AzulejoPayload();
            document.Payload.Transforms ??= new List<ComponentTransform>();

            foreach (var key in Utils.BadComponents.Keys)
            {
                var t = GetOrCreateTransform(document.Payload.Transforms, key);
                t.Align = HiddenAlign;
                t.Translate ??= new Vector3D();
                t.Translate.X = Offscreen;
                t.Translate.Y = Offscreen;
                t.Scale ??= new Vector3D();
                t.Scale.X = 0;
                t.Scale.Y = 0;
                t.Scale.Z = 0;
            }
        }

        public static void SaveDocument(string path, AzulejoLayoutDocument document)
        {
            var json = JsonConvert.SerializeObject(document, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private static ComponentTransform? FindTransform(AzulejoLayoutDocument document, int componentKey)
        {
            var list = document.Payload?.Transforms;
            if (list == null)
                return null;
            return list.FirstOrDefault(t => t.ComponentKey == componentKey);
        }

        private static bool IsHiddenOffscreen(ComponentTransform t)
        {
            if (!string.Equals(t.Align, HiddenAlign, StringComparison.Ordinal))
                return false;

            if (t.Scale == null || t.Scale.X != 0 || t.Scale.Y != 0 || t.Scale.Z != 0)
                return false;

            if (t.Translate == null || t.Translate.X != Offscreen || t.Translate.Y != Offscreen)
                return false;

            return true;
        }

        private static ComponentTransform GetOrCreateTransform(List<ComponentTransform> list, int componentKey)
        {
            var existing = list.FirstOrDefault(t => t.ComponentKey == componentKey);
            if (existing != null)
                return existing;

            var created = new ComponentTransform
            {
                ComponentKey = componentKey,
                Align = HiddenAlign,
                DesiredSize = new IntSize2D { Width = 100, Height = 100 },
                Translate = new Vector3D { X = Offscreen, Y = Offscreen },
                Scale = new Vector3D(),
                ZOrder = 0
            };
            list.Add(created);
            return created;
        }
    }
}
