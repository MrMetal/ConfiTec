namespace DemoConfiTec.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new int();
        }

        public int Id { get; set; }
    }
}