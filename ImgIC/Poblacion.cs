using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgIC
{
    class Poblacion
    {
        Random ale = new Random();
        public int x = 0, y = 0, val1 = 0, val2 = 0;
        individuo[] ind = new individuo[100];
        public string DeciToBin(int number)
        {
            string bin = "";
            while (number > 0)
            {
                bin = (number % 2 == 1) ? bin += 1 : bin += 0;
                number /= 2;
            }
            return bin;
        }

        public int BinToDeci(string bin)
        {
            int exponente = bin.Length - 1, Decimal = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                if (int.Parse(bin.Substring(i, 1)) == 1)
                {
                    Decimal += int.Parse(System.Math.Pow(2, double.Parse(exponente.ToString())).ToString());
                }
                exponente--;
            }
            return Decimal;
        }

        public int ObtenerTam(int value)
        {
            return DeciToBin(value).Length;
        }

        public void CrearPoblacion(int W, int H, int[,] ma, System.Windows.Forms.ListBox Salida1)
        {
            for (int n = 0; n < 100; n++)
            {
                ind[n] = new individuo();
                ind[n].X = ale.Next(0, W);
                ind[n].Y = ale.Next(0, H);
                ind[n].Evolucionado = false;
                ind[n].Xbin = DeciToBin(ind[n].X);
                ind[n].Ybin = DeciToBin(ind[n].Y);
                ind[n].Value = ma[ind[n].X, ind[n].Y];
            }
            for (int n = 0; n < 100; n++)
            {
                ind[n].Xdistante = Xdistante(ind, ind[n]);//individuo actual, toda la poblacion
                Salida1.Items.Add("[" + n + "]Xdistante : ->" + ind[n].Xdistante);
                ind[n].Fenotipo = ind[n].Xdistante + ind[n].Value;
            }
        }

        public int Xdistante(individuo[] all, individuo indActual)
        {
            int acum = 0;//0
            for (int i = 0; i < all.Length; i++)
            {
                double raiz = Math.Sqrt(Math.Pow((indActual.X - all[i].X), 2) + Math.Pow((indActual.Y - all[i].Y), 2));
                acum += (raiz <= 35) ? 1 : 0; //40 umbral
            }
            return (acum == 2) ? 1 : 0;
        }

        public double Promedio(individuo[] ind)
        {
            double acum = 0;
            for (int i = 0; i < ind.Length; i++)
            {
                acum += ind[i].Fenotipo;
            }
            return acum / ind.Length;
        }

        public int dProm() {
            return 0;
        }
    }
}
