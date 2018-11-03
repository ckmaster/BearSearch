using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommonComponents_NETCore
{
    public class JsonManager
    {
        private static string json;
        public JsonManager (string json)
        {
            JsonManager.json = json;
        }

        public JObject GenericDeserialize ()
        {
            //Look at refining and readding DeserializeJson later
            //https://github.com/ckmaster/PullIndexHTML/blob/master/PullCRMImages/Program.cs
            JObject jObject = JsonConvert.DeserializeObject<JObject>(json);
            return jObject;
        }
    }
}
