namespace ObjectOrientedProgramming
{
    public abstract class Character
    {
        public string Name;
        public int HitPoints;

        public abstract void Defend(Player player);
        public abstract void Talk(Player player);
    }
}
