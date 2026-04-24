using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TLVanced
{
    public sealed class InputMouseOptionRow : INotifyPropertyChanged
    {
        private bool on;
        private readonly Action? onPersist;

        public InputMouseOptionRow(InputMouseOptionDefinition def, bool isOn, Action? onPersist = null)
        {
            Definition = def;
            on = isOn;
            this.onPersist = onPersist;
        }

        public InputMouseOptionDefinition Definition { get; }

        public string Title => Definition.Title;

        public string IniKey => Definition.IniKey;

        public bool IsOn
        {
            get => on;
            set
            {
                if (on == value)
                    return;
                on = value;
                NotifyPropertyChanged();
                onPersist?.Invoke();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
