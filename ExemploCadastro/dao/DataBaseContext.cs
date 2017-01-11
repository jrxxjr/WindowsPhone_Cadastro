using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq;
using ExemploCadastro.Model;

namespace ExemploCadastro.Dao
{
    /**
     * Classe responsável pela conexão de banco de dados 
     * Autor: Evaldo Junior 
     * */
    public class DataBaseContext : DataContext
    {
        public static string ConnectionString = "Data Source=isostore:/InfoTeste.sdf";

        private Table<Item> itens;

        public Table<Item> Itens
        {
            get
            {
                if (itens == null)
                    itens = GetTable<Item>();

                return itens;
            }
        }

        public DataBaseContext(string connectionString):base(connectionString)
        {
            if (!this.DatabaseExists())
                this.CreateDatabase();
        }
    }
}
