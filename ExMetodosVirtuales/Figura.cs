//Participantes del grupo: Thiago Scooby Rebora y Emiliano Shaggy Navarretta

using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        public Pen Lapiz { get; set; }

        public virtual void Dibujar(Graphics g, int posX, int posY){
            //metodo para polimorfismo
        }
    }

    public class Rectangulo : Figura
    {
        protected int altura;
        protected int baseX;

        public Rectangulo(int ancho, int alto)
        {
            this.baseX = ancho;
            this.altura = alto;
        }

        public override void Dibujar(Graphics g, int posX, int posY)
        {
            Pen lapizUsar = this.Lapiz ?? new Pen(Color.Green);

            Point[] vertices = new Point[]
            {
                new Point(posX, posY),
                new Point(posX + baseX, posY),
                new Point(posX + baseX, posY + altura),
                new Point(posX, posY + altura)
            };

            g.DrawPolygon(lapizUsar, vertices);
        }
    }

    public class Cuadrado : Rectangulo
    {
        public Cuadrado(int lado) : base(lado, lado) { }

        public override void Dibujar(Graphics g, int posX, int posY)
        {
            Pen lapizUsar = this.Lapiz ?? new Pen(Color.MediumVioletRed);

            Point[] vertices = new Point[]
            {
                new Point(posX, posY),
                new Point(posX + baseX, posY),
                new Point(posX + baseX, posY + altura),
                new Point(posX, posY + altura),
                new Point(posX, posY) // Cierra el polígono
            };

            g.DrawPolygon(lapizUsar, vertices);
        }
    }

    public class Circulo : Figura
    {
        private int radio;

        public Circulo(int radio)
        {
            this.radio = radio;
        }

        public override void Dibujar(Graphics g, int posX, int posY)
        {
            Pen lapizUsar = this.Lapiz ?? new Pen(Color.Red);

            g.DrawEllipse(lapizUsar, posX, posY, radio, radio);
        }
    }

    public class TrianguloIsosceles : Figura
    {
        protected int lado;
        protected int baseTriangulo;

        public TrianguloIsosceles(int lado, int baseTriangulo)
        {
            this.lado = lado;
            this.baseTriangulo = baseTriangulo;
        }

        public override void Dibujar(Graphics g, int posX, int posY)
        {
            Pen lapizUsar = this.Lapiz ?? new Pen(Color.SteelBlue);

            double altura = Math.Sqrt(Math.Pow(lado, 2) - Math.Pow(baseTriangulo / 2.0, 2));

            Point[] vertices = new Point[]
            {
                new Point(posX, (int)(posY + altura)),
                new Point(posX + baseTriangulo / 2, posY),
                new Point(posX + baseTriangulo, (int)(posY + altura))
            };

            g.DrawPolygon(lapizUsar, vertices);
        }
    }

    public class TrianguloEquilatero : Figura
    {
        protected int lado;

        public TrianguloEquilatero(int lado)
        {
            this.lado = lado;
        }

        public override void Dibujar(Graphics g, int posX, int posY)
        {
            Pen lapizUsar = this.Lapiz ?? new Pen(Color.MintCream);

            double altura = (Math.Sqrt(3) / 2) * lado;

            Point[] vertices = new Point[]
            {
                new Point(posX, (int)(posY + altura)),
                new Point(posX + lado / 2, posY),
                new Point(posX + lado, (int)(posY + altura))
            };

            g.DrawPolygon(lapizUsar, vertices);
        }
    }
}
