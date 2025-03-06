using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class ConvertToBItmap
    {
        public static Bitmap LoadImage(string photoFileName, string path)
        {
            string fullPath = Path.Combine(path, photoFileName);
            if (File.Exists(fullPath))
            {
                return new Bitmap(fullPath);
            }
            else
            {
                Console.WriteLine($"Изображение не найдено: {fullPath}");
                return new Bitmap("D:\\desktop\\Desktop\\Desktop\\Assets\\default.png");
            }
        }
    }
}
