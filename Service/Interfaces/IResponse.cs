namespace Service.Interfaces
{
    internal interface IResponse : IHttpMessage
    {
        int Status { get; }
    }
}
