namespace Pokemon.Api
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        protected int Order { get; private set; }       
    }
}
