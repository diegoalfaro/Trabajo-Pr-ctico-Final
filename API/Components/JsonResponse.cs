using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace API.Components
{
    public class JsonResponse : Response
    {
        public dynamic ToJson()
        {
            return JsonConvert.DeserializeObject(this.Body);
        }

        public TObject ToJson<TObject>()
        {
            return JsonConvert.DeserializeObject<TObject>(this.Body);
        }
    }
}
