namespace OrderEntryEngine
{
    public interface IEntity
    {
        int Id { get; }

        bool IsArchived { get; set; }

        bool IsValid { get; }
    }
}