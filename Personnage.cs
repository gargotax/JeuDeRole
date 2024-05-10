using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JeuDeRole
{
    public abstract class Personnage
    {
        public string Name { get; set; }
        public int MaxPV { get; }
        public int CurrentPV { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }

        public abstract void NormalAttack(Personnage personnage);

        public abstract void Heal(Personnage personnage);

        public abstract void MagicAttack(Personnage personnage);

    }
}
