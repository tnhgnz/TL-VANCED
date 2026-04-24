using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace TLVanced
{
    public sealed class GameValueTrashOptionRow : INotifyPropertyChanged
    {
        private bool on;
        private readonly Action? onPersist;

        public GameValueTrashOptionRow(GameValueTrashOptionDefinition def, bool isOn, Action? onPersist = null)
        {
            Definition = def;
            on = isOn;
            this.onPersist = onPersist;
        }

        public GameValueTrashOptionDefinition Definition { get; }

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
