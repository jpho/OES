namespace OrderEntryEngine
{
    public class EntityEventArgs<T>
    {
        public EntityEventArgs(T entity)
        {
            this.Entity = entity;
        }

        public T Entity { get; private set; }
    }
}