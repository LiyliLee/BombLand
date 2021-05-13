using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace BombLand
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Perfil : Page
    {
        public Perfil()
        {
            this.InitializeComponent();
        }
        public ObservableCollection<VMPrenda> ListaPrendas {
            get;
        } = new ObservableCollection<VMPrenda>();

        protected override void OnNavigatedTo(NavigationEventArgs e) {

            if (ListaPrendas != null) //Carga la lista de ModelView
                foreach (Prenda prenda in Model.GetAllPrendas()) {
                    VMPrenda VMitem = new VMPrenda(prenda);
                    ListaPrendas.Add(VMitem);
                }

            base.OnNavigatedTo(e);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e) {

        }

        private void PerfilVolver_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MenuPrincipal));
        }

        //dimensiones originales de la imagen de personaje: 568x698
        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if(sender is GridView gridView) {
                if(gridView.SelectedItems.Count == 0) {
                    BitmapImage b = new BitmapImage();
                    b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\NoClothes.png");
                    Characterskin.Source = b;
                }else if(gridView.SelectedItems.Count == 1) {
                    if(gridView.SelectedIndex == 0) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\Hat.png");
                        Characterskin.Source = b;
                    } else if(gridView.SelectedIndex == 1) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\Glasses.png");
                        Characterskin.Source = b;
                    } else if (gridView.SelectedIndex == 2) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\Dress.png");
                        Characterskin.Source = b;
                    }
                } else if(gridView.SelectedItems.Count == 2) {
                    if(gridView.SelectedItems.Contains(ListaPrendas[0]) && gridView.SelectedItems.Contains(ListaPrendas[1])) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\HatGlasses.png");
                        Characterskin.Source = b;
                    }
                    else if (gridView.SelectedItems.Contains(ListaPrendas[0]) && gridView.SelectedItems.Contains(ListaPrendas[2])) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\HatDress.png");
                        Characterskin.Source = b;
                    }
                    else if (gridView.SelectedItems.Contains(ListaPrendas[1]) && gridView.SelectedItems.Contains(ListaPrendas[2])) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\GlassesDress.png");
                        Characterskin.Source = b;
                    }
                } else if (gridView.SelectedItems.Count == 3) {
                    if (gridView.SelectedItems.Contains(ListaPrendas[0]) && gridView.SelectedItems.Contains(ListaPrendas[1]) && gridView.SelectedItems.Contains(ListaPrendas[2])) {
                        BitmapImage b = new BitmapImage();
                        b.UriSource = new Uri(Characterskin.BaseUri, "Assets\\character\\HatGlassesDress.png");
                        Characterskin.Source = b;
                    }
                }
            }
        }
    }
}
