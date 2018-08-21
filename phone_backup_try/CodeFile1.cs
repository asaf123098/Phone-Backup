using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace phone_backup_try
{
    class ImageComparingClass
    {
        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }

        //public static void Main(string[] args)
        //{
        //    List<bool> iHash1 = GetHash(new Bitmap(@"C:\Users\Asaf\Desktop\1.jpg"));
        //    List<bool> iHash2 = GetHash(new Bitmap(@"C:\Users\Asaf\Desktop\2.jpg"));

        //    int equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);

        //}
    }
}

