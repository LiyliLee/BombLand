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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BombLand
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;

        public MainPage()
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

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Armeria));
        }

        private void creditsb_Click(object sender, RoutedEventArgs e)
        {
            PanelCredits.Visibility = Visibility.Visible;
            PanelInicio.Visibility = Visibility.Collapsed;
        }
        private void CloseCredits_Click(object sender, RoutedEventArgs e)
        {
            PanelCredits.Visibility = Visibility.Collapsed;
            PanelInicio.Visibility = Visibility.Visible;
        }

        private void accountb_Click(object sender, RoutedEventArgs e)
        {
            PanelCuentas.Visibility = Visibility.Visible;
            PanelInicio.Visibility = Visibility.Collapsed;
        }

        private void EnterGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPrincipal));
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            PanelCuentas.Visibility = Visibility.Collapsed;
            PanelInicio.Visibility = Visibility.Visible;
        }


    }
}
