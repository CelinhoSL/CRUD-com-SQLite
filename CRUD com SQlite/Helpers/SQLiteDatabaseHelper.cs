using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CRUD_com_SQlite.Models;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_com_SQlite.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string dbName)
        {
            
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string dbPath = Path.Combine(folderPath, dbName);

            
            _conn = new SQLiteAsyncConnection(dbPath);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task <int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Categoria=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Categoria, p.Quantidade, p.Preco, p.Id
                );
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }


        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT *  FROM Produto WHERE descricao LIKE '%" + q + "%' OR categoria LIKE '%" + q + "%' ";
            return _conn.QueryAsync<Produto>(sql);
        }

        public Task<List<Produto>> GetTag()
        {
            return _conn.Table<Produto>()
                        .ToListAsync()
                        .ContinueWith(task =>
                        {
                            var produtos = task.Result;
                            var resultado = produtos.GroupBy(p => p.Categoria)
                                                    .Select(g => new Produto
                                                    {
                                                        Categoria = g.Key,
                                                        TotalCategoria = g.Sum(p => p.Total)
                                                    })
                                                    .ToList();
                            return resultado;
                        });
        }

    }
}