using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizadorClimaAutomoviles
{
    class Funciones
    {
        double y;
        double alfa, beta, gamma, delta, phi;
        public string variableLinguistica;

        public Funciones(double alfa, double beta, string variableLinguistica)
        {
            this.alfa = alfa;
            this.beta = beta;
            this.variableLinguistica = variableLinguistica;
        }

        public Funciones(double alfa, double beta, double gamma, string variableLinguistica)
        {
            this.alfa = alfa;
            this.beta = beta;
            this.gamma = gamma;
            this.variableLinguistica = variableLinguistica;
        }
        public Funciones(double alfa, double beta, double delta, double phi, string variableLinguistica)
        {
            this.alfa = alfa;
            this.beta = beta;
            this.delta = delta;
            this.phi = phi;
            this.variableLinguistica = variableLinguistica;
        }

        public double Triangular(double x)
        {
            if (x < alfa)
            {
                y = 0;
            }
            else if (alfa <= x && x < beta)
            {
                y = (x - alfa) / (beta - alfa);
            }
            else if (beta <= x && x < gamma)
            {
                y = (gamma - x) / (gamma - beta);
            }
            else if (x >= gamma)
            {
                y = 0;
            }
            return y;
        }

        public double Saturacion(double x)
        {
            if (x <= alfa)
            {
                y = 0;
            }
            else if (alfa <= x && x <= beta)
            {
                y = (x - alfa) / (beta - alfa);
            }
            else if (x >= beta)
            {
                y = 1;
            }
            return y;
        }

        public double Hombro(double x)
        {
            if (x <= alfa)
            {
                y = 1;
            }
            else if (alfa <= x && x <= beta)
            {
                y = (x - beta) / (alfa - beta);
            }
            else if (x <= beta)
            {
                y = 0;
            }
            else
            {
                y = 0;
            }
            return y;
        }

        public double PI(double x)
        {
            if (alfa <= x && x < beta)
            {
                y = (x - alfa) / (beta - alfa);
            }
            else if (beta <= x && x < delta)
            {
                y = 1;
            }
            else if (delta <= x && x < phi)
            {
                y = (x - phi) / (delta - phi);
            }
            else
            {
                y = 0;
            }
            return y;
        }

        public double TriangularInversa(double x)
        {
            if (x < alfa)
            {
                y = 1;
            }
            else if (alfa <= x && x < beta)
            {
                y = 1 - (x - alfa) / (beta - alfa);
            }
            else if (beta <= x && x < gamma)
            {
                y = 1 - (gamma - x) / (gamma - beta);
            }
            else if (x >= gamma)
            {
                y = 1;
            }
            return y;
        }
    }
}
