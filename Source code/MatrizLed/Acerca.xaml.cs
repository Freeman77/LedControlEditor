using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace MatrizLed
{
    /// <summary>
    /// Lógica de interacción para Acerca.xaml
    /// </summary>
    public partial class Acerca : Window
    {
        public Acerca()
        {
            InitializeComponent();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
