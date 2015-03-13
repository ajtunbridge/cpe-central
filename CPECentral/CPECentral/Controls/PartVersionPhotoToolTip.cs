using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CPECentral.Data.EF5;

namespace CPECentral.Controls
{
    public class PartVersionPhotoToolTip : ToolTip
    {
        public PartVersionPhotoToolTip()
        {
            OwnerDraw = true;
            Popup += OnPopup;
            Draw += OnDraw;
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            e.ToolTipSize = new Size(640, 480);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this to customzie the tool tip
        {
            Graphics g = e.Graphics;

            // to set the tag for each button or object
            Control parent = e.AssociatedControl;

            var partVersion = parent.Tag as PartVersion;

            using (var ms = new MemoryStream(partVersion.PhotoBytes)) {
                Image photo = Image.FromStream(ms);

                //create your own custom brush to fill the background with the image
                TextureBrush b = new TextureBrush(new Bitmap(photo)); // get the image from Tag

                g.FillRectangle(b, e.Bounds);
                b.Dispose();
            }
        }
    }
}