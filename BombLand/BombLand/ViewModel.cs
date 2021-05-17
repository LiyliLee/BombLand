using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BombLand {
    public class VMArma : Arma {
        //public Image Img;
        public string Img;
        public Image ImageFocus;

        public VMArma(Arma arma) {
            Id = arma.Id;
            ImgEquipada = arma.ImgEquipada;
            ImgDesequipada = arma.ImgDesequipada;
            ImgFocus = arma.ImgFocus;
            Estado = arma.Estado;
            //if(Estado == estados.Desequipado) {
            //    Img = ImgDesequipada;
            //}
            //else if (Estado == estados.Equipado) {
            //    Img = ImgEquipada;
            //}
            if (Estado == estados.Desequipado) {
                ImgDisplay = ImgDesequipada;
            }
            else if (Estado == estados.Equipado) {
                ImgDisplay = ImgEquipada;
            }
            //Img = new Image();
            //string s = System.IO.Directory.GetCurrentDirectory() + "\\" + arma.ImgDesequipada;
            //Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
        }
    }
    //------------------------------------------------------------------

    public class VMPrenda : Prenda {
        public Image Imgp;

        public VMPrenda(Prenda prenda) {
            Id = prenda.Id;
            ImgChecked = prenda.ImgChecked;
            ImgUnchecked = prenda.ImgUnchecked;
            Estado = prenda.Estado;
            Imgp = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + prenda.ImgUnchecked;
            Imgp.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
        }
    }
}
