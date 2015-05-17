using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tema2_2.Models
{
    public class Factory
    {

        //String s;

        public static Exporter GetFormat(String s)
        {
            if (s == "csv")
                return new CsvExporter();
            else
                return new JsonExporter();
        }

    }
}