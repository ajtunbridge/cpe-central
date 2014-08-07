using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Properties;

namespace CPECentral.Controls
{
    public partial class SettingsGeneralUserControl : UserControl
    {
        public SettingsGeneralUserControl()
        {
            InitializeComponent();

            base.Font = Settings.Default.AppFont;
        }

        private void SettingsGeneralUserControl_Load(object sender, EventArgs e)
        {
            programHeaderFormatRichTextBox.Text = Settings.Default.TurningProgramHeaderFormat;
            toolFormatRichTextBox.Text = Settings.Default.TurningProgramToolFormat;
            holderFormatRichTextBox.Text = Settings.Default.TurningProgramHolderFormat;
        }

        private void programFormatRichTextBoxes_Leave(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        private void programHeaderFormatRichTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.TurningProgramHeaderFormat = programHeaderFormatRichTextBox.Text;
        }

        private void toolFormatRichTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.TurningProgramToolFormat = toolFormatRichTextBox.Text;
        }

        private void holderFormatRichTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.TurningProgramHolderFormat = holderFormatRichTextBox.Text;
        }
    }
}
