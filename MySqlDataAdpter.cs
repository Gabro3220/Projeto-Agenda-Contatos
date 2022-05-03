using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ProjetoAgendaContatos
{
    internal class MySqlDataAdpter
    {
        private MySqlCommand cmd;

        public MySqlDataAdpter(MySqlCommand cmd)
        {
            this.cmd = cmd;
        }

        internal void Fill(DataTable contato)
        {
            throw new NotImplementedException();
        }
    }
}