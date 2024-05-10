using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeRole
{
    public class Ennemy : Personnage
    {
        public  string Name { get; set; }
        public  int MaxPV { get; set; }
        public  int Attack { get; set; }
        public  int Defense { get; set; }
        public int Magic { get; set; }

        public Ennemy(string name)
        {
            MaxPV = 50;
            Name = name;

        }
        public override void NormalAttack(Personnage hero)
        {
            bool victory = false;
            var rnd = new Random();
            CurrentPV = MaxPV;
            hero.CurrentPV = MaxPV;

            while(CurrentPV>0 && hero.CurrentPV>0 && !victory)
            {
                Attack = rnd.Next(5, 10);
                hero.CurrentPV -= Attack;
                Console.WriteLine($"il reste encore {hero.CurrentPV} au {hero.Name}");

                Console.WriteLine($"c'est autour de {hero} de jouer");

            }
            if (hero.CurrentPV <= 0)
            {
                victory = true;
                Console.WriteLine("vous avez gagné");
            }
            
            Console.ReadKey();
        }
        public override void Heal(Personnage personnage)
        {

            bool victory = false;
            while(CurrentPV > 0 && Magic>3 && !victory)
            {
                if (MaxPV == 50)
                {
                    Console.WriteLine("max PV!");
                }
                if (Magic < 3)
                {
                    Console.WriteLine("pas assez de mana");
                }
                else
                {
                    var rnd = new Random();
                    int decreaseMagic = 3;
                    Magic = rnd.Next(15);
                    Magic -= decreaseMagic;
                    personnage.CurrentPV += 5;
                    Console.WriteLine($"vous vous etes soigné, vous avez maintenant{CurrentPV} points de vie");
                    Console.WriteLine($"il vous reste encore {Magic} points de mana");
                    Console.WriteLine($"c'est autour de votre adversaire de jouer");

                }

                if (CurrentPV == 0)
                {
                    victory = true;
                }
            }

            Console.WriteLine("vous avez perdu");
            Console.ReadKey();
        }
        public override void MagicAttack(Personnage hero)
        {

            bool victory = false;
            while (CurrentPV>0 && !victory)
            {
                if(Magic<5)
                {
                    Console.WriteLine("pas assez de mana");
                }

                if (Magic > 5)
                {
                    Console.WriteLine("vous lancez une magie!");
                    var rnd = new Random();
                    int decreaseMagic = 8;
                    Magic = rnd.Next(5, 10);
                    Magic -= decreaseMagic;
                    CurrentPV -= Magic;
                    hero.CurrentPV -= 5;

                    Console.WriteLine($"Hero a subi {hero.CurrentPV} de degats");
                    Console.WriteLine($"il vous reste {Magic} points de mana");
                    Console.WriteLine($"c'est autour de {hero} de jouer");

                }

            }
            
        }
    }
}
