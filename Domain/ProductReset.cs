namespace Domain
{
    public interface ProductReset
    {
        string Number { get; set; }
        int Error { get; set; }
        string ErrorDescription { get; set; }
    }
}
