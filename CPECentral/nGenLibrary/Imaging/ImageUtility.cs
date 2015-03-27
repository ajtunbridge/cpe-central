#region Using directives

using System.Drawing;
using System.IO;

#endregion

namespace nGenLibrary.Imaging
{
    public static class ImageUtility
    {
        public static Image ConvertBytesToImage(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length)) {
                var image = new Bitmap(ms);
                return image;
            }
        }

        public static byte[] ConvertImageToBytes(Image image)
        {
            var imageConverter = new ImageConverter();
            var bytes = (byte[]) imageConverter.ConvertTo(image, typeof (byte[]));
            return bytes;
        }
    }
}