namespace JeuDeRole
{
    public class Hero : Personnage
    {
        public int PV { get; set; }
        public int NombrePotion = 3;


        public Hero(string name): base(name, 50, 50, 35)
        {

        }
        
    }
}
