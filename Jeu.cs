using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeRole
{
    public class Jeu:Personnage
    {
        public void ChoixAction(Personnage personnage)
        {
            Console.WriteLine("choisissez une action, M pour attaque magique, N pour attaque normale, P pour prendre une potion");
            var attaqueMagique = "M".ToLower();
            var attaqueNormale = "N".ToLower();
            var boirePotion = "P".ToLower();

            var input = Console.ReadLine();
            if (input != attaqueMagique && input != attaqueNormale && input != boirePotion)
            {
                Console.WriteLine("veuillez choisir une action");
            }

            if (input == boirePotion)
            {
                //PrendrePotion(Potion, personnage);
            }
            else if (input == attaqueNormale)
            {
                NormalAttack(personnage);
            }
            else if (input == attaqueMagique)
            {
                MagicAttack(personnage);
            }

        }

        public override void Heal(Personnage personnage)
        {
            throw new NotImplementedException();
        }


        public override void MagicAttack(Personnage personnage)
        {
            throw new NotImplementedException();
        }

    


        public override void NormalAttack(Personnage personnage)
        {
            throw new NotImplementedException();
        }
    }
}
