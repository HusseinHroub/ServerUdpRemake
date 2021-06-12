using Alchemy.Classes;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ServerUdpRemake.command
{
    class TakeScreenShotCommand : Command
    {
       
        public void Apply(UserContext context)
        {
            var test = getScreenshotImage();
            Console.WriteLine(test.Length);
            context.Send(getScreenshotImage());
            //context.Send(new byte[] {1, 2, 3, 5});
        }

        private byte[] getScreenshotImage()
        {
            var bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           PixelFormat.Format32bppArgb);

            fillBitmapGraphicWithDesktopImage(bitmap);
            return imageToByte(bitmap);
        }

        private void fillBitmapGraphicWithDesktopImage(Bitmap bmpScreenshot)
        {
            Graphics.FromImage(bmpScreenshot).CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);
        }

        private byte[] imageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
