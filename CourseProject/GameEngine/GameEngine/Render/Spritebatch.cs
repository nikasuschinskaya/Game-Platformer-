using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

namespace GameEngine
{
    /// <summary>
    /// Работа с текстурой, отрисовка.
    /// </summary>
    public class Spritebatch : GameComponent
    {
        /// <summary>
        /// Отрисовка текстуры.
        /// </summary>
        /// <param name="texture">Текстура.</param>
        /// <param name="rectangle">Прямоугольник.</param>
        public static void Draw(Texture2D texture, RectangleF rectangle)
        {
            Draw(texture, new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.Width / texture.Width, rectangle.Height / texture.Height), Color.White, Vector2.Zero);
        }
        /// <summary>
        /// Отрисовка текстуры.
        /// </summary>
        /// <param name="texture"> Текстура. </param>
        /// <param name="position"> Позиция. </param>
        /// <param name="scale"> Масштаб. </param>
        /// <param name="color"> Цвет. </param>
        /// <param name="origin"> Начало. </param>
        /// <param name="sourceRec">Источник.</param>
        public static void Draw(Texture2D texture, Vector2 position, Vector2 scale, Color color, Vector2 origin, RectangleF? sourceRec = null)
        {
            Vector2[] vertices = new Vector2[4]
            {
                new Vector2 (0, 0),
                new Vector2 (1, 0),
                new Vector2 (1, 1),
                new Vector2 (0, 1)
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(color);
            for ( int i = 0; i < vertices.Length; i++)
            {
                if(sourceRec == null)
                    GL.TexCoord2(vertices[i]);
                else
                {
                    GL.TexCoord2((sourceRec.Value.Left + vertices[i].X * sourceRec.Value.Width) / texture.Width,
                        (sourceRec.Value.Top + vertices[i].Y * sourceRec.Value.Height) / texture.Height);
                }

                vertices[i].X *= (sourceRec == null) ? texture.Width : sourceRec.Value.Width;
                vertices[i].Y *= (sourceRec == null) ? texture.Height : sourceRec.Value.Height;
                vertices[i] -= origin;
                vertices[i] *= scale;
                vertices[i] += position;

                GL.Vertex2(vertices[i]);
            }

            GL.End();
        }

        /// <summary>
        /// Begin метод.
        /// </summary>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-screenWidth / 2.0f, screenWidth / 2.0f, screenHeight / 2.0f, -screenHeight / 2.0f, 0.0f, 1.0f);
        }

    }
}
