namespace RestService.Interfaces
{
    internal interface IResponse : IHttpMessage
    {
        int Status { get; }
    }
}
