using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombLand {

    public class Arma {
        public enum estados {Equipado, Desequipado};

        public int Id {
            get; set;
        }

        public string ImgEquipada {
            get; set;
        }

        public string ImgDesequipada {
            get; set;
        }

        public string ImgFocus {
            get; set;
        }

        public estados Estado {
            get; set;
        }

        public Arma() {
        
        }
    }
    public class Model {
        public static List<Arma> Armas = new List<Arma>() {
            new Arma() {
                Id = 0,
                ImgEquipada = "Assets\\armeria\\Blood Star selected.png",
                ImgDesequipada = "Assets\\armeria\\Blood Star unselected.png",
                ImgFocus = "Assets\\armeria\\Blod Star focus.png",
                Estado = Arma.estados.Desequipado,
            },

            new Arma() {
                Id = 1,
                ImgEquipada = "Assets\\armeria\\Cyclone selected.png",
                ImgDesequipada = "Assets\\armeria\\Cyclone unselected.png",
                ImgFocus = "Assets\\armeria\\Cyclone focus.png",
                Estado = Arma.estados.Desequipado,
            },

            new Arma() {
                Id = 2,
                ImgEquipada = "Assets\\armeria\\Laser Gun selected.png",
                ImgDesequipada = "Assets\\armeria\\Laser Gun unselected.png",
                ImgFocus = "Assets\\armeria\\Laser Gun focus.png",
                Estado = Arma.estados.Desequipado,
            },

            new Arma() {
                Id = 3,
                ImgEquipada = "Assets\\armeria\\Medkit selected.png",
                ImgDesequipada = "Assets\\armeria\\Medkit unselected.png",
                ImgFocus = "Assets\\armeria\\Medkit focus.png",
                Estado = Arma.estados.Desequipado,
            },

            new Arma() {
                Id = 4,
                ImgEquipada = "Assets\\armeria\\Mortar selected.png",
                ImgDesequipada = "Assets\\armeria\\Mortar unselected.png",
                ImgFocus = "Assets\\armeria\\Mortar focus.png",
                Estado = Arma.estados.Desequipado,
            },

            new Arma() {
                Id = 5,
                ImgEquipada = "Assets\\armeria\\RiotGun selected.png",
                ImgDesequipada = "Assets\\armeria\\RiotGun unselected.png",
                ImgFocus = "Assets\\armeria\\RiotGun focus.png",
                Estado = Arma.estados.Desequipado,
            },

            new Arma() {
                Id = 6,
                ImgEquipada = "Assets\\armeria\\UltraUrn selected.png",
                ImgDesequipada = "Assets\\armeria\\Ultra Urn unselected.png",
                ImgFocus = "Assets\\armeria\\Ultra Urn focus.png",
                Estado = Arma.estados.Desequipado,
            }
        };

        public static IList<Arma> GetAllArmas() {
            return Armas;
        }

        public static Arma GetArmaById(int id) {
            return Armas[id];
        }
    }
}
