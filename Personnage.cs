

namespace JeuDeRole
{
    public abstract class Personnage
    {
        public string Name { get; }
        public int MaxPV { get; }
        public int CurrentPV { get; set; }

        public int Defense { get; set; }
        public int Magic { get; set; }

        public Personnage(string name, int maxPV, int currentPV, int magic)
        {
            Name = name;
            MaxPV = maxPV;
            CurrentPV = currentPV;
            Magic = magic;
        }

    }
}
