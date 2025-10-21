using System;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        // Array que almacenará todas las figuras a dibujar
        private Figura[] coleccionFiguras;

        public Form1()
        {
            InitializeComponent();

            // Crear generador de números aleatorios para colores
            Random rnd = new Random();

            // Generar colores aleatorios para cada figura
            Color col1 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Color col2 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Color col3 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Color col4 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Color col5 = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            // Crear lápices con grosor 2 para cada figura
            Pen lapiz1 = new Pen(col1, 2);
            Pen lapiz2 = new Pen(col2, 2);
            Pen lapiz3 = new Pen(col3, 2);
            Pen lapiz4 = new Pen(col4, 2);
            Pen lapiz5 = new Pen(col5, 2);

            // Inicializar todas las figuras con sus respectivos lápices
            coleccionFiguras = new Figura[]
            {
                new Circulo(20) { Lapiz = lapiz1 },
                new Rectangulo(60, 90) { Lapiz = lapiz2 },
                new Cuadrado(100) { Lapiz = lapiz3 },
                new TrianguloEquilatero(80) { Lapiz = lapiz5 },
                new TrianguloIsosceles(90, 100) { Lapiz = lapiz4 }
            };
        }

        // Evento que se dispara al presionar el botón de dibujar
        private void btnDibujar_Click(object sender, EventArgs e)
        {
            // Obtener objeto Graphics del PictureBox
            Graphics lienzo = pictureBox1.CreateGraphics();

            // Dibujar cada figura, separadas horizontalmente
            for (int i = 0; i < coleccionFiguras.Length; i++)
            {
                coleccionFiguras[i].Dibujar(lienzo, i * 100, 50);
            }
        }
    }
}
