namespace JeuDeRole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Hero hero = new Hero("Luke");
            Ennemy ennemy = new Ennemy("Vador");
            ennemy.NormalAttack(hero);

        }
    }
}
