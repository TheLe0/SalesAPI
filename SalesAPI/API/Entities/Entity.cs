using API.Utils;

using Newtonsoft.Json;

namespace API.Entities
{
    public class Entity
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, JsonUtils.JsonSerializeParameters());
        }
    }
}
