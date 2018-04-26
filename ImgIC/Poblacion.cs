using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgIC
{
    class Poblacion
    {
        Random ale = new Random();
        individuo[] ind;

        public int[] DeciToBin(int number)
        {
            int[] ret = new int[10];
            int temp = 0;
            while (number > 0)
            {
                ret[temp] = (number % 2 == 1) ? 1 : 0;
                number /= 2;
                temp++;
            }
            return ret;
        }

        public int BinToDeci(int[] bin)
        {
            int retorno = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                retorno += bin[i] * (int)Math.Pow(2, i);
            }
            return retorno;
        }

        public int ObtenerTam(int value)
        {
            return DeciToBin(value).Length;
        }

        public individuo[] CrearPoblacion(int W, int H, int tamaño, int[,] ma, System.Windows.Forms.ListBox Salida1)
        {
            ind = new individuo[tamaño];
            for (int n = 0; n < tamaño; n++)
            {
                ind[n] = new individuo();
                ind[n].X = ale.Next(0, W);
                ind[n].Y = ale.Next(0, H);
                ind[n].Evolucionado = false;
                ind[n].Xbin = DeciToBin(ind[n].X);
                ind[n].Ybin = DeciToBin(ind[n].Y);
                ind[n].Value = ma[ind[n].X, ind[n].Y];//evitar usar toda la matriz
            }
            for (int n = 0; n < tamaño; n++)
            {
                ind[n].Xdistante = Xdistante(ind, ind[n], 35);//individuo actual, toda la poblacion
                Salida1.Items.Add("[" + n + "]Xdistante : ->" + ind[n].Xdistante);
                ind[n].Fenotipo = ind[n].Xdistante + ind[n].Value;
            }
            return ind;
        }

        public int Xdistante(individuo[] all, individuo indActual, int umbral)
        {
            int acum = 0;//0
            for (int i = 0; i < all.Length; i++)
            {
                double raiz = Math.Sqrt(Math.Pow((indActual.X - all[i].X), 2) + Math.Pow((indActual.Y - all[i].Y), 2));
                acum += (raiz <= umbral) ? 1 : 0; //40 umbral
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

        public double calidad_poblacion(individuo[] ind)
        {
            int acum = 0;
            for (int i = 0; i < ind.Length; i++)
            {
                acum += ind[i].Fenotipo;
            }
            return acum / (float)ind.Length;
        }

        public int calculo_derivada(float[] der, float calidad)
        {
            float acum = 0;
            for (int i = 0; i < der.Length; i++)
            {
                acum += der[i];
            }
            return ((calidad == (acum / der.Length)) && (calidad != 0)) ? 1 : 0;
        }

        public individuo[] funcion_cruce(int individuo1, int individuo2, individuo[] poblacion,int umbral_d, Image img, int umbral)
        {
            int pivote = 0, test1 = 0, test2 = 0;
            int[] indX = new int[10], ind2X = new int[10], indY = new int[10], ind2Y = new int[10], temp = new int[10], fenotipos = new int[4], best = new int[2];
            bool option = true;
            while (option)            //violada en x
            {
                pivote = ale.Next(10);
                indX = poblacion[individuo1].Xbin;
                ind2X = poblacion[individuo2].Xbin;
                temp = indX;
                indX[pivote] = ind2X[pivote];
                ind2X[pivote] = temp[pivote];
                test1 = BinToDeci(indX);
                test2 = BinToDeci(ind2X);
                option = (test1 < img.Size.Width) && (test2 < img.Size.Width) ? false : true;
            }
            option = true;
            while (option)            //violada en y
            {
                pivote = ale.Next(10);
                indY = poblacion[individuo1].Ybin;
                ind2Y = poblacion[individuo2].Ybin;
                temp = indY;
                indY[pivote] = ind2Y[pivote];
                ind2Y[pivote] = temp[pivote];
                test1 = BinToDeci(indY);
                test2 = BinToDeci(ind2Y);
                option = (test1 < img.Size.Height) && (test2 < img.Size.Height) ? false : true;
            }
            //Determinacion del fenotipo de los violados
            individuo son1 = new individuo(), son2 = new individuo();
            IMG imagenparaalgo = new IMG(img);
            son1.Xbin = indX;
            son1.Ybin = indY;
            son1.X = BinToDeci(son1.Xbin);
            son1.Y = BinToDeci(son1.Ybin);
            son1.Xdistante = Xdistante(poblacion, son1, umbral_d);
            son1.Value = imagenparaalgo.gray2(son1, umbral);
            son1.Fenotipo = son1.Xdistante + son1.Value;
            son2.Xbin = ind2X;
            son2.Ybin = ind2Y;
            son2.X = BinToDeci(son2.Xbin);
            son2.Y = BinToDeci(son2.Ybin);
            son2.Xdistante = Xdistante(poblacion, son2, umbral_d);
            son2.Value = imagenparaalgo.gray2(son2, umbral);
            son2.Fenotipo = son2.Xdistante + son2.Value;
            //the best
            List<individuo> poblation = new List<individuo>();
            fenotipos[0] = poblacion[individuo1].Fenotipo;
            fenotipos[1] = poblacion[individuo2].Fenotipo;
            fenotipos[2] = son1.Fenotipo;
            fenotipos[3] = son2.Fenotipo;
            int max = 0, contador = 0;
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= fenotipos.Length; j++)
                {
                    for (int k = 0; k <= fenotipos.Length; k++)
                    {
                        max = (fenotipos[j] > fenotipos[k]) && (j != k) ? j : 0;
                    }
                }
                //the best
                if ((contador == 1) && (max == 1))
                {
                    max = 0;
                }
                contador = ((max == 1) && (contador == 0)) ? 1 : 0;
                switch (max)
                {
                    case 0:
                        poblation.Add(poblacion[individuo1]);
                        break;
                    case 1:
                        poblation.Add(poblacion[individuo2]);
                        break;
                    case 2:
                        poblation.Add(son1);
                        break;
                    case 3:
                        poblation.Add(son2);
                        break;
                }
                fenotipos[max] = 0;
                max = 1;
            }
            return poblation.ToArray(); //convertir list to array
        }

        public individuo funcion_mutar(individuo indi, individuo[] Poblacion, Image img, int umbral,int umbral_d)
        {
            individuo copia =indi;
            IMG paraalgo = new IMG(img);
            int pivote = 0, prueba = 0;
            bool op = true; 
            while (op)//Mutar en X
            {
                pivote = ale.Next(10);
                copia.Xbin[pivote] = (copia.Xbin[pivote] == 0) ? 1 : 0;
                prueba = BinToDeci(copia.Xbin);
                op = (prueba < img.Size.Width) ? false : true;
            } 
            op = true;
            while (op)//Mutar en Y
            {
                pivote = ale.Next(10);
                copia.Ybin[pivote] = (copia.Ybin[pivote] == 0) ? 1 : 0;
                prueba = BinToDeci(copia.Ybin);
                op = (prueba < img.Size.Height) ? false : true;
            }
            copia.X = BinToDeci(copia.Xbin);
            copia.Y = BinToDeci(copia.Ybin);
            copia.Value = paraalgo.gray2(copia, umbral);
            copia.Xdistante = Xdistante(Poblacion, copia, umbral_d);
            copia.Fenotipo = copia.Value + copia.Xdistante;
            return (copia.Fenotipo >= indi.Fenotipo) ? copia : indi;
        }

        public individuo[] Crear_generacion(individuo[] poblacion, float cruce, float mutacion, int umbral_distancia, Image imagen, int umbral)
        {
            int numero_cruces = (int)(cruce * (float)poblacion.Length);
            numero_cruces += ((numero_cruces % 2 == 1)) ? 1 : 0;
            numero_cruces = numero_cruces / 2;
            int numero_mutaciones = poblacion.Length - (numero_cruces * 2);
            for (int i = 1; i <= numero_cruces; i++)
            {
                int individuo1 = 0, individuo2 = 0;
                bool guardian = true;
                while (guardian)
                {
                    individuo1 = ale.Next(poblacion.Count);
                    individuo2 = ale.Next(poblacion.Count);
                    guardian = (poblacion[individuo1].Evolucionado == false) && (poblacion[individuo2].Evolucionado == false) ? false : true;
                }
                individuo[] cruzados =funcion_cruce(individuo1, individuo2, poblacion.ToArray(), umbral_distancia, imagen, umbral);
                poblacion[individuo1] = cruzados[0];
                poblacion[individuo2] = cruzados[1];
                poblacion[individuo1].Evolucionado = true;
                poblacion[individuo2].Evolucionado = true;
            }
            for (int i = 1; i <= numero_mutaciones; i++)
            {
                int individuo1 = 0;
                bool guardian2 = true;
                while (guardian2)
                {
                    individuo1 = ale.Next(poblacion.Count);
                    guardian2 = (poblacion[individuo1].Evolucionado == false) ? false : true;
                }
                poblacion[individuo1] = funcion_mutar(poblacion[individuo1], poblacion.ToArray(), imagen, umbral, umbral_distancia);
                poblacion[individuo1].Evolucionado = true;
            }
            return poblacion;
        }
    }
}