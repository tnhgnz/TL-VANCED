using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TLVanced
{
    public partial class InputSettingsWindow : Window
    {
        private readonly ObservableCollection<InputMouseOptionRow> rows = new();
        private bool suppressPersist;

        public InputSettingsWindow()
        {
            InitializeComponent();
            optionsList.ItemsSource = rows;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pathHint.Text = Utils.InputIniPath;
            ReloadFromDisk();
        }

        private void ReloadFromDisk()
        {
            suppressPersist = true;
            try
            {
                rows.Clear();
                var map = InputIniSettingsStore.ReadInputSection(Utils.InputIniPath, out _);
                foreach (var def in InputMouseOptionDefinition.All)
                {
                    map.TryGetValue(def.IniKey, out var raw);
                    var parsed = InputIniSettingsStore.ParseBool(raw, def.DefaultWhenMissing);
                    rows.Add(new InputMouseOptionRow(def, parsed, PersistAll));
                }
            }
            finally
            {
                suppressPersist = false;
            }
        }

        private void PersistAll()
        {
            if (suppressPersist)
                return;
            try
            {
                var updates = rows.ToDictionary(r => r.IniKey, r => InputIniSettingsStore.FormatBool(r.IsOn));
                InputIniSettingsStore.SaveInputSection(Utils.InputIniPath, updates);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input.ini", MessageBoxButton.OK, MessageBoxImage.Error);
                ReloadFromDisk();
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e) => Close();

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
