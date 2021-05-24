using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.Input;
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
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;

        public MenuPrincipal()
        {
            this.InitializeComponent();

            Gamepad.GamepadAdded += (object sender, Gamepad e) => {
                // Check if the just-added gamepad is already in myGamepads; if it isn't, add
                // it.
                lock (myLock) {
                    bool gamepadInList = myGamepads.Contains(e);
                    if (!gamepadInList) {
                        myGamepads.Add(e);
                    }
                }
            };

            Gamepad.GamepadRemoved += (object sender, Gamepad e) => {
                lock (myLock) {
                    int indexRemoved = myGamepads.IndexOf(e);
                    if (indexRemoved > -1) {
                        if (mainGamepad == myGamepads[indexRemoved]) {
                            mainGamepad = null;
                        }
                        myGamepads.RemoveAt(indexRemoved);
                    }
                }
            };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.Parameter is string &&
                !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                Diamonds.Text = e.Parameter.ToString();
            }
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
