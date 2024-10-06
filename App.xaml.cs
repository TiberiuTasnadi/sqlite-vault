using System.Windows;
using SQLiteVault.Views;

namespace SQLiteVault
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private NotifyIcon _notifyIcon;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = new Icon("icon.ico"),
                Visible = true,
                Text = "SQLite Vault"
            };

            var contextMenu = new ContextMenuStrip();

            var uploadMenuItem = new ToolStripMenuItem("Upload DB");
            uploadMenuItem.Click += UploadMenuItem_Click;
            contextMenu.Items.Add(uploadMenuItem);

            var downloadMenuItem = new ToolStripMenuItem("Download DB");
            downloadMenuItem.Click += DownloadMenuItem_Click;
            contextMenu.Items.Add(downloadMenuItem);

            var exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += ExitMenuItem_Click;
            contextMenu.Items.Add(exitMenuItem);

            var configMenuItem = new ToolStripMenuItem("Configuration");
            configMenuItem.Click += ConfigurationMenuItem_Click;
            contextMenu.Items.Add(configMenuItem);

            _notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void UploadMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Uploading DB...");
        }

        private void DownloadMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.MessageBox.Show("Downloading DB...");
        }

        private void ConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            var configWindow = new ConfigurationView();
            configWindow.Show();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            System.Windows.Application.Current.Shutdown();
        }

    }
}
