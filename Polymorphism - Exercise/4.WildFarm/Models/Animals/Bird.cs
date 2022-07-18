namespace _4.WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; }

        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]"; //problem in :f2 or :f1 ???
        }
    }
}
