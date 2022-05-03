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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            cl_Conexao con = new cl_Conexao();
            MessageBox.Show(con.conectar());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContatos contatos = new FormContatos();
            contatos.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cl_Conexao con = new cl_Conexao();

            MessageBox.Show(con.conectar());
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsulta consulta = new FrmConsulta();
            consulta.ShowDialog();
        }
    }
}
