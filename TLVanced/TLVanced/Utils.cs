using System.IO;

namespace TLVanced
{
    public class Utils
    {
        public static readonly string ConfigPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TL\UserHUD\Main.azj";

        public static readonly string EngineIniPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "TL", "Saved", "Config", "WindowsNoEditor", "Engine.ini");

        public static Dictionary<int, string> BadComponents = new()
        {
            { 145, "Диалоговое окно с NPC" },
            { 128, "Диалоговое окно с Амитоем" },
        };
    }
}
