using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomatizadorClimaAutomoviles
{
    public partial class Automatizador : Form
    {
        double y = 0;
        private int valor;

        public Automatizador()
        {
            InitializeComponent();

            #region Matriz de Reglas Difusas
            FAMTemperatura[,] famTemperatura = new FAMTemperatura[3, 5];

            famTemperatura[0, 0].Resistencias = "Encendidas";
            famTemperatura[0, 0].Ventilador = "Apagado";

            #endregion

            sbTemperatura.Minimum = 0;
            sbTemperatura.Maximum = 39;
            sbIntensidadSolar.Minimum = 0;
            sbIntensidadSolar.Maximum = 12009;
            sbParteDia.Minimum = 0;
            sbParteDia.Maximum = 29;
        }

        private void btnTemperatura_Click(object sender, EventArgs e)
        {
            Funciones calcular = new Funciones(5, 10, "");
            Funciones calcular1 = new Funciones(25, 30, "");
            Funciones calcular2 = new Funciones(5, 10, 20, "");
            Funciones calcular3 = new Funciones(12, 20, 24, "");
            Funciones calcular4 = new Funciones(20, 24, 39, "");

            for (double x = 0; x <= 50; x++)
            {
                y = calcular.Hombro(x);
                grafica1.Series[0].Points.AddXY(x, y);

                y = calcular1.Saturacion(x);
                grafica1.Series[4].Points.AddXY(x, y);

                y = calcular2.Triangular(x);
                grafica1.Series[1].Points.AddXY(x, y);

                y = calcular3.Triangular(x);
                grafica1.Series[2].Points.AddXY(x, y);

                y = calcular4.Triangular(x);
                grafica1.Series[3].Points.AddXY(x, y);
            }

        }

        private void sbTemperatura_Scroll(object sender, ScrollEventArgs e)
        {
            double[] y = new double[5];
            valor = sbTemperatura.Value;

            Funciones[] calcular = new Funciones[5];
            calcular[0] = new Funciones(5, 10, "Muy frío");
            y[0] = calcular[0].Hombro(valor);

            calcular[1] = new Funciones(25, 30, "Frío");
            y[1] = calcular[1].Saturacion(valor);

            calcular[2] = new Funciones(5, 10, 20, "Normal");
            y[2] = calcular[2].Triangular(valor);

            calcular[3] = new Funciones(12, 20, 24, "Caliente");
            y[3] = calcular[3].Triangular(valor);

            calcular[4] = new Funciones(20, 24, 39, "Muy caliente");
            y[4] = calcular[4].Triangular(valor);

            double yMax = y.Max();
            int indiceMax = 0;
            for (int i = 0; i <= 4; i++)
            {
                if (y[i] == yMax)
                {
                    indiceMax = i;
                }
            }
            lblTemperatura.Text = calcular[indiceMax].variableLinguistica;
        }

        private void btnIntensidadSolar_Click(object sender, EventArgs e)
        {
            Funciones calcular5 = new Funciones(0, 2000, 3995, "");
            Funciones calcular6 = new Funciones(2000, 4000, 6000, "");
            Funciones calcular7 = new Funciones(4000, 6000, 8000, "");
            Funciones calcular8 = new Funciones(6000, 8000, "");

            for (double x = 0; x <= 12000; x++)
            {
                y = calcular5.Triangular(x);
                grafica2.Series[0].Points.AddXY(x, y);

                y = calcular6.Triangular(x);
                grafica2.Series[1].Points.AddXY(x, y);

                y = calcular7.Triangular(x);
                grafica2.Series[2].Points.AddXY(x, y);

                y = calcular8.Saturacion(x);
                grafica2.Series[3].Points.AddXY(x, y);
            }
        }

        private void sbIntensidadSolar_Scroll(object sender, ScrollEventArgs e)
        {
            double[] y = new double[4];
            valor = sbIntensidadSolar.Value;

            Funciones[] calculo = new Funciones[4];

            calculo[0] = new Funciones(0, 2000, 3995, "Muy poca");
            y[0] = calculo[0].Triangular(valor);

            calculo[1] = new Funciones(2000, 4000, 6000, "Poca");
            y[1] = calculo[1].Triangular(valor);

            calculo[2] = new Funciones(4000, 6000, 8000, "Normal");
            y[2] = calculo[2].Triangular(valor);

            calculo[3] = new Funciones(6000, 8000, "Mucha");
            y[3] = calculo[3].Saturacion(valor);

            double yMax = y.Max();
            int indiceMax = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (y[i] == yMax)
                {
                    indiceMax = i;
                }
            }
            lblIntensidadSolar.Text = calculo[indiceMax].variableLinguistica;
        }

        private void btnVentanas_Click(object sender, EventArgs e)
        {
            Funciones calcular9 = new Funciones(0.1, 0, "");
            Funciones calcular10 = new Funciones(2.4, 2.5, 2.6, "");
            Funciones calcular11 = new Funciones(4.9, 1, "");

            for (double x = 0; x < 5; x += 0.1)
            {
                y = calcular9.Hombro(x);
                grafica3.Series[0].Points.AddXY(x, y);

                y = calcular10.Triangular(x);
                grafica3.Series[1].Points.AddXY(x, y);

                y = calcular11.Saturacion(x);
                grafica3.Series[2].Points.AddXY(x, y);
            }
        }

        private void sbVentanas_Scroll(object sender, ScrollEventArgs e)
        {
            double[] y = new double[3];
            valor = sbVentanas.Value;

            Funciones[] calculo = new Funciones[3];

            calculo[0] = new Funciones(0.1, 0, "CIERRA");
            y[0] = calculo[0].Hombro(valor);

            calculo[1] = new Funciones(2.4, 2.5, 2.6, "MEDIO");
            y[1] = calculo[1].Triangular(valor);

            calculo[2] = new Funciones(4.9, 1, "ABRE");
            y[2] = calculo[2].Saturacion(valor);

            double yMax = y.Max();
            int indiceMax = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (y[i] == yMax)
                {
                    indiceMax = i;
                }
            }
            lblVentatas.Text = calculo[indiceMax].variableLinguistica;
        }

        private void btnVentilador_Click(object sender, EventArgs e)
        {
            Funciones calcular12 = new Funciones(0.1, 0, "");
            Funciones calcular13 = new Funciones(2.4, 2.5, 2.6, "");
            Funciones calcular14 = new Funciones(4.9, 1, "");

            for (double x = 0; x < 5; x += 0.1)
            {
                y = calcular12.Hombro(x);
                grafica4.Series[0].Points.AddXY(x, y);

                y = calcular13.Triangular(x);
                grafica4.Series[1].Points.AddXY(x, y);

                y = calcular14.Saturacion(x);
                grafica4.Series[2].Points.AddXY(x, y);
            }
        }

        private void sbVentilador_Scroll(object sender, ScrollEventArgs e)
        {
            double[] y = new double[3];
            valor = sbVentilador.Value;

            Funciones[] calculo = new Funciones[3];

            calculo[0] = new Funciones(0.1, 0, "Apagado");
            y[0] = calculo[0].Hombro(valor);

            calculo[1] = new Funciones(2.4, 2.5, 2.6, "Medio");
            y[1] = calculo[1].Triangular(valor);

            calculo[2] = new Funciones(3.9, 1, "Encendido");
            y[2] = calculo[2].Saturacion(valor);

            double yMax = y.Max();
            int indiceMax = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (y[i] == yMax)
                {
                    indiceMax = i;
                }
            }
            lblVentilador.Text = calculo[indiceMax].variableLinguistica;
        }

        private void btnParteDia_Click(object sender, EventArgs e)
        {
            Funciones calcular1 = new Funciones(3, 7, "");
            Funciones calcular2 = new Funciones(6, 12, 18, "");
            Funciones calcular3 = new Funciones(15, 18, "");

            for (double x = 0; x < 20; x++)
            {
                y = calcular1.Hombro(x);
                grafica5.Series[0].Points.AddXY(x, y);

                y = calcular2.Triangular(x);
                grafica5.Series[1].Points.AddXY(x, y);

                y = calcular3.Saturacion(x);
                grafica5.Series[2].Points.AddXY(x, y);

            }
        }

        private void sbParteDia_Scroll(object sender, ScrollEventArgs e)
        {
            double[] y = new double[3];
            valor = sbParteDia.Value;

            Funciones[] calculo = new Funciones[3];

            calculo[0] = new Funciones(3, 7, "Mañana");
            y[0] = calculo[0].Hombro(valor);

            calculo[1] = new Funciones(6, 12, 18, "Día");
            y[1] = calculo[1].Triangular(valor);

            calculo[2] = new Funciones(15, 18, "Noche");
            y[2] = calculo[2].Saturacion(valor);

            double yMax = y.Max();
            int indiceMax = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (y[i] == yMax)
                {
                    indiceMax = i;
                }
            }
            lblParteDia.Text = calculo[indiceMax].variableLinguistica;
        }

        private void btnResistencias_Click(object sender, EventArgs e)
        {
            Funciones calcular1 = new Funciones(0.1, 0, "");
            Funciones calcular2 = new Funciones(2.4, 2.5, 2.6, "");
            Funciones calcular3 = new Funciones(4.9, 1, "");

            for (double x = 0; x < 5; x += 0.1)
            {
                y = calcular1.Hombro(x);
                grafica6.Series[0].Points.AddXY(x, y);

                y = calcular2.Triangular(x);
                grafica6.Series[1].Points.AddXY(x, y);

                y = calcular3.Saturacion(x);
                grafica6.Series[2].Points.AddXY(x, y);
            }
        }

        private void sbResistencias_Scroll(object sender, ScrollEventArgs e)
        {
            double[] y = new double[3];
            valor = sbResistencias.Value;

            Funciones[] calculo = new Funciones[3];

            calculo[0] = new Funciones(0.1, 0, "Apagadas");
            y[0] = calculo[0].Hombro(valor);

            calculo[1] = new Funciones(2.4, 2.5, 2.6, "Medio");
            y[1] = calculo[1].Triangular(valor);

            calculo[2] = new Funciones(3.9, 1, "Encendidas");
            y[2] = calculo[2].Saturacion(valor);

            double yMax = y.Max();
            int indiceMax = 0;
            for (int i = 0; i <= 2; i++)
            {
                if (y[i] == yMax)
                {
                    indiceMax = i;
                }
            }
            lblResistencias.Text = calculo[indiceMax].variableLinguistica;
        }
    }
}
