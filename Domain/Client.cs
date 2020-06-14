namespace Domain
{
    public interface Client
    {
        int Id { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        ClientSegment Segment { get; set; }
    }
}
