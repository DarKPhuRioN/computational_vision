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
        private Random ale = new Random();
        private individuo[] ind;
        public int Generation { get; set; }
        public double[] Derivative { get; set; }

        public Poblacion()//constructor por defecto
        {
            Derivative = new double[10];
        }

        public int[] DeciToBin(int number)//convertir decimal a binario
        {
            int[] ret = new int[10];
            int j = 0;
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = 0;
            }
            bool op = true;
            while (op)
            {
                if (number <= 1)
                {
                    ret[j] = number;
                    op = false;
                }
                else
                {
                    ret[j] = number % 2;
                    number /= 2;
                    j++;
                }
            }
            return ret;
        }

        public int BinToDeci(int[] bin)//convertir Binario a decimal
        {
            int res = 0;
            for (int i = 0; i < bin.Length; i++)
            {
                res += bin[i] * (int)Math.Pow(2, i);
            }
            return res;   
        }

        public int ObtenerTam(int value)//obtener length de arreglo de binarios
        {
            return DeciToBin(value).Length;
        }

        public individuo[] CrearPoblacion(int W, int H, int Size, int umbral, IMG picture)//Crea la poblacion inicial
        {
            ind = new individuo[Size];
            for (int n = 0; n < Size; n++)
            {
                ind[n] = new individuo();
                ind[n].X = ale.Next(0, W);
                ind[n].Y = ale.Next(0, H);
                ind[n].Evolved = false;
                ind[n].Xbin = DeciToBin(ind[n].X);
                ind[n].Ybin = DeciToBin(ind[n].Y);
                ind[n].Value = picture.gray2(ind[n], umbral);
            }
            for (int n = 0; n < Size; n++)
            {
                ind[n].Xdist = Xdistant(ind, ind[n], umbral);
                ind[n].Phenotype = ind[n].Xdist + ind[n].Value;
            }
            return ind;
        }

        public int Xdistant(individuo[] all, individuo indCurrent, int umbral_d)//Calcula Xdistante
        {
            int acum = 0;
            for (int i = 0; i < all.Length; i++)
            {
                double raiz = Math.Sqrt(Math.Pow((indCurrent.X - all[i].X), 2) + Math.Pow((indCurrent.Y - all[i].Y), 2));
                 acum += (raiz <= umbral_d) ? 1 : 0;
            }
            return (acum == 2) ? 1 : 0;
        }

        public double Average(individuo[] ind)//calidad poblacion
        {
            double acum = 0;
            for (int i = 0; i < ind.Length; i++)
            {
                acum += ind[i].Phenotype;
            }
            return acum / ind.Length;
        }

        public int derivate_calculation(double[] der, double quality)// Calcula la derivada
        {
            double acum = 0;
            for (int i = 0; i < der.Length; i++)
            {
                acum += der[i];
            }
            return ((quality == (acum / der.Length)) && (quality != 0)) ? 1 : 0;
        }


        public individuo[] function_crossing(int ind1, int ind2, individuo[] poblation, int umbral_d, IMG picture, int umbral)
        {
            int pivot = 0, test1 = 0, test2 = 0, max = 0;
            int[] indX = new int[10], ind2X = new int[10], indY = new int[10], ind2Y = new int[10], temp = new int[10], Phenotypes = new int[4];
            bool option = true;
            while (option)            //violada en x
            {
                pivot = ale.Next(10);
                indX = poblation[ind1].Xbin;
                ind2X = poblation[ind2].Xbin;
                temp = indX;
                indX[pivot] = ind2X[pivot];
                ind2X[pivot] = temp[pivot];
                test1 = BinToDeci(indX);
                test2 = BinToDeci(ind2X);
                option = (test1 < picture.getW()) && (test2 < picture.getW()) ? false : true;
            }
            option = true;
            while (option)            //violada en y
            {
                pivot = ale.Next(10);
                indY = poblation[ind1].Ybin;
                ind2Y = poblation[ind2].Ybin;
                temp = indY;
                indY[pivot] = ind2Y[pivot];
                ind2Y[pivot] = temp[pivot];
                test1 = BinToDeci(indY);
                test2 = BinToDeci(ind2Y);
                option = (test1 < picture.getH()) && (test2 < picture.getH()) ? false : true;
            } //Determinacion del fenotipo de los violados
            individuo son1 = new individuo(), son2 = new individuo();
            son1.Xbin = indX;
            son1.Ybin = indY;
            son1.X = BinToDeci(son1.Xbin);
            son1.Y = BinToDeci(son1.Ybin);
            son1.Xdist = Xdistant(poblation, son1, umbral_d);
            son1.Value = picture.gray2(son1, umbral);
            son1.Phenotype = son1.Xdist + son1.Value;
            son2.Xbin = ind2X;
            son2.Ybin = ind2Y;
            son2.X = BinToDeci(son2.Xbin);
            son2.Y = BinToDeci(son2.Ybin);
            son2.Xdist = Xdistant(poblation, son2, umbral_d);
            son2.Value = picture.gray2(son2, umbral);
            son2.Phenotype = son2.Xdist + son2.Value;
            List<individuo> poblationFinal = new List<individuo>();
            Phenotypes[0] = poblation[ind1].Phenotype;
            Phenotypes[1] = poblation[ind2].Phenotype;
            Phenotypes[2] = son1.Phenotype;
            Phenotypes[3] = son2.Phenotype;
            for (int i = 0; i < Phenotypes.Length / 2; i++)
             {
                max = getBest(Phenotypes);
                 switch (max)
                 {
                     case 0:
                        poblationFinal.Add(poblation[ind1]);
                         break;
                     case 1:
                        poblationFinal.Add(poblation[ind2]);
                         break;
                     case 2:
                        poblationFinal.Add(son1);
                         break;
                     case 3:
                        poblationFinal.Add(son2);
                         break;
                 }
                 Phenotypes[max] = 0;
             }
            return poblationFinal.ToArray(); //convertir list to array*/
        }

        public int getBest(int[] values){
            int higher = 0, pos = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (higher <= values[i])
                {
                    higher = values[i];
                    pos = i;
                }
            }
            return pos;
        }

        public individuo function_mutate(individuo ind, individuo[] Poblation, IMG picture, int umbral, int umbral_d)
        {//mejorar
            individuo copy = ind;
            int pivot = 0, test = 0;
            bool op = true;
            while (op)//Mutar en X
            {
                pivot = ale.Next(10);
                copy.Xbin[pivot] = (copy.Xbin[pivot] == 0) ? 1 : 0;
                test = BinToDeci(copy.Xbin);
                op = (test < picture.getW()) ? false : true;
            }
            op = true;
            while (op)//Mutar en Y
            {
                pivot = ale.Next(10);
                copy.Ybin[pivot] = (copy.Ybin[pivot] == 0) ? 1 : 0;
                test = BinToDeci(copy.Ybin);
                op = (test < picture.getH()) ? false : true;
            }
            copy.X = BinToDeci(copy.Xbin);
            copy.Y = BinToDeci(copy.Ybin);
            copy.Value = picture.gray2(copy, umbral);
            copy.Xdist = Xdistant(Poblation, copy, umbral_d);
            copy.Phenotype = copy.Value + copy.Xdist;
            return (copy.Phenotype >= ind.Phenotype) ? copy : ind;
        }

        public individuo[] Create_Generation(individuo[] poblation, float cruce, int umbral_d, IMG picture, int umbral)
        {
            int num_cruces = (int)(cruce * (float)poblation.Length), ind1 = 0, ind2 = 0, num_mutations = 0;
            num_cruces += ((num_cruces % 2 == 1)) ? 1 : 0;
            num_cruces /= 2;
            num_mutations = (poblation.Length - (num_cruces * 2));
            bool op = true;
            for (int i = 0; i < num_cruces; i++)
            {
                while (op)
                {
                    ind1 = ale.Next(poblation.Length);
                    ind2 = ale.Next(poblation.Length);
                    op = (poblation[ind1].Evolved == false) && (poblation[ind2].Evolved == false) ? false : true;
                }
                individuo[] cruzados = function_crossing(ind1, ind2, poblation.ToArray(), umbral_d, picture, umbral);
                poblation[ind1] = cruzados[0];
                poblation[ind1].Evolved = true;
                poblation[ind2] = cruzados[1];
                poblation[ind2].Evolved = true;
            }
            for (int i = 0; i < num_mutations; i++)
            {
                ind1 = 0;
                op = true;
                while (op)
                {
                    ind1 = ale.Next(poblation.Length);
                    op = (poblation[ind1].Evolved == false) ? false : true;
                }
                poblation[ind1] = function_mutate(poblation[ind1], poblation.ToArray(), picture, umbral, umbral_d);
                poblation[ind1].Evolved = true;
            }
            return poblation;
        }

        public individuo[] UpdateState(individuo[] poblation)
        {
            for (int i = 0; i < poblation.Length; i++)
            {
                poblation[i].Evolved = false;
            }
            return poblation;
        }
    }
}