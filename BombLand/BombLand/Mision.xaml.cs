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
    public sealed partial class Mision : Page
    {
        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad = null;

        public ObservableCollection<VMTareaMision> ListaTareaMision  { get; set; } = new ObservableCollection<VMTareaMision>();
        public ObservableCollection<VMTareaGrowing> ListaTareaGrowing  { get; set; } = new ObservableCollection<VMTareaGrowing>();
        public Mision()
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
            if (ListaTareaMision != null) //Carga la lista de ModelView
            {
                foreach (TareaMision mis in Model2.GetAllMisiones())
                {
                    VMTareaMision VMitem = new VMTareaMision(mis);

                    if (VMitem.Estado == TareaMision.estados.NoTerminado)
                    {
                        VMitem.TerminadoImagen = VMitem.Vacio;
                        VMitem.RecogidoImagen = VMitem.Vacio;
                    }
                    else if (VMitem.Estado == TareaMision.estados.Terminado)
                    {
                        VMitem.TerminadoImagen = VMitem.ImgTerminado;
                        VMitem.RecogidoImagen = VMitem.Vacio;
                    }
                    else if (VMitem.Estado == TareaMision.estados.Recogido)
                    {
                        VMitem.TerminadoImagen = VMitem.ImgTerminado;
                        VMitem.RecogidoImagen = VMitem.ImgRecogido;
                    }
                    ListaTareaMision.Add(VMitem);
                }
            }
            if (ListaTareaGrowing != null) //Carga la lista de ModelView
            {
                foreach (TareaGrowing mis in Model2.GetAllGrowing())
                {
                    VMTareaGrowing VMitem = new VMTareaGrowing(mis);
                    if (VMitem.Estado == TareaGrowing.estados.NoTerminado)
                    {
                        VMitem.TerminadoImagen = VMitem.Vacio;
                        VMitem.RecogidoImagen = VMitem.Vacio;
                    }
                    else if (VMitem.Estado == TareaGrowing.estados.Terminado)
                    {
                        VMitem.TerminadoImagen = VMitem.ImgTerminado;
                        VMitem.RecogidoImagen = VMitem.Vacio;
                    }
                    else if (VMitem.Estado == TareaGrowing.estados.Recogido)
                    {
                        VMitem.TerminadoImagen = VMitem.ImgTerminado;
                        VMitem.RecogidoImagen = VMitem.ImgRecogido;
                    }

                    ListaTareaGrowing.Add(VMitem);
                }
            }
            base.OnNavigatedTo(e);
        }
        private void MisionVolver_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MenuPrincipal),Diamonds.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button m = e.OriginalSource as Button;
            VMTareaMision VMitem = m.DataContext as VMTareaMision;
 
            
            if (VMitem.Estado == TareaMision.estados.Terminado)
            {
                
                VMTareaMision item = new VMTareaMision(Model2.GetAllMisiones()[VMitem.Id]);
                item.RecogidoImagen = item.ImgRecogido;
                ListaTareaMision[VMitem.Id] = item;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button m = e.OriginalSource as Button;
            VMTareaGrowing VMitem = m.DataContext as VMTareaGrowing;


            if (VMitem.Estado == TareaGrowing.estados.Terminado)
            {

                VMTareaGrowing item = new VMTareaGrowing(Model2.GetAllGrowing()[VMitem.Id]);
                item.RecogidoImagen = item.ImgRecogido;
                item.Estado = TareaGrowing.estados.Recogido;
                ListaTareaGrowing[VMitem.Id] = item;
                int total = Int32.Parse(Diamonds.Text) + 5;
                Diamonds.Text = total.ToString();
            }
        }

        private void Misionb_Click(object sender, RoutedEventArgs e)
        {
            MisionList.Visibility = Visibility.Visible;
            GrowingList.Visibility = Visibility.Collapsed;
        }

        private void Growingb_Click(object sender, RoutedEventArgs e)
        {
            MisionList.Visibility = Visibility.Collapsed;
            GrowingList.Visibility = Visibility.Visible;
        }
    }
}
