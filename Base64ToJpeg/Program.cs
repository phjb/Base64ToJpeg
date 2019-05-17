using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Base64ToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            //Caminho da imagem no servidor
            //  string path = Path.GetFullPath("cartao_digital_elolife.png");

            if (!Directory.Exists("img"))
            {
                Directory.CreateDirectory("img");
            }

            string fileName = "cartao_digital_elolife.png";
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

                    //Escrever na página o Base64 da imagem
                    Console.Write(base64);
    
                    

                }
            }

            SaveByteArrayAsImage(Path.Combine(Environment.CurrentDirectory, @"img\", "img.png"), base64);
        }

        protected static void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }

            image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
