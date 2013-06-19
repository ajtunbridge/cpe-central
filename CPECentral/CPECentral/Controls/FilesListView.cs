using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary;
using nGenLibrary.Controls;

namespace CPECentral.Controls
{
    public partial class FilesListView : EnhancedListView
    {
        private static ImageList _smallIconImageList;
        private static ImageList _largeIconImageList;

        public FilesListView()
        {
            InitializeComponent();

            if (_smallIconImageList == null)
            {
                _smallIconImageList = new ImageList();
                _smallIconImageList.ImageSize = new Size(16, 16);
                _smallIconImageList.ColorDepth = ColorDepth.Depth32Bit;
                _smallIconImageList.Images.Add("GenericFileIcon", Resources.GenericFileIcon);
            }

            if (_largeIconImageList == null)
            {

                _largeIconImageList = new ImageList();
                _largeIconImageList.ImageSize = new Size(32, 32);
                _largeIconImageList.ColorDepth = ColorDepth.Depth32Bit;
                _largeIconImageList.Images.Add("GenericFileIcon", Resources.GenericFileIcon);
            }

            SmallImageList = _smallIconImageList;
            LargeImageList = _largeIconImageList;
        }

        public void AddFile(string fileName, object tag)
        {
            var fileInfo = new FileInfo(fileName);

            var indexOfLastDot = fileName.LastIndexOf(".");

            string extension = "GenericFileIcon";

            if (indexOfLastDot > 0)
            {
                // set the image key as the file extension
                extension = fileInfo.Extension;

                if (!_smallIconImageList.Images.ContainsKey(extension))
                {
                    var smallIcon = Win32.GetIconForFileExtension(extension, false, false);
                    var largeIcon = Win32.GetIconForFileExtension(extension, true, false);

                    _smallIconImageList.Images.Add(extension, smallIcon);
                    _largeIconImageList.Images.Add(extension, largeIcon);
                }
            }

            var friendlySize = GetFriendlyFileSize(fileInfo.Length);

            var item = Items.Add(fileInfo.Name);
            item.SubItems.Add(extension);
            item.SubItems.Add(friendlySize);
            item.ImageKey = extension;
            item.Tag = tag;
        }
       
        private string GetFriendlyFileSize(long length)
        {
            string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

            if (length == 0)
                return "0" + suffixes[0];

            long bytes = Math.Abs(length);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);

            return (Math.Sign(length) * num) + " " + suffixes[place];
        }
    }
}
