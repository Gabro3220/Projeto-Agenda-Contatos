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
    public partial class FrmConsulta : Form
    {

        cl_Contato cont = new cl_Contato();
        cl_ControleContato controle = new cl_ControleContato();

        public FrmConsulta()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controle.PreencherTodos();
        }

        private void cbOpcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex < 0)
            {
                textBuscar.Enabled = false;
                btnBuscar.Enabled = false;
                lblOpcao.Text = "";

            }
            else
            {
                textBuscar.Enabled = true;
                lblOpcao.Text = "Digite o " + cbOpcao.Text;
                textBuscar.Clear();
                textBuscar.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbOpcao.SelectedIndex == 0)
            {
                try
                {
                    int codigo = Convert.ToInt32(textBuscar.Text);

                    dataGridView1.DataSource = controle.pesquisaCodigo(codigo);
                }

                catch
                {
                    MessageBox.Show("Digite um valor inteiro para código!");
                    textBuscar.Clear();
                    textBuscar.Focus();
                }
            }
            else
            {

            }
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBuscar.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }
    }
}
