using System.Windows.Input;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows;
using System.IO;

namespace TLVanced
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) => RefreshUiFixButtonState();

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Close(object sender, RoutedEventArgs e) => Environment.Exit(0);

        private void OpenTwitch(object sender, MouseButtonEventArgs e) =>
            Process.Start(new ProcessStartInfo("https://www.twitch.tv/tnhgnz") { UseShellExecute = true });
        private void OpenTelegram(object sender, MouseButtonEventArgs e) =>
            Process.Start(new ProcessStartInfo("https://t.me/tnhgnz") { UseShellExecute = true });
        private void OpenYT(object sender, MouseButtonEventArgs e) =>
            Process.Start(new ProcessStartInfo("https://www.youtube.com/@Tnhgnz") { UseShellExecute = true });

        private void OpenUe4ConfigClick(object sender, RoutedEventArgs e)
        {
            var w = new Ue4ConfigWindow { Owner = this };
            w.Show();
        }

        private void OpenTrashSettingsClick(object sender, RoutedEventArgs e)
        {
            var w = new TrashSettingsWindow { Owner = this };
            w.Show();
        }

        private void OpenInputSettingsClick(object sender, RoutedEventArgs e)
        {
            var w = new InputSettingsWindow { Owner = this };
            w.Show();
        }

        private void RefreshUiFixButtonState()
        {
            UiFixButton.ClearValue(BackgroundProperty);
            UiFixButtonText.ClearValue(ForegroundProperty);

            if (!File.Exists(Utils.ConfigPath))
            {
                UiFixButton.Background = Brushes.Red;
                return;
            }

            if (!MainAzjUiFix.TryReadDocument(Utils.ConfigPath, out var doc, out _) || doc == null)
                return;

            if (MainAzjUiFix.AreBadDialogsHidden(doc))
                UiFixButtonText.Foreground = Brushes.LimeGreen;
        }

        private void UiFixButtonClick(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(Utils.ConfigPath))
            {
                MessageBox.Show(
                    $"Файл не найден:\n{Utils.ConfigPath}",
                    "UI Фикс",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                RefreshUiFixButtonState();
                return;
            }

            if (!MainAzjUiFix.TryReadDocument(Utils.ConfigPath, out var doc, out var err) || doc == null)
            {
                MessageBox.Show(err ?? "Ошибка чтения файла.", "UI Фикс", MessageBoxButton.OK, MessageBoxImage.Error);
                RefreshUiFixButtonState();
                return;
            }

            try
            {
                MainAzjUiFix.ApplyHideBadDialogs(doc);
                MainAzjUiFix.SaveDocument(Utils.ConfigPath, doc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UI Фикс", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RefreshUiFixButtonState();
        }
    }
}