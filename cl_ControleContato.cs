using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ProjetoAgendaContatos
{
    class cl_ControleContato
    {

        cl_Conexao c = new cl_Conexao();


        public string cadastrar(cl_Contato cont)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into tbcontato (nome, telefone, celular, email) values " +
                    "('" + cont.Nome + "', '" + cont.Telefone + "','" + cont.Celular + "', '" + cont.Email + "')", c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro realizado com sucesso!");

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string alterar(cl_Contato cont)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("update tbcontato set nome = '" + cont.Nome + "' , " + "telefone = '" + cont.Telefone + "', " + " celular = '" + cont.Celular + "', " + " email= '" + cont.Email + "'  where codcontato = " + cont.Codcontato + ";", c.con);

                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro alterado com sucesso!");

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public string excluir(cl_Contato cont)
        {
            try
            {

                MySqlCommand cmd = new MySqlCommand("delete from tbcontato where codcontato = " + cont.Codcontato + ";", c.con);
                c.conectar();
                cmd.ExecuteNonQuery();
                c.desconectar();
                return ("Cadastro excluído com sucesso!");

            }
            catch (MySqlException e)
            {
                return (e.ToString());
            }
        }

        public cl_Contato buscar(int codigo)
        {
            cl_Contato cont = new cl_Contato();

            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from tbcontato where codcontato = " + codigo + ";", c.con);
                c.conectar();

                MySqlDataReader objDados = cmd.ExecuteReader();

                if (!objDados.HasRows)
                {
                    return null;
                }
                else
                {
                    objDados.Read();
                    cont.Codcontato = Convert.ToInt32(objDados["codcontato"]);
                    cont.Nome = objDados["nome"].ToString();
                    cont.Telefone = objDados["telefone"].ToString();
                    cont.Celular = objDados["celular"].ToString();
                    cont.Email = objDados["email"].ToString();

                    objDados.Close();

                    return cont;
                }

            }

            catch (MySqlException e)
            {
                throw (e);
            }

            finally
            {
                c.desconectar();
            }

        }

        public DataTable PreencherTodos()
        {
            string sql = "select codcontato as 'Codigo', nome as Nome, telefone as Telefone," + "celular as Celular, email as Email from tbcontato; ";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;

        }
        public DataTable pesquisaCodigo(int codigo)
        {
            string sql = "select codcontato as 'Codigo', nome as Nome, telefone as Telefone," + "celular as Celular, email as Email from tbcontato where codcontato = + codigo +";

            MySqlCommand cmd = new MySqlCommand(sql, c.con);

            c.conectar();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable contato = new DataTable();
            da.Fill(contato);
            c.desconectar();
            return contato;

        }
    }
}
