﻿using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace OCR
{
	class ImageProcessor
	{
        public static bool CutImage(string filepath, int targetWidth, int targetHeight)
        {
            var jpgInfo = ImageCodecInfo.GetImageEncoders().Where(codecInfo => codecInfo.MimeType == "image/jpeg").First();
            var image = new Bitmap(filepath);
            var x = image.Width / 2 - targetWidth;
            var y = image.Height / 2 - targetHeight;
            var cropArea = new Rectangle(x, y, 2 * targetWidth, 2 * targetHeight);
            try
            {
                using (EncoderParameters encParams = new EncoderParameters(1))
                {
                    var croppedImage = image.Clone(cropArea, image.PixelFormat);
                    image.Dispose();
                    encParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)100);
                    //quality should be in the range [0..100] .. 100 for max, 0 for min (0 best compression)
                    croppedImage = new Bitmap(croppedImage, new Size(targetWidth, targetHeight));
                    File.Delete(filepath);
                    croppedImage.Save(filepath, jpgInfo, encParams);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static int CountPixels(Bitmap b, int startX, int startY, int toX, int toY)
        {
            var matches = 0;
            for (int y = startY; y < toY; y++)
            {
                for (int x = startX; x < toX; x++)
                {
                    if (b.GetPixel(x, y) == Color.FromArgb(255, 0, 0, 0)) matches++;
                }
            }
            return matches;
        }

        public static float[] ConvertImageToData(string path)
        {
            var image = new Bitmap(path);
            var width = image.Width;
            var height = image.Height;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var c = image.GetPixel(x, y);
                    var scale = c.R + c.G + c.B;
                    var isWhite = scale > 600 ? true : false;
                    if (isWhite)
                    {
                        c = Color.FromArgb(255, 255, 255, 255);
                    }
                    else
                    {
                        c = Color.FromArgb(255, 0, 0, 0);
                    }
                    image.SetPixel(x, y, c);
                }
            }
            var partWidth = width / 8;
            var partHeight = height / 8;
            var PixelValues = new float[64];
            var k = 0;
            try
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        PixelValues[k++] = CountPixels(image, i * partWidth, j * partHeight, (i + 1) * partWidth - 1, (j + 1) * partHeight - 1);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return null;
            }
            finally
            {
                if (image != null)
                    image.Dispose();
            }
            return PixelValues;
        }
    }
}
