#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary.Controls;

#endregion

namespace CPECentral.Controls
{
    public partial class FilesListView : EnhancedListView
    {
        private const string TextFileIcon = "TextFileIcon";

        private static ImageList _smallIconImageList;
        private static ImageList _largeIconImageList;

        public FilesListView()
        {
            InitializeComponent();

            if (_smallIconImageList == null) {
                _smallIconImageList = new ImageList();
                _smallIconImageList.ImageSize = new Size(16, 16);
                _smallIconImageList.ColorDepth = ColorDepth.Depth32Bit;
                _smallIconImageList.Images.Add(TextFileIcon, Resources.GenericFileIcon);
            }

            if (_largeIconImageList == null) {
                _largeIconImageList = new ImageList();
                _largeIconImageList.ImageSize = new Size(32, 32);
                _largeIconImageList.ColorDepth = ColorDepth.Depth32Bit;
                _largeIconImageList.Images.Add(TextFileIcon, Resources.GenericFileIcon);
            }

            SmallImageList = _smallIconImageList;
            LargeImageList = _largeIconImageList;
        }

        public void AddFile(string fileName, object tag)
        {
            var fileInfo = new FileInfo(fileName);

            bool hasExtension = fileName.LastIndexOf(".") > -1;

            string imageKey = null;

            if (hasExtension) {
                string[] textFileExtensions = Settings.Default.TextFileExtensions.Split(new[] {"|"},
                    StringSplitOptions.None);

                if (
                    textFileExtensions.Any(
                        textExt => textExt.Equals(fileInfo.Extension, StringComparison.OrdinalIgnoreCase))) {
                    imageKey = TextFileIcon;
                }
                else {
                    imageKey = fileInfo.Extension.ToLower();

                    if (!_smallIconImageList.Images.ContainsKey(imageKey)) {
                        Icon smallIcon = nGenLibrary.Win32.GetIconForFileExtension(imageKey, false, false);
                        Icon largeIcon = nGenLibrary.Win32.GetIconForFileExtension(imageKey, true, false);

                        _smallIconImageList.Images.Add(imageKey, smallIcon);
                        _largeIconImageList.Images.Add(imageKey, largeIcon);
                    }
                }
            }

            string friendlySize = GetFriendlyFileSize(fileInfo.Length);

            ListViewItem item = Items.Add(Path.GetFileNameWithoutExtension(fileInfo.FullName));
            item.SubItems.Add(fileInfo.Extension.IsNullOrWhitespace() ? "N/A" : fileInfo.Extension);
            item.SubItems.Add(friendlySize);
            item.ImageKey = imageKey;
            item.ToolTipText = string.Format("Extension: {0}\nSize: {1}", fileInfo.Extension, friendlySize);
            item.Tag = tag;
        }

        private string GetFriendlyFileSize(long length)
        {
            string[] suffixes = {"B", "KB", "MB", "GB", "TB", "PB", "EB"};

            if (length == 0) {
                return "0" + suffixes[0];
            }

            long bytes = Math.Abs(length);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes/Math.Pow(1024, place), 1);

            return (Math.Sign(length)*num) + " " + suffixes[place];
        }
    }
}