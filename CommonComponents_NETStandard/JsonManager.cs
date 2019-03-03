using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace CommonComponents_NETStandard
{
    public class JsonManager
    {
        public JsonManager ()
        {
        }

        public JObject GenericDeserialize(string json)
        {
            //Look at refining and readding DeserializeJson later
            //https://github.com/ckmaster/PullIndexHTML/blob/master/PullCRMImages/Program.cs
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);
            return jObject;
        }

        public string GenericSerialize(object item)
        {
            string retval = JsonConvert.SerializeObject(item);
            return retval;
        }

        public string GetTokenValue(JObject jObject, string tokenToFind)
        {
            string token = (string)jObject.SelectToken(tokenToFind);
            return token;
        }

        public List<string> GetMultiTokenValues(JObject jObject, string tokenToFind)
        {
            List<string> tokenValues = new List<string>();
            IEnumerable<JToken> jTokens = jObject.SelectTokens(tokenToFind);
            foreach(JToken jt in jTokens)
            {
                tokenValues.Add(jt.ToString());
            }
            return tokenValues;
        }
    }
}
