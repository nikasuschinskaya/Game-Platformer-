﻿using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GameEngine
{
    /// <summary>
    /// Загрузка текстуры.
    /// </summary>
    public class ContentPipe
    {
        /// <summary>
        /// Создание текстуры.
        /// </summary>
        /// <param name="path"> Путь к изображению. </param>
        /// <returns> Класс с параметрами текстуры. </returns>
        public static Texture2D LoadTexture(string path)
        {
            if (!File.Exists("Content/" + path))
            {
                throw new FileNotFoundException($"Файл не найден, проверьте путь {path}");
            }

            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            Bitmap bmp = new Bitmap("Content/" + path);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height,
                0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bmp.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
                (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
               (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            return new Texture2D(id, bmp.Width, bmp.Height);
        }
    }
}
