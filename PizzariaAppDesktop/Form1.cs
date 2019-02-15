using PizzariaAppDesktop.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzariaAppDesktop
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void CarregarQuantidadeClientes()
        {
            ClienteDAO clienteDao = new ClienteDAO();
            int numClientes = clienteDao.ContarClientes();
            stsNumeroClientes.Text = numClientes.ToString()+" Clientes";
        }
        private void CarregarDataGridView()
        {
            ClienteDAO cliDAO = new ClienteDAO();
            DataTable clientes = cliDAO.GetClientes();
            dgvClientes.DataSource = clientes;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CarregarDataGridView();
            CarregarQuantidadeClientes();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            frmIncluirAlterarCliente janela = new frmIncluirAlterarCliente();
            janela.ShowDialog();
            CarregarDataGridView();
            CarregarQuantidadeClientes();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value),
                Nome = dgvClientes.CurrentRow.Cells[1].Value.ToString(),
                Cpf = dgvClientes.CurrentRow.Cells[2].Value.ToString()
            };
            frmIncluirAlterarCliente janela = new frmIncluirAlterarCliente(cliente);
            janela.ShowDialog();
            CarregarDataGridView();
            CarregarQuantidadeClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);
            string nome = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show("Deseja excluir o(a) cliente "+ nome + " ?", "Pergunta", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                ClienteDAO clienteDAO = new ClienteDAO();
                clienteDAO.ExcluirCliente(id);
            }
            CarregarDataGridView();
            CarregarQuantidadeClientes();
        }
    }
}
