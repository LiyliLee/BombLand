using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace BombLand
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Armeria : Page
    {
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;
        private GamepadReading reading, prereading;
        private GamepadVibration vibration;

        public int seleccionado = -1;
        public Armeria()
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

        public ObservableCollection<VMArma> ListaArmas {
            get;
        } = new ObservableCollection<VMArma>();

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            if (ListaArmas != null) //Carga la lista de ModelView
                foreach (Arma arma in Model.GetAllArmas()) {
                    VMArma VMitem = new VMArma(arma);
                    ListaArmas.Add(VMitem);
                }

            base.OnNavigatedTo(e);
        }


        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {
            
            BitmapImage b = new BitmapImage();
            Arma g = e.ClickedItem as Arma;
            b.UriSource = new Uri(ArmaFocus.BaseUri, g.ImgFocus);
            ArmaFocus.Source = b;

            seleccionado = g.Id;
            
            ListaArmas.Clear();
            foreach (Arma arma in Model.GetAllArmas()) {
                VMArma VMitem = new VMArma(arma);
                if (VMitem.Id == seleccionado) {
                    VMitem.ImgDisplay = VMitem.ImgEquipada;
                }
                ListaArmas.Add(VMitem);
            }

        }    

        private void ArmeriaVolver_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MenuPrincipal));
        }

    }
}
