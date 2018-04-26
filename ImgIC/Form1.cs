using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImgIC
{
    public partial class Form1 : Form
    {
        IMG piture;
        Poblacion pp = new Poblacion();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string img = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(img);
                    Salida1.Items.Add("Imagen cargada ");
                    piture = new IMG(pictureBox1.Image.Width, pictureBox1.Image.Height, pictureBox1.Image);
                    pictureBox2.Image = piture.gray();
                    Salida1.Items.Add("Imagen EN escala de Grises ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String temp = Salida1.Text;
            Salida1.Text = "";
            Salida1.Items.Add(temp);
            Salida1.Items.Add("Binarizando Imagen");
            var val = "";
            richTextBox1.Text = "";
            int[,] ma = piture.getmatriz();
            int I = piture.geti(), J = piture.getj();
            for (int i = 0; i < J; i++)
            {
                for (int j = 0; j < I; j++)
                {
                    val += ma[j, i] + "";
                }
                richTextBox1.Text = richTextBox1.Text + val + "\n";
                val = "";
            }
            pp.CrearPoblacion(piture.geti(), piture.getj(),100, ma,Salida1);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void graficar_puntos(individuo[] poblacion)
        {
            IMG up = new IMG(pictureBox1.Image);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = pictureBox1.Image;
            for (int i = 0; i < poblacion.Length; i++)
            {
                pictureBox2.Image = up.ubicar_puntos(poblacion[i].X, poblacion[i].Y, pictureBox2.Image);
            }
            this.pictureBox2.Refresh();
        }

    }
}
