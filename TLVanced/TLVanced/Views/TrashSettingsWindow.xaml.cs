using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace TLVanced
{
    public partial class TrashSettingsWindow : Window
    {
        private readonly ObservableCollection<GameValueTrashOptionRow> rows = new();
        private bool suppressPersist;

        public TrashSettingsWindow()
        {
            InitializeComponent();
            optionsList.ItemsSource = rows;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pathHint.Text = Utils.GameValueIniPath;
            ReloadFromDisk();
        }

        private void ReloadFromDisk()
        {
            suppressPersist = true;
            try
            {
                rows.Clear();
                var map = GameValueIniStore.ReadKeyValues(Utils.GameValueIniPath);
                foreach (var def in GameValueTrashOptionDefinition.All)
                {
                    map.TryGetValue(def.IniKey, out var raw);
                    var on = GameValueIniStore.ParseBool(raw, def.DefaultWhenMissing);
                    rows.Add(new GameValueTrashOptionRow(def, on, PersistAll));
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
                var updates = rows.ToDictionary(r => r.IniKey, r => GameValueIniStore.FormatBool(r.IsOn));
                GameValueIniStore.WriteKeyValues(Utils.GameValueIniPath, updates);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "GameValue.ini", MessageBoxButton.OK, MessageBoxImage.Error);
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
