using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantar.GHP.APITestClient
{
    internal class Validate
    {
        public static bool ValidateToken(string token)
        {
            return true;
        }
        public static bool IsEqualJsons(string firstJson, string secondJson, params string[] ignore)
        {
            if (!IsSameType(firstJson, secondJson))
            {
                //Logger
                return false;
            }
                

            var token = JToken.Parse(firstJson);

            if (token is JArray)
                return IsSameJsonArray(firstJson, secondJson, ignore);

            if (token is JObject)
                return IsSameJsonObject(firstJson, secondJson, ignore);

            return true;
        }
        private static bool IsSameType(string firstJson, string secondJson)
        {
            var firstObject = JToken.Parse(firstJson);
            var secondObject = JToken.Parse(secondJson);
            if (firstObject is JArray && !(secondObject is JArray))
            {
                //Logger
                return false;
            }

            if (firstObject is JObject && !(secondObject is JObject))
            {
                //Logger
                return false;
            }

            return true;
        }
        private static bool IsSameJsonObject(string firstJson, string secondJson, params string[] ignore)
        {
            var firstObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(firstJson);
            var secondObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(secondJson);
            return IsSameDictionary(firstObject, secondObject, ignore);
        }
        private static bool IsSameDictionary(Dictionary<string, dynamic> firstObject, Dictionary<string, dynamic> secondObject, string[] ignore)
        {
            foreach (var item in firstObject)
            {
                var key = item.Key;
                var value = item.Value;
                if (!ignore.Contains(key))
                {
                    if (secondObject[key] != value)
                    {
                        //Logger
                        return false;
                    }
                }

            }
            return true;
        }
        private static bool IsSameJsonArray(string firstJson, string secondJson, params string[] ignore)
        {
            var firstList = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(firstJson);
            var secondList = JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(secondJson);

            if (firstList.Count != secondList.Count)
            {
                //Logger
                return false;
            }

            for (var i = 0; i < firstList.Count; i++)
            {
                if (!IsSameDictionary(firstList[i], secondList[i], ignore))
                {
                    //Logger
                    return false;
                }
            }

            return true;
        }

    }
}
