namespace TLVanced
{
    public sealed class GameValueTrashOptionDefinition
    {
        public required string IniKey { get; init; }
        public required string Title { get; init; }
        public required bool DefaultWhenMissing { get; init; }

        public static IReadOnlyList<GameValueTrashOptionDefinition> All { get; } =
        [
            new()
            {
                IniKey = "TLGame.TLOption.bStartGameGuideTextToSpeech#1",
                Title = "Экранный диктор при запуске игры",
                DefaultWhenMissing = false
            },
            new()
            {
                IniKey = "TLGame.TLOption.System3DAudioEnabled#1",
                Title = "Системный 3D-звук (Выкл = Экономия CPU)",
                DefaultWhenMissing = true
            },
            new()
            {
                IniKey = "TLGame.TLOption.UseGroomHair#1",
                Title = "Волосы Groom (объёмные) - СИЛЬНО САДИТ FPS!",
                DefaultWhenMissing = true
            },
        ];
    }
}
