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

    }
}
