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
    public sealed partial class Juego : Page
    {
        public Juego()
        {
            this.InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            CompositeTransform tr = JugadorIdle.RenderTransform as CompositeTransform;
            CompositeTransform trW = JugadorArma.RenderTransform as CompositeTransform;
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.GamepadDPadLeft:
                    tr.TranslateX -= 10;
                    trW.TranslateX -= 10;
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.GamepadDPadRight:
                    tr.TranslateX += 10;
                    trW.TranslateX += 10;
                    break;
                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.GamepadDPadUp:
                    trW.Rotation += 5;
                    break;
                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.GamepadDPadDown:
                    trW.Rotation -= 5;
                    break;

            }

            JugadorIdle.RenderTransform = tr;
            JugadorArma.RenderTransform = trW;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPrincipal));
        }
    }
}
