﻿using System;
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
        public int Generacion { get; set; }
        public double[] Derivada { get; set; }

        public Poblacion()//constructor por defecto
        {
            Derivada = new double[10];
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

        public individuo[] CrearPoblacion(int W, int H, int tamaño, int umbral, IMG picture)//Crea la poblacion inicial
        {
            ind = new individuo[tamaño];
            for (int n = 0; n < tamaño; n++)
            {
                ind[n] = new individuo();
                ind[n].X = ale.Next(0, W);
                ind[n].Y = ale.Next(0, H);
                ind[n].Evolved = false;
                ind[n].Xbin = DeciToBin(ind[n].X);
                ind[n].Ybin = DeciToBin(ind[n].Y);
                ind[n].Value = picture.gray2(ind[n], umbral);
            }
            for (int n = 0; n < tamaño; n++)
            {
                ind[n].Xdist = Xdistante(ind, ind[n], umbral);
                ind[n].Phenotype = ind[n].Xdist + ind[n].Value;
            }
            return ind;
        }

        public int Xdistante(individuo[] all, individuo indActual, int umbral_d)//Calcula Xdistante
        {
            int acum = 0;
            for (int i = 0; i < all.Length; i++)
            {
                double raiz = Math.Sqrt(Math.Pow((indActual.X - all[i].X), 2) + Math.Pow((indActual.Y - all[i].Y), 2));
                 acum += (raiz <= umbral_d) ? 1 : 0;
            }
            return (acum == 2) ? 1 : 0;
        }

        public double Promedio(individuo[] ind)//calidad poblacion
        {
            double acum = 0;
            for (int i = 0; i < ind.Length; i++)
            {
                acum += ind[i].Phenotype;
            }
            return acum / ind.Length;
        }

        public int calculo_derivada(double[] der, double calidad)// Calcula la derivada
        {
            double acum = 0;
            for (int i = 0; i < der.Length; i++)
            {
                acum += der[i];
            }
            return ((calidad == (acum / der.Length)) && (calidad != 0)) ? 1 : 0;
        }


        public individuo[] funcion_cruce(int ind1, int ind2, individuo[] poblacion, int umbral_d, IMG picture, int umbral)
        {
            int pivote = 0, test1 = 0, test2 = 0, max = 0, contador = 0;
            int[] indX = new int[10], ind2X = new int[10], indY = new int[10], ind2Y = new int[10], temp = new int[10], Phenotypes = new int[4], best = new int[2];
            bool option = true;
            while (option)            //violada en x
            {
                pivote = ale.Next(10);
                indX = poblacion[ind1].Xbin;
                ind2X = poblacion[ind2].Xbin;
                temp = indX;
                indX[pivote] = ind2X[pivote];
                ind2X[pivote] = temp[pivote];
                test1 = BinToDeci(indX);
                test2 = BinToDeci(ind2X);
                option = (test1 < picture.getW()) && (test2 < picture.getW()) ? false : true;
            }
            option = true;
            while (option)            //violada en y
            {
                pivote = ale.Next(10);
                indY = poblacion[ind1].Ybin;
                ind2Y = poblacion[ind2].Ybin;
                temp = indY;
                indY[pivote] = ind2Y[pivote];
                ind2Y[pivote] = temp[pivote];
                test1 = BinToDeci(indY);
                test2 = BinToDeci(ind2Y);
                option = (test1 < picture.getH()) && (test2 < picture.getH()) ? false : true;
            } //Determinacion del fenotipo de los violados
            individuo son1 = new individuo(), son2 = new individuo();
            son1.Xbin = indX;
            son1.Ybin = indY;
            son1.X = BinToDeci(son1.Xbin);
            son1.Y = BinToDeci(son1.Ybin);
            son1.Xdist = Xdistante(poblacion, son1, umbral_d);
            son1.Value = picture.gray2(son1, umbral);
            son1.Phenotype = son1.Xdist + son1.Value;
            son2.Xbin = ind2X;
            son2.Ybin = ind2Y;
            son2.X = BinToDeci(son2.Xbin);
            son2.Y = BinToDeci(son2.Ybin);
            son2.Xdist = Xdistante(poblacion, son2, umbral_d);
            son2.Value = picture.gray2(son2, umbral);
            son2.Phenotype = son2.Xdist + son2.Value;
            List<individuo> poblation = new List<individuo>();
            Phenotypes[0] = poblacion[ind1].Phenotype;
            Phenotypes[1] = poblacion[ind2].Phenotype;
            Phenotypes[2] = son1.Phenotype;
            Phenotypes[3] = son2.Phenotype;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < Phenotypes.Length; j++)
                {
                    for (int k = 0; k < Phenotypes.Length; k++)
                    {
                        max = ((Phenotypes[j] > Phenotypes[k]) && (j != k)) ? j : 0;
                    }
                } //the best
                if ((contador == 1) && (max == 1))
                {
                    max = 0;
                }
                contador = ((max == 1) && (contador == 0)) ? 1 : 0;
                switch (max)
                {
                    case 0:
                        poblation.Add(poblacion[ind1]);
                        break;
                    case 1:
                        poblation.Add(poblacion[ind2]);
                        break;
                    case 2:
                        poblation.Add(son1);
                        break;
                    case 3:
                        poblation.Add(son2);
                        break;
                }
                Phenotypes[max] = 0;
                max = 1;
            }
            return poblation.ToArray(); //convertir list to array
        }

        public individuo funcion_mutar(individuo indi, individuo[] Poblacion, IMG picture, int umbral, int umbral_d)
        {//mejorar
            individuo copia = indi;
            int pivote = 0, prueba = 0;
            bool op = true;
            while (op)//Mutar en X
            {
                pivote = ale.Next(10);
                copia.Xbin[pivote] = (copia.Xbin[pivote] == 0) ? 1 : 0;
                prueba = BinToDeci(copia.Xbin);
                op = (prueba < picture.getW()) ? false : true;
            }
            op = true;
            while (op)//Mutar en Y
            {
                pivote = ale.Next(10);
                copia.Ybin[pivote] = (copia.Ybin[pivote] == 0) ? 1 : 0;
                prueba = BinToDeci(copia.Ybin);
                op = (prueba < picture.getH()) ? false : true;
            }
            copia.X = BinToDeci(copia.Xbin);
            copia.Y = BinToDeci(copia.Ybin);
            copia.Value = picture.gray2(copia, umbral);
            copia.Xdist = Xdistante(Poblacion, copia, umbral_d);
            copia.Phenotype = copia.Value + copia.Xdist;
            return (copia.Phenotype >= indi.Phenotype) ? copia : indi;
        }

        public individuo[] Crear_generacion(individuo[] poblacion, float cruce, float mutacion, int umbral_d, IMG picture, int umbral)
        {
            int numero_cruces = (int)(cruce * (float)poblacion.Length), individuo1 = 0, individuo2 = 0, numero_mutaciones = 0;
            numero_cruces += ((numero_cruces % 2 == 1)) ? 1 : 0;
            numero_cruces = numero_cruces / 2;
            numero_mutaciones = poblacion.Length - (numero_cruces * 2);
            bool op = true;
            for (int i = 0; i < numero_cruces; i++)
            {
                while (op)
                {
                    individuo1 = ale.Next(poblacion.Length);
                    individuo2 = ale.Next(poblacion.Length);
                    op = (poblacion[individuo1].Evolved == false) && (poblacion[individuo2].Evolved == false) ? false : true;
                }
                individuo[] cruzados = funcion_cruce(individuo1, individuo2, poblacion.ToArray(), umbral_d, picture, umbral);
                poblacion[individuo1] = cruzados[0];
                poblacion[individuo1].Evolved = true;
                poblacion[individuo2] = cruzados[1];
                poblacion[individuo2].Evolved = true;
            }
            for (int i = 0; i < numero_mutaciones; i++)
            {
                individuo1 = 0;
                op = true;
                while (op)
                {
                    individuo1 = ale.Next(poblacion.Length);
                    op = (poblacion[individuo1].Evolved == false) ? false : true;
                }
                poblacion[individuo1] = funcion_mutar(poblacion[individuo1], poblacion.ToArray(), picture, umbral, umbral_d);
                poblacion[individuo1].Evolved = true;
            }
            return poblacion;
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