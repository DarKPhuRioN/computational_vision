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
        private Bitmap img;
        private int[,] matriz;
        public IMG(Image img)
        {
            this.img = new Bitmap(img); 
        }
        public IMG(int Width, int Height, Image img)
        {
            this.Width = Width;
            this.Height = Height;
            this.img = new Bitmap(img);
            this.matriz = new int[Width, Height];
        }
        public Bitmap gray()
        {
            for (int i = 0; i < this.img.Width; i++)
            {
                for (int j = 0; j < this.img.Height; j++)
                {
                    Color color = (img.GetPixel(i, j));
                    byte gris = (byte)(color.R * 0.3f + color.G * 0.59f + color.B * 0.11f);
                    if (gris > 100)
                    {
                        matriz[i, j] = 1;
                        img.SetPixel(i, j, Color.FromArgb(gris));
                    }
                    else
                    {
                        matriz[i, j] = 0;
                        img.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }

                }
            }
            return this.img;
        }
        public int gray2(individuo ind, int umbral) //preguintarle mayor o menor
        {
            Color color = (img.GetPixel(ind.X, ind.Y));
            byte gris = (byte)(color.R * 0.3f + color.G * 0.59f + color.B * 0.11f);
            return (gris >= umbral) ? 1 : 0;
        }

        public int[,] getmatriz()
        {
            return this.matriz;
        }
        public int geti()
        {
            return Width;
        }
        public int getj()
        {
            return Height;
        }
        public Image ubicar_puntos(int x, int y, Image image)
        {
            Graphics temp;
            img = new Bitmap(image);
            Pen penTest = new System.Drawing.Pen(Brushes.Red);
            using (temp = Graphics.FromImage(img))
            {
                temp.DrawEllipse(penTest, x, y, 5, 5);
            }
            return img;
        }
    }
}