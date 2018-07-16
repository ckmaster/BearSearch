using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommonComponents
{
    public class JsonManager
    {
        private static string json;
        public JsonManager(string json)
        {
            JsonManager.json = json;
        }

        public JObject GenericDeserialize()
        {
            //Look at refining and readding DeserializeJson later
            //https://github.com/ckmaster/PullIndexHTML/blob/master/PullCRMImages/Program.cs
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);
            return jObject;
        }
    }
}
