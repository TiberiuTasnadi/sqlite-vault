using SQLiteVault.Models;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace SQLiteVault.Views
{
    /// <summary>
    /// Lógica de interacción para ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : Window
    {
        private readonly Services.ConfigurationManager _configurationManager;

        public ConfigurationView()
        {
            InitializeComponent();
            _configurationManager = new Services.ConfigurationManager();
            this.Closing += ConfigurationWindow_Closing;

            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            var configurations = _configurationManager.LoadConfigurations();

            if (configurations.FileConfigurations.Count > 0)
            {
                FilesListBox.ItemsSource = configurations.FileConfigurations;
            }
            else
            {
                FilesListBox.ItemsSource = new List<FileConfiguration>();
            }
        }

        private void FilesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (FilesListBox.SelectedItem is FileConfiguration selectedConfig)
            {
                FilePathTextBox.Text = selectedConfig.SourcePath;
                DestinationPathTextBox.Text = selectedConfig.DestinationPath;
                ButtonAdd.Content = "Update";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = FilePathTextBox.Text;
            var destinationPath = DestinationPathTextBox.Text;

            if (!string.IsNullOrWhiteSpace(filePath) && !string.IsNullOrWhiteSpace(destinationPath))
            {
                if (FilesListBox.SelectedItem is FileConfiguration selectedConfig)
                {
                    selectedConfig.SourcePath = FilePathTextBox.Text;
                    selectedConfig.DestinationPath = DestinationPathTextBox.Text;
                }
                else
                {
                    var fileConfig = new FileConfiguration { SourcePath = filePath, DestinationPath = destinationPath };
                    FilesListBox.Items.Add(fileConfig);
                    FilePathTextBox.Clear();
                    DestinationPathTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please complete both fields.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilesListBox.SelectedItem is FileConfiguration selectedConfig)
            {
                FilesListBox.Items.Remove(selectedConfig);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Configurations configurations = new Configurations { FileConfigurations = (List<FileConfiguration>)FilesListBox.ItemsSource};
            _configurationManager.SaveConfigurations(configurations);
            MessageBox.Show("Configuration saved.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // We should close the window instead of hiding it.
            this.Hide();
        }

        private void ConfigurationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            // We should close the window instead of hiding it.
            this.Hide();
        }
    }
}
