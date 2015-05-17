using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema2_2.Models
{
    public interface Exporter
    {
        void Export(List<Product> list);
    }
}
