using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ExemploCadastro.Model;

namespace ExemploCadastro
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            AtualizarTarefas();
        }

        private void AtualizarTarefas()
        {
            Item objTarefa = new Item();
            toDoList.ItemsSource = objTarefa.ObtemItens();
        }

        private void txtToDo_ActionIconTapped(object sender, EventArgs e)
        {
            Item novoItem = new Item
            {
                Descricao = txtToDo.Text,
                Adicionado = false
            };
            novoItem.Gravar();

            txtToDo.Text = string.Empty;
            AtualizarTarefas();
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var t = sender as Image;
            if (t != null)
            {
                Item tarefa = t.DataContext as Item;
                tarefa.Excluir();
                AtualizarTarefas();
            }
        }

        private void ToDo_Click(object sender, RoutedEventArgs e)
        {
            var t = sender as CheckBox;
            if (t != null)
            {
                Item item = t.DataContext as Item;
                item.Adicionados();
                AtualizarTarefas();
            }
        }

        private void txtToDo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}