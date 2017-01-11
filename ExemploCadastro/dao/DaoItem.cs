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
using System.Linq;
using System.Collections.Generic;
using ExemploCadastro.Model;

namespace ExemploCadastro.Dao
{   
    /**
     * Classe responsável pelos métodos de ação com o banco de dados 
     **/
    public class DaoItens
    {
        public IEnumerable<Item> ObtemItens()
        {
            List<Item> dados = new List<Item>();
            using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
            {
                dados = (from item in db.Itens orderby item.Descricao select item).ToList();
            }
            return dados;
        }

        public bool Gravar(Item novoItem)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    db.Itens.InsertOnSubmit(novoItem);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("erro ao deletar");
                return false;
            }
        }

        public bool Excluir(Item item)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    var excluir = db.Itens.Where(t => t.Id == item.Id).First();
                    db.Itens.DeleteOnSubmit(excluir);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Adicionados(Item item)
        {
            try
            {
                using (DataBaseContext db = new DataBaseContext(DataBaseContext.ConnectionString))
                {
                    Item update = (from tar in db.Itens
                                     where tar.Id == item.Id
                                     select tar).First();
                    update.Adicionado = !update.Adicionado;
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
