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
        double _quantidade;
        string _descricao;
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public string Descricao {
            get => _descricao;
            set { 
            if (value == null)
                {
                    throw new Exception("Prencha a descrição");
                }

                _descricao = value;
            }
        }
        public double Quantidade
        {
            get => _quantidade;
            set
            {
                if (value <= 0) 

                {
                    throw new Exception("Adicione uma quantidade");
                }

                _quantidade = value;
            }
        }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }

    }
}
