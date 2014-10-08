namespace RPGGame
{
    public abstract class GameObject
    {
        protected GameObject(string id)
        {
            this.id = id;
        }

        public string id { get; set; }
    }
}
