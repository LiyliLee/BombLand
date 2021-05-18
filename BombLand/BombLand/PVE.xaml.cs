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
    public sealed partial class PVE : Page
    {
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;

        public PVE()
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


        private void lv1_Click(object sender, RoutedEventArgs e)
        {
            Retos.Visibility = Visibility.Visible;
        }

        private void lv2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Juego));
        }

        private void PVEVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPrincipal));

        }

        private void recog1_Click(object sender, RoutedEventArgs e)
        {
            recog11.Visibility = Visibility.Visible;
            recog12.Visibility = Visibility.Visible;
        }

        private void recog0_Click(object sender, RoutedEventArgs e)
        {
            recog01.Visibility = Visibility.Visible;
            recog02.Visibility = Visibility.Visible;
        }

        private void closeLv1_Click(object sender, RoutedEventArgs e)
        {
            Retos.Visibility = Visibility.Collapsed;
        }

 
    }
}
