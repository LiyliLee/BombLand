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
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                    tr.TranslateX -= 10;
                    
                    break;
                case Windows.System.VirtualKey.Right:
                    tr.TranslateX += 10;
                    break;
                case Windows.System.VirtualKey.Up:
                    break;
                case Windows.System.VirtualKey.Down:
                    break;

            }

            JugadorIdle.RenderTransform = tr;
        }
    }
}
