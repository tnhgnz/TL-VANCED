namespace TLVanced
{
    public sealed class InputMouseOptionDefinition
    {
        public required string IniKey { get; init; }
        public required string Title { get; init; }
        public required bool DefaultWhenMissing { get; init; }

        public static IReadOnlyList<InputMouseOptionDefinition> All { get; } =
        [
            new()
            {
                IniKey = "bEnableMouseSmoothing",
                Title = "Сглаживание мыши (инерция, не 1:1)",
                DefaultWhenMissing = false
            },
            new()
            {
                IniKey = "bEnableFOVScaling",
                Title = "Чувствительность от FOV (плавает с зумом)",
                DefaultWhenMissing = false
            },
            new()
            {
                IniKey = "bUseMouseForTouch",
                Title = "Эмуляция тача мышью",
                DefaultWhenMissing = false
            },
        ];
    }
}
