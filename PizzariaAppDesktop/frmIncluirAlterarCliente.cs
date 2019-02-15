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
    public partial class frmIncluirAlterarCliente : Form
    {
        Cliente cliente;
        public frmIncluirAlterarCliente()
        {
            InitializeComponent();
        }

        public frmIncluirAlterarCliente(Cliente cliente = null)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void lblCpf_Click(object sender, EventArgs e)
        {

        }

        private void frmIncluirAlterarCliente_Load(object sender, EventArgs e)
        {
            if(cliente != null)
            {
                txtNome.Text = cliente.Nome;
                txtCpf.Text = cliente.Cpf;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (cliente == null)
            {
                Cliente cliente = new Cliente()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text
                };
                ClienteDAO clienteDAO = new ClienteDAO();
                clienteDAO.IncluirCliente(cliente);
            }
            else
            {
                cliente.Nome = txtNome.Text;
                cliente.Cpf = txtCpf.Text;
                ClienteDAO clienteDAO = new ClienteDAO();
                clienteDAO.AlterarCliente(cliente);
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
