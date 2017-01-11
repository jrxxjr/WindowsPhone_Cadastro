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
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using ExemploCadastro.Dao;

namespace ExemploCadastro.Model
{
    /**
     * Classe correpondete a tabela Item no banco de dados 
     **/
    [Table(Name="Item")]
    public class Item
    {
        private int _id;

        [Column(Name="Id", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false, AutoSync=AutoSync.OnInsert)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricao;

        [Column(Name="Descricao", CanBeNull=false)]
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private bool _adicionado;

        [Column(Name="Adicionado", CanBeNull=false)]
        public bool Adicionado
        {
            get { return _adicionado; }
            set { _adicionado = value; }
        }


        public IEnumerable<Item> ObtemItens()
        {
            DaoItens daoItem = new DaoItens();
            return daoItem.ObtemItens();
        }

        public bool Gravar()
        {
            DaoItens daoItem = new DaoItens();
            return daoItem.Gravar(this);
        }

        public bool Excluir()
        {
            DaoItens daoItem = new DaoItens();
            return daoItem.Excluir(this);
        }

        public bool Adicionados()
        {
            DaoItens daoItem = new DaoItens();
            return daoItem.Adicionados(this);
        }
    }
}
