#region Using directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CPECentral.Properties;
using nGenLibrary.Imaging;

#endregion

namespace CPECentral.Dialogs
{
    public partial class PhotoEditorDialog : Form
    {
        private readonly Size _aspectRatio = new Size(16, 9);
        private readonly Image _originalImage;
        private readonly Brush _selectionBrush = new SolidBrush(Color.FromArgb(60, 200, 0, 0));
        private bool _adjustingBrightness, _adjustingContrast;
        private Image _currentImage;
        private PictureBox _currentPictureBox;
        private bool _drawSelection = false;
        private Point _rectStartPoint;
        private Rectangle _regionToCrop;
        private Rectangle _selectionRect;

        private int _x0;
        private int _x1;
        private int _y0;
        private int _y1;

        public PhotoEditorDialog(Image image)
        {
            InitializeComponent();

            _currentPictureBox = pictureBox;

            _originalImage = image.Clone() as Image;

            pictureBox.Image = image.Clone() as Image;

            _currentImage = pictureBox.Image.Clone() as Image;
        }

        public Image EditedImage { get; private set; }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine the initial rectangle coordinates...
            _rectStartPoint = e.Location;

            ConvertCoordinates(_currentPictureBox, out _x0, out _y0, e.X, e.Y);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) {
                return;
            }

            Point tempEndPoint = e.Location;

            var dist = new Point(tempEndPoint.X - _rectStartPoint.X, tempEndPoint.Y - _rectStartPoint.Y);

            var normalized = new Point(dist.X/_aspectRatio.Width, dist.Y/_aspectRatio.Height);

            int largestNormal = (Math.Abs(normalized.X) > Math.Abs(normalized.Y))
                ? Math.Abs(normalized.X)
                : Math.Abs(normalized.Y);

            var calcedOffset = new Point(largestNormal*_aspectRatio.Width, largestNormal*_aspectRatio.Height);

            if (dist.X < 0) {
                calcedOffset.X *= -1;
            }
            if (dist.Y < 0) {
                calcedOffset.Y *= -1;
            }

            var endPoint = new Point(_rectStartPoint.X + calcedOffset.X, _rectStartPoint.Y + calcedOffset.Y);

            _selectionRect.Location = new Point(
                Math.Min(_rectStartPoint.X, endPoint.X),
                Math.Min(_rectStartPoint.Y, endPoint.Y));

            _selectionRect.Size = new Size(
                Math.Abs(_rectStartPoint.X - endPoint.X),
                Math.Abs(_rectStartPoint.Y - endPoint.Y));

            _drawSelection = true;

            _currentPictureBox.Invalidate();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                int xEnd = _rectStartPoint.X > e.X ? _selectionRect.Left : _selectionRect.Right;
                int yEnd = _rectStartPoint.Y > e.Y ? _selectionRect.Top : _selectionRect.Bottom;

                ConvertCoordinates(_currentPictureBox, out _x1, out _y1, xEnd, yEnd);

                _regionToCrop = MakeRectangle(_x0, _y0, _x1, _y1);

