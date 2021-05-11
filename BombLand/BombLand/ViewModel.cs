using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BombLand {
    public class VMArma : Arma {
        public Image Img;
        public Image ImageFocus;

        public VMArma(Arma arma) {
            Id = arma.Id;
            ImgEquipada = arma.ImgEquipada;
            ImgDesequipada = arma.ImgDesequipada;
            ImgFocus = arma.ImgFocus;
            Estado = arma.Estado;
            Img = new Image();
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + arma.ImgDesequipada;
            Img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
        }
    }
}
