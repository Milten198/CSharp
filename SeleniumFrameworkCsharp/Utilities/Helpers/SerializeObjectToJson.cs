using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Utilities.Helpers
{
    public static class SerializeObjectToJson
    {
        public static string SerializeToJson(object data)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(data);
        }

    }
}
