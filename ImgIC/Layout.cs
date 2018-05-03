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
        individuo Ind = new individuo();
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
                    picture = new IMG(ImagenInicial.Image.Size.Width, ImagenInicial.Image.Size.Height, ImagenInicial.Image);
                    Salida.Items.Add("Imagen cargada ");
                    Salida.Items.Add(ImagenInicial.Image.Size.Width + " --- " + ImagenInicial.Image.Width);
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
            picture = new IMG(ImagenInicial.Image.Size.Width, ImagenInicial.Image.Size.Height, ImagenInicial.Image);
            arraypoblation = pb.CrearPoblacion(picture.getW(), picture.getH(), int.Parse(numInd.Text), int.Parse(Umbral.Text), picture.getImg());
            Poblacion ctlPoblation = new Poblacion(); // 
            ctlPoblation.Generacion = 0;
            Salida.Items.Add("Población inicial generada");
            Salida.Refresh();
            MostrarPoblacion(arraypoblation);
            Salida.Items.Add("Graficación de la población inicial");
            Salida.Refresh();//promedio o calidad poblacional
            ctlPoblation.Derivada[ctlPoblation.Generacion] = pb.Promedio(arraypoblation);
            Salida.Items.Add("Calidad población inicial: " + ctlPoblation.Derivada[ctlPoblation.Generacion].ToString());
            Salida.Refresh();
            int derivada = ctlPoblation.calculo_derivada(ctlPoblation.Derivada, ctlPoblation.Derivada[ctlPoblation.Generacion]), cont = 0;
            Salida.Items.Add("Derivada : " + derivada);
            while (derivada == 0)
            {
                arraypoblation = pb.Crear_generacion(arraypoblation,
                  (float)Convert.ToSingle(Cruce.Text.Replace('.', ',')),
                   (float)Convert.ToSingle(Mutacion.Text.Replace('.', ',')),
                   int.Parse(Umbral_d.Text),
                   picture.getImg(),
                   int.Parse(Umbral.Text));
                ctlPoblation.Generacion++;
                cont++;
                Salida.Items.Add("Generación: " + cont);
                Salida.Refresh();
                if (ctlPoblation.Generacion == 10)
                {
                    ctlPoblation.Generacion = 0;
                }
                ctlPoblation.Derivada[ctlPoblation.Generacion] = pb.Promedio(arraypoblation);
                Salida.Items.Add("Calidad de la población: " + ctlPoblation.Derivada[ctlPoblation.Generacion].ToString());
                Salida.Refresh();
                derivada = ctlPoblation.calculo_derivada(ctlPoblation.Derivada, ctlPoblation.Derivada[ctlPoblation.Generacion]);
            }
            Salida.Items.Add("Proceso terminado");
            Salida.Refresh();
        }

        private void cleanImg_Click(object sender, EventArgs e)
        {

        }

        private void CleanOut_Click(object sender, EventArgs e)
        {
            Salida.ClearSelected();
        }

        private void MostrarPoblacion(individuo[] poblacion)
        {
            this.ImagenFinal.SizeMode = PictureBoxSizeMode.StretchImage;
            ImagenFinal.Image = ImagenInicial.Image;
            for (int i = 0; i < poblacion.Length; i++)
            {
                ImagenFinal.Image = picture.ubicar_puntos(poblacion[i].X, poblacion[i].Y, ImagenFinal.Image);
            }
            this.ImagenFinal.Refresh();
        }

    }
}
