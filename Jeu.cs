
using System.Reflection.PortableExecutable;

namespace JeuDeRole
{
    public class Jeu
    {

       private Random random = new Random();

        private Hero _hero;
        private Ennemy _ennemy;

        public Jeu()
        {
             _hero = new Hero("Luke");
             _ennemy = new Ennemy("Vador");
        }
        public void Game()
        {            
            while (_hero.CurrentPV > 0 && _ennemy.CurrentPV > 0)
            {
                ChoixAction();              
            }

            if(_hero.CurrentPV<= 0 && _ennemy.CurrentPV > 0)
            {
                Console.WriteLine("vous avez perdu");
            }
            else
            {
                Console.WriteLine("bravo vous avez gagné!");
            }
        }
        private void ChoixAction()
        {
            Console.WriteLine("choisissez une action, M pour attaque magique, N pour attaque normale, P pour prendre une potion, H pour vous soigner");

            string attaqueMagique = "M".ToLower();
            string attaqueNormale = "N".ToLower();
            string boirePotion = "P".ToLower();
            string heal = "H".ToLower();

            string? input = Console.ReadLine();
            if (input != attaqueMagique && input != attaqueNormale && input != boirePotion)
            {
                Console.WriteLine("veuillez choisir une action");
            }
            if (input == boirePotion)
            {
                PrendrePotion();
            }
            else if (input == attaqueNormale)
            {
                NormalAttack();
            }
            else if (input == attaqueMagique)
            {
                MagicAttack();
            }
            else if(input == heal)
            {
                Heal();
            }
        }
        private void Heal()
        {           

            if (_hero.MaxPV == 50)
            {
                Console.WriteLine("max PV!");
            }
            else if (_hero.CurrentPV > 0)
            {
                Random rnd = new Random();
                int decreaseMagic = 5;
                int heroPV = _hero.CurrentPV;
                _hero.Magic = rnd.Next(15);
                _hero.Magic -= decreaseMagic;
                heroPV += 5;
                Console.WriteLine($"vous vous etes soigné, vous avez recupere {heroPV}, il vous reste point de {_hero.Magic} ");

            }
        }
        private void MagicAttack()
        {
            if (_hero.Magic >= 5)
            {
                int decreaseMagic = 8;
                int damages = random.Next(5, 10);
                _hero.Magic -= decreaseMagic;
                _ennemy.CurrentPV -= damages;
                Console.WriteLine($"il reste encore {_ennemy.CurrentPV} points de vie a l'ennemi {_ennemy.Name}");

            }
            else
            {
                Console.WriteLine("pas assez de mana");
            }
        }
        private void NormalAttack()
        {

            int damages = random.Next(3, 8);
            _ennemy.CurrentPV -= damages;
            Console.WriteLine($"il reste encore {_ennemy.CurrentPV} points de vie a l'ennemi {_ennemy.Name}");
        }
        private void PrendrePotion()
        {
            if (_hero.CurrentPV <= 0)
            {
                Console.WriteLine("vous etes mort, tant pis pour vous");
                return;
            }
            
            if (_hero.NombrePotion <= 0)
            {
                Console.WriteLine("vous n'avez plus de potions!");
                return;
                
            }

            if (_hero.CurrentPV < _hero.MaxPV)
            {
                Console.WriteLine("boire une potion");     
                _hero.CurrentPV = random.Next(5, 50);
                _hero.NombrePotion--;
                Console.WriteLine("vous avez pris une potion");
                Console.WriteLine($"il vous reste encore {_hero.NombrePotion}");
            }
            else
            {
                Console.WriteLine("vous etes deja maxPV");
               
            }

        }
        
    }
}
