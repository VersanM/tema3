using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Tema2_2.Models
{
    public class CsvExporter : Exporter
    {
        public void Export(List<Product> list)
        {
            string csv = CsvSerializer.GetCSV(list);
            CsvSerializer.ExportCSV(csv);
        }
    }
}