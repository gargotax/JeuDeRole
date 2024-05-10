namespace JeuDeRole
{
    public class Hero : Personnage
    {
        public  string Name { get; set; }
        public  int MaxPV { get; set; }
        public  int Attack { get; set; }
        public  int Defense { get; set; }
        public  int Magic { get; set; }
        public int PV { get; set; }
        public Potion? Potion { get; set; }

        public Hero(string name)
        {
            MaxPV = 50;
            Name = name;

        }
        public override void Heal(Personnage hero)
        {
            Console.WriteLine("appuyez sur la touche 'H' pour lancer un sort de soins");
            Console.ReadLine();


            if (MaxPV == 50)
            {
                Console.WriteLine("max PV!");
            }
            else if (CurrentPV > 0)
            {
                Random rnd = new Random();
                int decreaseMagic = 5;
                int heroPV = hero.CurrentPV;
                Magic = rnd.Next(15);
                Magic -= decreaseMagic;
                heroPV += 5;
                Console.WriteLine($"vous vous etes soigné, vous avez recupere {heroPV}, il vous reste point de {Magic} ");

            }

            Console.ReadKey();
        }
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
                PrendrePotion(Potion, personnage);
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
        public override void MagicAttack(Personnage ennemy)
        {
            Console.WriteLine("appuyez sur la touche 'M' pour faire une attaque magique");
            Console.ReadLine();
            bool victory = false;

            while (ennemy.CurrentPV > 0 && CurrentPV != 0 && !victory)
            {
                if (Magic > 5)
                {
                    var rnd = new Random();
                    int decreaseMagic = 8;
                    Magic = rnd.Next(5, 10);
                    Magic -= decreaseMagic;
                    ennemy.CurrentPV -= Magic;

                    Console.ReadKey();
                }

                if (ennemy.CurrentPV == 0)
                {
                    victory = true;
                    Console.WriteLine("bravo vous avez gagné");
                }
                else if (CurrentPV == 0)
                {
                    Console.WriteLine("dommage, vous avez perdu");
                }
            }

        }
        public override void NormalAttack(Personnage ennemy)
        {
            Console.WriteLine("appuyez sur la touche 'N' pour faire une attaque normale");
            Console.ReadLine();
            bool victory = false;

            while (ennemy.CurrentPV > 0 && CurrentPV != 0 && !victory)
            {
                var rnd = new Random();
                Attack = rnd.Next(5, 10);
                ennemy.CurrentPV -= Attack;
                Console.WriteLine($"il reste encore {ennemy.CurrentPV} points de vie a l'ennemi {ennemy.Name}");
                Console.WriteLine($"il vous reste encore {CurrentPV}");

                if (ennemy.CurrentPV == 0)
                {
                    victory = true;
                }
            }

            Console.ReadKey();
        }

        public int PrendrePotion(Potion potion, Personnage personnage)
        {
            Console.WriteLine("appuyez sur la touche 'P' pour prendre une potion");
            Console.ReadLine();

            if (personnage.CurrentPV > 0)
            {
                if (potion.NombrePotion > 0 && potion.NombrePotion < 3)
                {
                    if (MaxPV < 100)
                    {
                        Console.WriteLine($"boire une {potion}");
                        var rnd = new Random();
                        personnage.CurrentPV = rnd.Next(5, 50);
                        potion.NombrePotion--;

                    }
                }
                else if (potion.NombrePotion <= 0)
                {
                    Console.WriteLine("vous n'avez plus de potions!");
                }
            }

            return personnage.CurrentPV;

        }


    }
}
