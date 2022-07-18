namespace _4.WildFarm.Models.Food
{
    public abstract class Food
    {
        public int Quantity { get; }
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
