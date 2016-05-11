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
            if (ignore != null && ignore.Count() == 0 && firstJson == secondJson)
                return true;

            if (!IsSameType(firstJson, secondJson))
            {
                //Logger
                return false;
            }
                

            var token = JToken.Parse(firstJson);

            if (token is JArray)
                return IsSameArrayOfJsonObject(firstJson, secondJson, ignore);

            if (token is JObject)
                return IsSameJsonObject(firstJson, secondJson, ignore);

            return true;
        }

        private static bool IsValidJson(string json)
        {
            try
            {
                var token = JToken.Parse(json);

                if (token is JArray)
                    return true;

                if (token is JObject)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
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
                    var firstJson = value.ToString();
                    var secondJson = secondObject[key].ToString();
                    if (IsValidJson(firstJson) && IsValidJson(secondJson))
                    {
                        if (!IsEqualJsons(firstJson, secondJson,ignore))
                            return false;
                    }
                    else if (secondObject[key] != value)
                    {
                        //Logger
                        return false;
                    }
                }

            }
            return true;
        }
        private static bool IsValidListOfJsonObject(string json)
        {
            try
            {
                JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(json);
                return true;
            }
            catch(Exception)
            {
                return false;
            }            
        }
        private static bool IsSameJsonArray(string firstJson,string secondJson)
        {
            return firstJson == secondJson;
        }
        private static bool IsSameArrayOfJsonObject(string firstJson, string secondJson, params string[] ignore)
        {
            if(!IsValidListOfJsonObject(firstJson) && !IsValidListOfJsonObject(secondJson))
            {
                return IsSameJsonArray(firstJson, secondJson);
            }
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
