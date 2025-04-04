﻿using CRUD_com_SQlite.Helpers;
using System.Globalization;

namespace CRUD_com_SQlite
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath
                        (Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(".....2");
                }
                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            

            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
