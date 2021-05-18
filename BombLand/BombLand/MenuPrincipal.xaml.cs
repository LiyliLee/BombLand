using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace BombLand
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MenuPrincipal : Page
    {
        public MenuPrincipal()
        {
            this.InitializeComponent();
        }

        private void closeMP_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Tienda));
        }

        private void task_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Mision));
        }

        private void forge_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Armeria));
        }

        private void character_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Perfil));
        }

        private void PVPMode_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PVP));
        }

        private void PVEMode_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PVE));
        }

        private void CloseProfile_Click(object sender, RoutedEventArgs e)
        {
            if (NombreCambiado.Text!="")
            {
                NombreUsuario.Text = NombreCambiado.Text;
            }
            PanelPerfil.Visibility = Visibility.Collapsed;
            PanelBotones.Visibility = Visibility.Visible;
            PlayModePanel.Visibility = Visibility.Visible;
            configClose.Visibility = Visibility.Visible;
        }

        private void ImageUsuario_Click(object sender, RoutedEventArgs e)
        {

            PanelPerfil.Visibility = Visibility.Visible;
            PanelBotones.Visibility = Visibility.Collapsed;
            PlayModePanel.Visibility = Visibility.Collapsed;
            configClose.Visibility = Visibility.Collapsed;

        }
    }
}
