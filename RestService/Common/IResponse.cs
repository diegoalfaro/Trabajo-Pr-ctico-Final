namespace RestService.Common
{
    internal interface IResponse : IHttpMessage
    {
        int Status { get; }
    }
}
