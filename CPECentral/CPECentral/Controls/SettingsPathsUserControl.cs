#region Using directives

using System;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary;

#endregion

namespace CPECentral.Controls
{
    public partial class SettingsPathsUserControl : UserControl
    {
        /// <summary>
        ///     The text to display when a setting has not value defined
        /// </summary>
        private const string NoValueText = "NOT SET!";

        public SettingsPathsUserControl()
        {
            InitializeComponent();
        }

        private void PathSettingsUserControl_Load(object sender, EventArgs e)
        {
            string sharedAppDir = Settings.Default.SharedAppDir;
            string drawingFileDir = Settings.Default.DrawingFileDirectory;
            string millingCamTemplatePath = Settings.Default.CamTemplateMilling;
            string turningCamTemplatePath = Settings.Default.CamTemplateTurning;

            sharedAppDirDirectoryTextBox.Text = sharedAppDir.IsNullOrWhitespace() ? NoValueText : sharedAppDir;
            drawingFileDirectoryTextBox.Text = drawingFileDir.IsNullOrWhitespace() ? NoValueText : drawingFileDir;

            millingCamTemplateTextBox.Text = millingCamTemplatePath.IsNullOrWhitespace()
                ? NoValueText
                : millingCamTemplatePath;

            turningCamTemplateTextBox.Text = turningCamTemplatePath.IsNullOrWhitespace()
                ? NoValueText
                : turningCamTemplatePath;
        }

        private void templatesButton_Clicked(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog()) {
                fileDialog.Filter = "All files|*.*";
                fileDialog.Multiselect = false;
                fileDialog.Title = "Select a CAM template";

                if (fileDialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                string clickedButtonName = (sender as Button).Name;

                switch (clickedButtonName) {
                    case "selectMillingTemplateButton":
                        millingCamTemplateTextBox.Text = fileDialog.FileName;
                        Settings.Default.CamTemplateMilling = fileDialog.FileName;
                        break;
                    case "selectTurningTemplateButton":
                        turningCamTemplateTextBox.Text = fileDialog.FileName;
                        Settings.Default.CamTemplateTurning = fileDialog.FileName;
                        break;
                }

                using (BusyCursor.Show()) {
                    Settings.Default.Save();
                }
            }
        }

        private void dataDirectoriesButton_Clicked(object sender, EventArgs e)
        {
            string clickedButtonName = (sender as Button).Name;

            string description = null;
            switch (clickedButtonName) {
                case "selectSharedAppDirButton":
                    description = "Select the folder where all application files are stored";
                    break;
                case "selectDrawingDirButton":
                    description = "Select the folder where drawings and models are stored";
                    break;
            }

            using (var folderDialog = new FolderBrowserDialog()) {
                folderDialog.Description = description;
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                }

                switch (clickedButtonName) {
                    case "selectSharedAppDirButton":
                        sharedAppDirDirectoryTextBox.Text = folderDialog.SelectedPath;
                        Settings.Default.SharedAppDir = folderDialog.SelectedPath;
                        break;
                    case "selectDrawingDirButton":
                        drawingFileDirectoryTextBox.Text = folderDialog.SelectedPath;
                        Settings.Default.DrawingFileDirectory = folderDialog.SelectedPath;
                        break;
                }
            }

            using (BusyCursor.Show()) {
                Settings.Default.Save();
            }
        }
    }
}