using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace TLVanced
{
    public sealed class RendererSettingRow : INotifyPropertyChanged
    {
        public RendererSettingRow(EngineRendererSettingDefinition def, string? fromFile)
        {
            Def = def;
            HasValueInFile = !string.IsNullOrWhiteSpace(fromFile);
            _editingValue = HasValueInFile ? fromFile!.Trim() : "*";
        }

        public EngineRendererSettingDefinition Def { get; }

        public bool HasValueInFile { get; }

        public string Key => Def.Key;

        public string AllowedValues => Def.AllowedValues;

        public string Description => Def.Description;

        private string _editingValue;

        public string EditingValue
        {
            get => _editingValue;
            set
            {
                var v = value ?? string.Empty;
                if (_editingValue == v)
                    return;
                _editingValue = v;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
