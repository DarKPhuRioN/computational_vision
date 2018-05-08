using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgIC
{
    public partial class Layout : Form
    {
        private IMG picture;
        private individuo[] arraypoblation;
        private Poblacion pb = new Poblacion();
        private individuo Ind = new individuo();

        public Layout()
        {
            InitializeComponent();
        }

        private void Examinar_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagendecarga.ShowDialog() == DialogResult.OK)
                {
                    string img = imagendecarga.FileName;
                    ImagenInicial.Image = Image.FromFile(img);
                    picture = new IMG(ImagenInicial.Image.Width, ImagenInicial.Image.Height, ImagenInicial.Image);
                    Salida.Items.Add("Imagen cargada ");
                    IniciarAE.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.ToString());
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void IniciarAE_Click(object sender, EventArgs e)
        {
            CleanOut.Enabled = true;
            arraypoblation = pb.CrearPoblacion(picture.getW(), picture.getH(), int.Parse(numInd.Text), int.Parse(Umbral.Text), picture);
            Poblacion ctlPoblation = new Poblacion(); // 
            ctlPoblation.Generation = 0;
            Salida.Items.Add("Población inicial generada");
            Salida.Refresh();
            PrintPoblation(arraypoblation);
            Salida.Items.Add("Graficación de la población inicial");
            Salida.Refresh();//promedio o calidad poblacional
            ctlPoblation.Derivative[ctlPoblation.Generation] = pb.Average(arraypoblation);
            Salida.Items.Add("Calidad población inicial: " + ctlPoblation.Derivative[ctlPoblation.Generation].ToString());
            Salida.Refresh();
            int derivada = ctlPoblation.derivate_calculation(ctlPoblation.Derivative, ctlPoblation.Derivative[ctlPoblation.Generation]), cont = 0;
            Salida.Items.Add("Derivada : " + derivada);
            while (derivada == 0)
            {
                arraypoblation = pb.Create_Generation(arraypoblation,
                  (float)Convert.ToSingle(Cruce.Text.Replace('.', ',')),
                   int.Parse(Umbral_d.Text),
                   picture,
                   int.Parse(Umbral.Text));
                arraypoblation = pb.UpdateState(arraypoblation);
                ctlPoblation.Generation++;
                cont++;
                Salida.Items.Add("Generación: " + cont);
                Salida.Refresh();
                if (ctlPoblation.Generation == 10)
                {
                    ctlPoblation.Generation = 0;
                }
                ctlPoblation.Derivative[ctlPoblation.Generation] = pb.Average(arraypoblation);
                Salida.Items.Add("Calidad de la población: " + ctlPoblation.Derivative[ctlPoblation.Generation].ToString());
                Salida.Refresh();
                derivada = ctlPoblation.derivate_calculation(ctlPoblation.Derivative, ctlPoblation.Derivative[ctlPoblation.Generation]);
            }
            Salida.Items.Add("Derivada : " + derivada);
            Salida.Items.Add("Proceso terminado");
            Salida.Refresh();
            //MostrarPoblacion(arraypoblation);
        }

        private void cleanImg_Click(object sender, EventArgs e)
        {
        }

        private void CleanOut_Click(object sender, EventArgs e)
        {
            Salida.ClearSelected();
        }

        private void PrintPoblation(individuo[] poblacion)
        {
            ImagenFinal.Image = ImagenInicial.Image;
            for (int i = 0; i < poblacion.Length; i++)
            {
                ImagenFinal.Image = picture.locate_points(poblacion[i].X, poblacion[i].Y, ImagenFinal.Image);
            }
            this.ImagenFinal.Refresh();
        }
    }
}