                cropToolStripButton.Enabled = _regionToCrop.Width >= 360 && _regionToCrop.Height >= 205;
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (_drawSelection) {
                if (_selectionRect != null && _selectionRect.Width > 0 && _selectionRect.Height > 0) {
                    e.Graphics.FillRectangle(_selectionBrush, _selectionRect);

                    using (var dottedPen = new Pen(Brushes.WhiteSmoke, 1)) {
                        dottedPen.DashStyle = DashStyle.Dash;
                        e.Graphics.DrawRectangle(dottedPen, _selectionRect);
                    }
                }
            }
        }

        // Return a Rectangle with these points as corners.
        private Rectangle MakeRectangle(int x0, int y0, int x1, int y1)
        {
            return new Rectangle(
                Math.Min(x0, x1),
                Math.Min(y0, y1),
                Math.Abs(x0 - x1),
                Math.Abs(y0 - y1));
        }

        private Image ResizeImage(Image image, double width, double height)
        {
            double ratioX = width/image.Width;
            double ratioY = height/image.Height;

            double ratio = ratioX < ratioY ? ratioX : ratioY;

            int newHeight = Convert.ToInt32(image.Height*ratio);
            int newWidth = Convert.ToInt32(image.Width*ratio);

            var destRect = new Rectangle(0, 0, newWidth, newHeight);
            var destImage = new Bitmap(newWidth, newHeight);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RemoveAndCreatePictureBox(_originalImage);

            _currentPictureBox.MouseDown += pictureBox_MouseDown;
            _currentPictureBox.MouseMove += pictureBox_MouseMove;
            _currentPictureBox.MouseUp += pictureBox_MouseUp;
            _currentPictureBox.Paint += pictureBox_Paint;

            _currentPictureBox.Cursor = Cursors.Cross;

            originalImageToolStripButton.Enabled = false;

            brightnessTrackBar.Value = 0;
            contrastTrackBar.Value = 0;
        }

        private Bitmap AdjustBrightness(Bitmap image, int value)
        {
            Bitmap tempBitmap = image;
            float finalValue = value/255.0f;
            var newBitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
            Graphics newGraphics = Graphics.FromImage(newBitmap);

            float[][] floatColorMatrix = {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {finalValue, finalValue, finalValue, 1, 1}
            };

            var newColorMatrix = new ColorMatrix(floatColorMatrix);

            var attributes = new ImageAttributes();

            attributes.SetColorMatrix(newColorMatrix);

            newGraphics.DrawImage(tempBitmap, new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), 0, 0,
                tempBitmap.Width, tempBitmap.Height, GraphicsUnit.Pixel, attributes);

            attributes.Dispose();
            newGraphics.Dispose();
            tempBitmap.Dispose();

            return newBitmap;
        }

        private Bitmap AdjustContrast(Bitmap image, int value)
        {
            Bitmap tempBitmap = image;
            float finalValue = 1 + value/255.0f;
            var newBitmap = new Bitmap(tempBitmap.Width, tempBitmap.Height);
            Graphics newGraphics = Graphics.FromImage(newBitmap);

            float[][] floatColorMatrix = {
                new float[] {finalValue, 0, 0, 0, 0},
                new float[] {0, finalValue, 0, 0, 0},
                new float[] {0, 0, finalValue, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 1, 1}
            };

            var newColorMatrix = new ColorMatrix(floatColorMatrix);

            var attributes = new ImageAttributes();

            attributes.SetColorMatrix(newColorMatrix);

            newGraphics.DrawImage(tempBitmap, new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), 0, 0,
                tempBitmap.Width, tempBitmap.Height, GraphicsUnit.Pixel, attributes);

            attributes.Dispose();
            newGraphics.Dispose();
            tempBitmap.Dispose();

            return newBitmap;
        }

        private void cropToolStripButton_Click(object sender, EventArgs e)
        {
            var workerPictureBox = new PictureBox();
            workerPictureBox.Image = Resources.PreloaderImage2;
            workerPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            workerPictureBox.Left = (_currentPictureBox.Width - workerPictureBox.Width)/2;
            workerPictureBox.Top = (_currentPictureBox.Height - workerPictureBox.Height)/2;

            workerPictureBox.BackColor = Color.Transparent;

            _currentPictureBox.Controls.Add(workerPictureBox);

            _drawSelection = false;
            _currentPictureBox.Invalidate();

            cropToolStripButton.Enabled = false;
            originalImageToolStripButton.Enabled = false;
            saveToolStripButton.Enabled = false;

            var worker = new BackgroundWorker();

            worker.DoWork += (obj, args) => {
                _drawSelection = false;

                var pic = args.Argument as Image;

                // Create cropped image:
                Image img = pic.Crop(_regionToCrop);

                img = Sharpen(img, 0.5f);

                args.Result = img;
            };

            worker.RunWorkerCompleted += (obj, args) => {
                cropToolStripButton.Enabled = false;

                originalImageToolStripButton.Enabled = true;
                saveToolStripButton.Enabled = true;

                var img = args.Result as Image;

                RemoveAndCreatePictureBox(img);
            };

            worker.RunWorkerAsync(_currentPictureBox.Image.Clone());
        }

        // Convert the coordinates for the image's SizeMode.
        private void ConvertCoordinates(PictureBox pic, out int outX, out int outY, int x, int y)
        {
            int picHgt = pic.ClientSize.Height;
            int picWid = pic.ClientSize.Width;
            int imgHgt = pic.Image.Height;
            int imgWid = pic.Image.Width;

            outX = x;
            outY = y;
            switch (pic.SizeMode) {
                case PictureBoxSizeMode.AutoSize:
                case PictureBoxSizeMode.Normal:
                    // These are okay. Leave them alone.
                    break;
                case PictureBoxSizeMode.CenterImage:
                    outX = x - (picWid - imgWid)/2;
                    outY = y - (picHgt - imgHgt)/2;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    outX = (int) (imgWid*x/(float) picWid);
                    outY = (int) (imgHgt*y/(float) picHgt);
                    break;
                case PictureBoxSizeMode.Zoom:
                    float picAspect = picWid/(float) picHgt;
                    float imgAspect = imgWid/(float) imgWid;
                    if (picAspect > imgAspect) {
                        // The PictureBox is wider/shorter than the image.
                        outY = (int) (imgHgt*y/(float) picHgt);

                        // The image fills the height of the PictureBox.
                        // Get its width.
                        float scaledWidth = imgWid*picHgt/imgHgt;
                        float dx = (picWid - scaledWidth)/2;
                        outX = (int) ((x - dx)*imgHgt/(float) picHgt);
                    }
                    else {
                        // The PictureBox is taller/thinner than the image.
                        outX = (int) (imgWid*x/(float) picWid);

                        // The image fills the height of the PictureBox.
                        // Get its height.
                        float scaledHeight = imgHgt*picWid/imgWid;
                        float dy = (picHgt - scaledHeight)/2;
                        outY = (int) ((y - dy)*imgWid/picWid);
                    }
                    break;
            }
        }

        /// <summary>
        ///     Sharpens the specified image.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="strength">The strength.</param>
        /// <returns></returns>
        public static Bitmap Sharpen(Image image, double strength)
        {
            using (var bitmap = image as Bitmap) {
                if (bitmap != null) {
                    var sharpenImage = bitmap.Clone() as Bitmap;

                    int width = image.Width;
                    int height = image.Height;

                    // Create sharpening filter.
                    const int filterSize = 5;

                    var filter = new double[,] {
                        {-1, -1, -1, -1, -1},
                        {-1, 2, 2, 2, -1},
                        {-1, 2, 16, 2, -1},
                        {-1, 2, 2, 2, -1},
                        {-1, -1, -1, -1, -1}
                    };

                    double bias = 1.0 - strength;
                    double factor = strength/16.0;

                    const int s = filterSize/2;

                    var result = new Color[image.Width, image.Height];

                    // Lock image bits for read/write.
                    if (sharpenImage != null) {
                        BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height),
                            ImageLockMode.ReadWrite,
                            PixelFormat.Format24bppRgb);

                        // Declare an array to hold the bytes of the bitmap.
                        int bytes = pbits.Stride*height;
                        var rgbValues = new byte[bytes];

                        // Copy the RGB values into the array.
                        Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

                        int rgb;
                        // Fill the color array with the new sharpened color values.
                        for (int x = s; x < width - s; x++) {
                            for (int y = s; y < height - s; y++) {
                                double red = 0.0, green = 0.0, blue = 0.0;

                                for (int filterX = 0; filterX < filterSize; filterX++) {
                                    for (int filterY = 0; filterY < filterSize; filterY++) {
                                        int imageX = (x - s + filterX + width)%width;
                                        int imageY = (y - s + filterY + height)%height;

                                        rgb = imageY*pbits.Stride + 3*imageX;

                                        red += rgbValues[rgb + 2]*filter[filterX, filterY];
                                        green += rgbValues[rgb + 1]*filter[filterX, filterY];
                                        blue += rgbValues[rgb + 0]*filter[filterX, filterY];
                                    }

                                    rgb = y*pbits.Stride + 3*x;

                                    int r = Math.Min(Math.Max((int) (factor*red + (bias*rgbValues[rgb + 2])), 0), 255);
                                    int g = Math.Min(Math.Max((int) (factor*green + (bias*rgbValues[rgb + 1])), 0), 255);
                                    int b = Math.Min(Math.Max((int) (factor*blue + (bias*rgbValues[rgb + 0])), 0), 255);

                                    result[x, y] = Color.FromArgb(r, g, b);
                                }
                            }
                        }

                        // Update the image with the sharpened pixels.
                        for (int x = s; x < width - s; x++) {
                            for (int y = s; y < height - s; y++) {
                                rgb = y*pbits.Stride + 3*x;

                                rgbValues[rgb + 2] = result[x, y].R;
                                rgbValues[rgb + 1] = result[x, y].G;
                                rgbValues[rgb + 0] = result[x, y].B;
                            }
                        }

                        // Copy the RGB values back to the bitmap.
                        Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
                        // Release image bits.
                        sharpenImage.UnlockBits(pbits);
                    }

                    return sharpenImage;
                }
            }
            return null;
        }

        private void RemoveAndCreatePictureBox(Image image)
        {
            _currentPictureBox.Dispose();
            _currentImage.Dispose();

            panel1.Controls.Remove(_currentPictureBox);

            var picBox = new PictureBox();
            picBox.Dock = DockStyle.Fill;
            picBox.BackgroundImage = Resources.DocumentPreviewBgTile;
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.Image = image;
            picBox.BorderStyle = BorderStyle.Fixed3D;

            _currentPictureBox = picBox;

            _currentImage = (Image) picBox.Image.Clone();

            panel1.Controls.Add(picBox);

            GC.Collect();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            EditedImage = ResizeImage(_currentImage, 360, 205);
            DialogResult = DialogResult.OK;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Brightness = " + brightnessTrackBar.Value.ToString("D3");
            _adjustingBrightness = true;
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Contrast = " + contrastTrackBar.Value.ToString("D3");
            _adjustingContrast = true;
        }

        private void brightnessTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (_adjustingBrightness) {
                _adjustingBrightness = false;
                Bitmap image = AdjustBrightness((Bitmap) _currentImage.Clone(), brightnessTrackBar.Value);
                image = AdjustContrast(image, contrastTrackBar.Value);
                _currentPictureBox.Image = image;
            }

            GC.Collect();
        }

        private void contrastTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (_adjustingContrast) {
                _adjustingContrast = false;
                Bitmap image = AdjustBrightness((Bitmap) _currentImage.Clone(), brightnessTrackBar.Value);
                image = AdjustContrast(image, contrastTrackBar.Value);
                _currentPictureBox.Image = image;
            }

            GC.Collect();
        }
    }
}