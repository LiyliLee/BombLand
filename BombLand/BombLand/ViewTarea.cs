
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BombLand
{
    public class VMTareaMision : TareaMision
    {
       

        public VMTareaMision(TareaMision tmsion)
        {
            Id = tmsion.Id;
            ImgRecogido = tmsion.ImgRecogido;
            ImgTarea = tmsion.ImgTarea;
            ImgTerminado = tmsion.ImgTerminado;
            ImgReward = tmsion.ImgReward;
            RecogidoImagen = tmsion.ImgRecogido;
            TerminadoImagen = tmsion.ImgTerminado;
            Vacio = tmsion.Vacio;
            Estado = tmsion.Estado;
            Descripcion = tmsion.Descripcion;
            Reward = tmsion.Reward;
            
        }
    }
    //------------------------------------------------------------------

    public class VMTareaGrowing : TareaGrowing
    {
       

        public VMTareaGrowing(TareaGrowing tgwing)
        {
            Id = tgwing.Id;
            string s;
            ImgRecogido = tgwing.ImgRecogido;
            ImgReward = tgwing.ImgReward;
            ImgTerminado = tgwing.ImgTerminado;
            Estado = tgwing.Estado;
            Descripcion = tgwing.Descripcion;
        }
    }
}

