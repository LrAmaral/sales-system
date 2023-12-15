using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.Classes
{
    internal class produto
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
    }
}
