using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace API.Utils
{
    public class JsonUtils
    {
        public static JsonSerializerSettings JsonSerializeParameters()
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };
        }
    }
}
