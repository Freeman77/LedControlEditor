using System;
using System.Collections.Generic;

namespace MatrizLed
{
    public class MatrizLED_8x8
    {
        private List<LED> Matriz8x8;

        public MatrizLED_8x8()
        {
            inicializarMatrizv2();
        }

        private void inicializarMatriz()
        {
            this.Matriz8x8 = new List<LED>();
            string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int valorHorizontal = 1;
            foreach (string letra in letras)
            {
                for (int i = 1; i < 9; i++)
                {
                    this.Matriz8x8.Add(
                        new LED()
                        {
                            ID = String.Concat(letra, i),
                            ValorNumericoVertical = Convert.ToInt32(Math.Pow(2, (i - 1))),
                            ValorNumericoHorizontal = Convert.ToInt32(Math.Pow(2, (valorHorizontal - 1))),
                            Encendido = false
                        });
                }
                valorHorizontal++;
            }
        }

        private void inicializarMatrizv2()
        {
            this.Matriz8x8 = new List<LED>();
            string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H" };
            int valorExponenteHorizontal = 8;
            foreach (string letra in letras)
            {
                for (int i = 1; i < 9; i++)
                {
                    this.Matriz8x8.Add(
                        new LED()
                        {
                            ID = String.Concat(letra, i),
                            ValorNumericoVertical = Convert.ToInt32(Math.Pow(2, (8-i))),
                            ValorNumericoHorizontal = Convert.ToInt32(Math.Pow(2, (valorExponenteHorizontal - 1))),
                            Encendido = false
                        });
                }
                valorExponenteHorizontal--;
            }
        }


        public void cambiarEstadoLED(string led)
        {
            this.Matriz8x8.Find(x => x.ID == led).cambiarEstado();
        }

        public bool obtenerEstado(string led)
        {
            return this.Matriz8x8.Find(x => x.ID == led).Encendido;
        }

        public int calcularColumna(string letraColumna)
        {
            int totalColumna = 0;
            List<LED> columnaLED = this.Matriz8x8.FindAll(x => x.ID.StartsWith(letraColumna));
            foreach (LED led in columnaLED)
            {
                if (led.Encendido)
                {
                    totalColumna += led.ValorNumericoVertical;
                }
            }
            return totalColumna;
        }

        public int calcularFila(string numeroFila) {
            int totalFila = 0;
            List<LED> filaLED = this.Matriz8x8.FindAll(x => x.ID.EndsWith(numeroFila));
            foreach (LED led in filaLED)
            {
                if (led.Encendido)
                {
                    totalFila += led.ValorNumericoHorizontal;
                }
            }
            return totalFila;
        }


        public void llenarMatriz()
        {
            foreach (LED led in Matriz8x8)
            {
                led.Encendido = true;
            }
        }

        public void limpiarMatriz()
        {
            foreach (LED led in Matriz8x8)
            {
                led.Encendido = false;
            }
        }

        public void invertirMatriz()
        {
            foreach (LED led in Matriz8x8) {
                led.cambiarEstado();
            }
        }

    }
}
