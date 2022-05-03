using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAgendaContatos
{
    public partial class FormContatos : Form
    {

        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();


        public FormContatos()
        {
            InitializeComponent();
        }

        private void limpar()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtCelular.Clear();
            txtEmail.Clear();
            txtEmail.Focus();
           
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Não é permitido cadastro sem um nome!");
            }
            else
            {
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.cadastrar(cont));

                limpar();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Informe o código do registro que deseja alterar!");
            }
            else
            {
                cont.Codcontato = int.Parse(txtCodigo.Text);
                cont.Nome = txtNome.Text;
                cont.Telefone = txtTelefone.Text;
                cont.Celular = txtCelular.Text;
                cont.Email = txtEmail.Text;

                MessageBox.Show(controle.alterar(cont));
                limpar();

            }

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                btnAlterar.Enabled = true;
            }
            else
            {
                btnAlterar.Enabled = false;
            }
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            cont.Codcontato = int.Parse(txtCodigo.Text);
           
            MessageBox.Show(controle.excluir(cont));
            limpar();
            txtCodigo.Clear();
            txtCodigo.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try { 

            cont = controle.buscar(int.Parse(txtCodigo.Text));

            if (cont is null)
            {
                MessageBox.Show("Registro não cadastrado no banco!");
            }
            else
            {
                txtCodigo.Text = cont.Codcontato.ToString();
                txtNome.Text = cont.Nome;
                txtTelefone.Text = cont.Telefone;
                txtCelular.Text = cont.Celular;
                txtEmail.Text = cont.Email;
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void FormContatos_Load(object sender, EventArgs e)
        {

        }
    }
}
