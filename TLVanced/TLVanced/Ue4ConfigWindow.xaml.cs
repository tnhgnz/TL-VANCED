using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TLVanced
{
    public partial class Ue4ConfigWindow : Window
    {
        public ObservableCollection<RendererSettingRow> Rows { get; } = new();

        public Ue4ConfigWindow()
        {
            InitializeComponent();
            SettingsGrid.ItemsSource = Rows;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PathText.Text = Utils.EngineIniPath;
            ReloadFromDisk();
        }

        private void ReloadButton_Click(object sender, RoutedEventArgs e) => ReloadFromDisk();

        private void ReloadFromDisk()
        {
            Rows.Clear();
            var map = EngineIniRendererSettingsStore.ReadRendererSection(Utils.EngineIniPath, out var sectionExists);

            foreach (var def in EngineRendererSettingDefinition.All)
            {
                map.TryGetValue(def.Key, out var val);
                Rows.Add(new RendererSettingRow(def, val));
            }

            SectionHint.Visibility = sectionExists ? Visibility.Collapsed : Visibility.Visible;
            SectionHint.Text =
                "Секция [/Script/Engine.RendererSettings] в файле не найдена: для строк без значения в конфиге показан символ *.";

            FileMissingHint.Visibility = File.Exists(Utils.EngineIniPath)
                ? Visibility.Collapsed
                : Visibility.Visible;
            FileMissingHint.Text =
                "Файл Engine.ini ещё не создан. После «Сохранить» будет создан каталог и секция с выбранными параметрами.";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dict = Rows.ToDictionary(r => r.Key, r => r.EditingValue, StringComparer.OrdinalIgnoreCase);
                EngineIniRendererSettingsStore.SaveRendererSection(Utils.EngineIniPath, dict);
                ReloadFromDisk();
                MessageBox.Show("Сохранено.", "UE4 Конфиг", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e) => Close();

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
