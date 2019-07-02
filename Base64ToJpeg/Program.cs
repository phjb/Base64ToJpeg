using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Base64ToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
           
            if (!Directory.Exists("img"))
            {
                Directory.CreateDirectory("img");
            }

            string fileName = "mib_pug.jpg";
            string path = Path.Combine(Environment.CurrentDirectory, @"img\", fileName);
            string base64 = "";
            //Bitmap da nossa imagem de exemplo
            using (Bitmap bmp = new Bitmap(path))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    //Salvar a imagem no MemoryStream
                    bmp.Save(ms, bmp.RawFormat);

                    //Converter o byte[] do MemoryStream para Base64
                     base64 = Convert.ToBase64String(ms.ToArray());

                    Console.WriteLine("\n\r=== Escrever na página o Base64 da imagem ====\n\r");

                    //Escrever na página o Base64 da imagem
                    Console.WriteLine(base64);
    
                    

                }
            }

            SaveByteArrayAsImage(Path.Combine(Environment.CurrentDirectory, @"img\", "img.png"), base64);
        }

       
        protected static void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            //Converte em byte a string Base64
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            //Converter o byte[] para MemoryStream
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms, true);
            }

            //Converte a Image em Bitmap
            Bitmap bmp = new Bitmap(image);

            //Salva a nova imgem
            bmp.Save(fullOutputPath, ImageFormat.Png);

            Console.WriteLine("\n\r=== Imagem: {0}, criada em: {1} ===", "img.png", fullOutputPath);
        }
    }
}
