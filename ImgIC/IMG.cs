using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImgIC
{
    class IMG
    {
        private int Width, Height;
        private Bitmap Img;
        private int[,] matriz;

        public IMG()
        {
        }

        public IMG(int Width, int Height, Image img)
        {
            this.Width = Width;
            this.Height = Height;
            this.Img = new Bitmap(img);
            this.matriz = new int[Width, Height];
        }

        public Bitmap gray()
        {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    Color color = (Img.GetPixel(i, j));
                    byte gris = (byte)(color.R * 0.3f + color.G * 0.59f + color.B * 0.11f);
                    if (gris > 100)
                    {
                        matriz[i, j] = 1;
                        Img.SetPixel(i, j, Color.FromArgb(gris));
                    }
                    else
                    {
                        matriz[i, j] = 0;
                        Img.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }

                }
            }
            return this.Img;
        }

        public int gray2(individuo ind, int umbral) //preguintarle mayor o menor
        {
            Color color = (Img.GetPixel(ind.X, ind.Y));
            byte gris = (byte)(color.R * 0.3f + color.G * 0.59f + color.B * 0.11f);
            return (gris >= umbral) ? 1 : 0;
        }

        public int[,] getmatriz()
        {
            return this.matriz;
        }

        public int getW()
        {
            return Width;
        }

        public int getH()
        {
            return Height;
        }

        public Image ubicar_puntos(int x, int y, Image image)
        {
            Pen penTest = new System.Drawing.Pen(Brushes.Green);
            using (Graphics temp = Graphics.FromImage(image))
            {
                temp.DrawEllipse(penTest, x, y, 4, 4);
            }
            return image;
        }
    }
}