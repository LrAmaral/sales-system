using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenda.Classes
{
    internal class venda
    {
        public int id { get; set; }
        public int codCliente { get; set; }
        public DateTime data { get; set; }
        public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    }

    internal class ItemVenda
    {
        public int codVenda {  get; set; }
        public int codProduto { get; set; }
        public int quantidade { get; set; }
        public decimal valorUnitario { get; set; } 
        public decimal totalItem { get; set; }
    }
}
