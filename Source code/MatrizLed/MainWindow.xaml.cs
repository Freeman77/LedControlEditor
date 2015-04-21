using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatrizLed
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Style RedLED;
        private Style GrayLED;
        private MatrizLED_8x8 ObjetoMatriz;
        private int[] calculoColumna;
        private int[] calculoFila;

        public MainWindow()
        {
            InitializeComponent();
            this.RedLED = (Style)this.FindResource("RedLED");
            this.GrayLED = (Style)this.FindResource("GrayLED");
            this.ObjetoMatriz = new MatrizLED_8x8();
            this.calculoColumna = new int[8];
            this.calculoFila = new int[8];
        }

        private void LED_Button_Click(object sender, RoutedEventArgs e)
        {
            string led = ((Button)sender).Name;
            this.ObjetoMatriz.cambiarEstadoLED(led);
            if (this.ObjetoMatriz.obtenerEstado(led))
            {
                ((Button)sender).Style = RedLED;
            }
            else
            {
                ((Button)sender).Style = GrayLED;
            }
            actualizarTotalColumna((led.Substring(0, 1)).ToString());
            actualizarTotalFila((led.Substring(1, 1)).ToString());
        }

        private void actualizarTotalColumna(string letraColumna)
        {
            switch (letraColumna)
            {
                case "A":
                    calculoColumna[0] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalA.Content = calculoColumna[0];
                    break;
                case "B":
                    calculoColumna[1] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalB.Content = calculoColumna[1];
                    break;
                case "C":
                    calculoColumna[2] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalC.Content = calculoColumna[2];
                    break;
                case "D":
                    calculoColumna[3] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalD.Content = calculoColumna[3];
                    break;
                case "E":
                    calculoColumna[4] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalE.Content = calculoColumna[4];
                    break;
                case "F":
                    calculoColumna[5] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalF.Content = calculoColumna[5];
                    break;
                case "G":
                    calculoColumna[6] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalG.Content = calculoColumna[6];
                    break;
                case "H":
                    calculoColumna[7] = this.ObjetoMatriz.calcularColumna(letraColumna);
                    this.lblTotalH.Content = calculoColumna[7];
                    break;
            }

        }

        private void actualizarTotalFila(string numeroFila)
        {
            switch (numeroFila)
            {
                case "1":
                    calculoFila[0] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal1.Content = calculoFila[0];
                    break;
                case "2":
                    calculoFila[1] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal2.Content = calculoFila[1];
                    break;
                case "3":
                    calculoFila[2] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal3.Content = calculoFila[2];
                    break;
                case "4":
                    calculoFila[3] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal4.Content = calculoFila[3];
                    break;
                case "5":
                    calculoFila[4] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal5.Content = calculoFila[4];
                    break;
                case "6":
                    calculoFila[5] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal6.Content = calculoFila[5];
                    break;
                case "7":
                    calculoFila[6] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal7.Content = calculoFila[6];
                    break;
                case "8":
                    calculoFila[7] = this.ObjetoMatriz.calcularFila(numeroFila);
                    this.lblTotal8.Content = calculoFila[7];
                    break;
            }

        }

        private void btnLimpiarMatriz_Click(object sender, RoutedEventArgs e)
        {
            this.ObjetoMatriz.limpiarMatriz();
            for (int i = 0; i < 8; i++)
            {
                this.calculoColumna[i] = 0;
                this.calculoFila[i] = 0;
            }
            foreach (Button led in gridMatriz.Children.OfType<Button>())
            {
                led.Style = GrayLED;
            }
            foreach (Label lbl in gridMatriz.Children.OfType<Label>())
            {
                lbl.Content = 0;
            }
        }

        private void btnLlenarMatriz_Click(object sender, RoutedEventArgs e)
        {
            this.ObjetoMatriz.llenarMatriz();
            for (int i = 0; i < 8; i++)
            {
                this.calculoColumna[i] = 255;
                this.calculoFila[i] = 255;
            }
            foreach (Button led in gridMatriz.Children.OfType<Button>())
            {
                led.Style = RedLED;
            }
            foreach (Label lbl in gridMatriz.Children.OfType<Label>())
            {
                lbl.Content = 255;
            }
        }

        private void btnInvertirMatriz_Click(object sender, RoutedEventArgs e)
        {
            this.ObjetoMatriz.invertirMatriz();
            foreach (Button led in gridMatriz.Children.OfType<Button>())
            {
                if (this.ObjetoMatriz.obtenerEstado(led.Name))
                {
                    led.Style = RedLED;
                }
                else
                {
                    led.Style = GrayLED;
                }
                actualizarTotalColumna((led.Name.Substring(0, 1)).ToString());
                actualizarTotalFila((led.Name.Substring(1, 1)).ToString());
            }
        }

        private void btnGenerarCodigo_Click(object sender, RoutedEventArgs e)
        {
            //Columnas
            this.txtCalculoColumnas.Text = string.Format("{{{0},{1},{2},{3},{4},{5},{6},{7}}}",
                this.calculoColumna[0],
                this.calculoColumna[1],
                this.calculoColumna[2],
                this.calculoColumna[3],
                this.calculoColumna[4],
                this.calculoColumna[5],
                this.calculoColumna[6],
                this.calculoColumna[7]);
            //Filas
            this.txtCalculoFilas.Text = string.Format("{{{0},{1},{2},{3},{4},{5},{6},{7}}}",
                this.calculoFila[0],
                this.calculoFila[1],
                this.calculoFila[2],
                this.calculoFila[3],
                this.calculoFila[4],
                this.calculoFila[5],
                this.calculoFila[6],
                this.calculoFila[7]);
        }

        private void MenuItem_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Acerca_Click(object sender, RoutedEventArgs e)
        {
            Acerca dialogBox = new Acerca();
            dialogBox.Owner = this;
            Nullable<bool> dialogResult = dialogBox.ShowDialog();
        }

        

        

    }
}
