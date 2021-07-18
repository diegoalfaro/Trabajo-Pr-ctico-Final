using Newtonsoft.Json;

namespace RestService.Common
{
    class JsonResponse<TEntity>: Response
    {
        public TEntity Entity => JsonConvert.DeserializeObject<TEntity>(Body);
    }
}
