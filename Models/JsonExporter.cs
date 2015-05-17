using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Tema2_2.Models
{
    public class JsonExporter : Exporter
    {
        public void Export(List<Product> list)
        {
            
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText("d:\\PROGRAMARE\\C#\\Tema2_2 - Copy\\exportJson.json", json);
            
        }
    }
}