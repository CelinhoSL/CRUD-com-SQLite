using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace CRUD_com_SQlite.Models
{
    public class Produto
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Double Quantidade { get; set; }
        public Double Preco { get; set; }
        public Double Total { get => Quantidade * Preco; }

    }
}
