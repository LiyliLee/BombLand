using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombLand
{

    public class TareaGrowing
    {
        public enum estados { NoTerminado, Terminado, Recogido };

        public int Id
        {
            get; set;
        }
        public string ImgTarea
        {
            get; set;
        }
        public string Vacio
        {
            get; set;
        }
        public string ImgReward
        {
            get; set;
        }

        public string ImgRecogido
        {
            get; set;
        }

        public string ImgTerminado
        {
            get; set;
        }
        public string Descripcion
        {
            get; set;
        }

        public string RecogidoImagen
        {
            get; set;
        }
        public string TerminadoImagen
        {
            get; set;
        }

        public estados Estado
        {
            get; set;
        }

        public TareaGrowing()
        {

        }
    }

    public class TareaMision
    {
        public enum estados { NoTerminado, Terminado, Recogido };

        public int Id
        {
            get; set;
        }

        public string ImgRecogido
        {
            get; set;
        }
        public string ImgTerminado
        {
            get; set;
        }

        public string RecogidoImagen
        {
            get; set;
        }
        public string TerminadoImagen
        {
            get; set;
        }

        public string Vacio
        {
            get; set;
        }


        public string ImgTarea
        {
            get; set;
        } 
        public string ImgReward
        {
            get; set;
        }

      
        public string Descripcion
        {
            get; set;
        }

        public string Reward
        {
            get; set;
        }
        public estados Estado
        {
            get; set;
        }

        public TareaMision()
        {

        }
    }

    public class Model2
    {
        public static List<TareaMision> Misiones = new List<TareaMision>() {
            new TareaMision() {
                Id = 0,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Acabar.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgReward = "Assets\\Image\\MMision\\Icons\\Encontrar.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaMision.estados.Recogido,
                Descripcion = "Play 1 game in PVP mode",
                Reward = " x 2"
            },
            new TareaMision() {
                Id = 1,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\PVE.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgReward = "Assets\\Image\\MMision\\Icons\\Personalizar.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaMision.estados.Terminado,
                Descripcion = "Win 1 match in PVE mode",
                Reward = "x 1"
            },
            new TareaMision() {
                Id = 2,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Regalar.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgReward = "Assets\\Image\\MMision\\Icons\\Usar.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaMision.estados.Terminado,
                Descripcion = "Give 1 gift to a friend",
                Reward = " x 3"
            },
            new TareaMision() {
                Id = 3,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Tiempo.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgReward = "Assets\\Image\\MMision\\Icons\\Mejorar.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaMision.estados.NoTerminado,
                Descripcion = "Win 1 PVE game in 120 sec",
                Reward = " x 1"
            },
            new TareaMision() {
                Id = 4,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Turno.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgReward = "Assets\\Image\\MMision\\Icons\\Encontrar.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaMision.estados.NoTerminado,
                Descripcion = "Win 1 PVP game in 10 turns",
                Reward = " x 2"
            }

        };

        public static IList<TareaMision> GetAllMisiones()
        {
            return Misiones;
        }

        public static TareaMision GetMisionById(int id)
        {
            return Misiones[id];
        }
        //------------------------------------------------------------

        public static List<TareaGrowing> Crecimientos = new List<TareaGrowing>() {
            new TareaGrowing() {
                Id = 0,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Ganar.png",
                ImgReward = "Assets\\Image\\diamante.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaGrowing.estados.Terminado,
                Descripcion = "Reach level 3."
            },
            new TareaGrowing() {
                Id = 1,
                 ImgTarea = "Assets\\Image\\MMision\\Icons\\Ganar.png",
                  ImgReward = "Assets\\Image\\diamante.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaGrowing.estados.Terminado,
                Descripcion = "Reach level 5."
            },
            new TareaGrowing() {
                Id = 2,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Ganar.png",
                  ImgReward = "Assets\\Image\\diamante.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaGrowing.estados.NoTerminado,
                Descripcion = "Reach level 10."
            },
            new TareaGrowing() {
                Id = 3,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Ganar.png",
                 ImgReward = "Assets\\Image\\diamante.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaGrowing.estados.NoTerminado,
               Descripcion = "Reach level 15."
            },
            new TareaGrowing() {
                Id = 4,
                ImgTarea = "Assets\\Image\\MMision\\Icons\\Ganar.png",
                  ImgReward = "Assets\\Image\\diamante.png",
                ImgRecogido = "Assets\\Image\\PVE\\recibido.png",
                ImgTerminado = "Assets\\Image\\MMision\\Terminado.png",
                Vacio = "Assets\\Image\\vacio.png",
                Estado = TareaGrowing.estados.NoTerminado,
               Descripcion = "Reach level 20."
            }

        };

        public static IList<TareaGrowing> GetAllGrowing()
        {
            return Crecimientos;
        }

        public static TareaGrowing GetGrowingById(int id)
        {
            return Crecimientos[id];
        }
    }
}
