﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoAgendaContatos
{
    class cl_Conexao
    {
        public MySqlConnection con = new MySqlConnection(@"Server=localhost;Port=3306;Database=agenda;User=root;Pwd=");

        public string conectar()
        {

            try
            {
                con.Open();
                return ("Conexão realizada com sucesso!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }


        public string desconectar()
        {
            try
            {
                con.Close();
                return ("Conexão encerrada!");
            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

    }
}
