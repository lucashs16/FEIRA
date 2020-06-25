using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FEIRA
{
    public partial class formClientes : Form
    {
        public formClientes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CAMADAS.DAL.Clientes dalCli = new CAMADAS.DAL.Clientes();
            dtGrvClientes.DataSource = dalCli.Select();
            habilitaBotoes(true);
            habilitarControles(false);
        }


        private void limparCampos()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            txtCpf.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
        }

        private void habilitaBotoes(bool status)
        {
            btnInserir.Enabled = status;
            btnRemover.Enabled = status;
            btnEditar.Enabled = status;
            btnCancelar.Enabled = !status;
            btnGravar.Enabled = !status;
        }

        private void habilitarControles(bool status)
        {
            txtNome.Enabled = status;
            txtRua.Enabled = status;
            txtNumero.Enabled = status;
            txtCidade.Enabled = status;
            txtEstado.Enabled = status;
            txtCpf.Enabled = status;
            txtTelefone.Enabled = status;
            txtEmail.Enabled = status;
            dtpNascimento.Enabled = status;
        }



        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGrvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dtGrvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtGrvClientes.SelectedRows.Count > 0)
            {
                txtID.Text = dtGrvClientes.SelectedRows[0].Cells[0].Value.ToString();
                int id = Convert.ToInt32(txtID.Text);
                CAMADAS.DAL.Clientes dalCli = new CAMADAS.DAL.Clientes();
                CAMADAS.MODEL.Clientes cliente = dalCli.SelectByID(id);
                txtNome.Text = cliente.nome;
                txtRua.Text = cliente.rua;
                txtNumero.Text = Convert.ToString(cliente.numero);
                txtCidade.Text = cliente.cidade;
                txtEstado.Text = cliente.estado;
                txtCpf.Text = cliente.cpf;
                txtTelefone.Text = cliente.telefone;
                txtEmail.Text = cliente.email;
                dtpNascimento.Value = cliente.nascimento;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                CAMADAS.MODEL.Clientes cliente = new CAMADAS.MODEL.Clientes();
                cliente.id = Convert.ToInt32(txtID.Text);
                cliente.nome = txtNome.Text;
                cliente.rua = txtRua.Text;
                cliente.numero = Convert.ToInt32(txtNumero.Text);
                cliente.cidade = txtCidade.Text;
                cliente.estado = txtEstado.Text;
                cliente.cpf = txtCpf.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.email = txtEmail.Text;
                cliente.nascimento = dtpNascimento.Value;

                CAMADAS.DAL.Clientes dalCli = new CAMADAS.DAL.Clientes();
                dalCli.Update(cliente);

                dtGrvClientes.DataSource = "";
                dtGrvClientes.DataSource = dalCli.Select();

                MessageBox.Show("Cliente Alterado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CAMADAS.MODEL.Clientes cliente = new CAMADAS.MODEL.Clientes();
                cliente.nome = txtNome.Text;
                cliente.rua = txtRua.Text;
                cliente.numero = Convert.ToInt32(txtNumero.Text);
                cliente.cidade = txtCidade.Text;
                cliente.estado = txtEstado.Text;
                cliente.cpf = txtCpf.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.email = txtEmail.Text;
                cliente.nascimento = dtpNascimento.Value;

                CAMADAS.DAL.Clientes dalCli = new CAMADAS.DAL.Clientes();
                dalCli.Insert(cliente);


                dtGrvClientes.DataSource = "";
                dtGrvClientes.DataSource = dalCli.Select();

                MessageBox.Show("Cliente Inserido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            habilitaBotoes(true);
            habilitarControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitaBotoes(true);
            habilitarControles(false);
            limparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            habilitaBotoes(false);
            habilitarControles(true);
            limparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                habilitaBotoes(false);
                habilitarControles(true);
            }
            else
            {
                MessageBox.Show("É necessário selecionar um cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                int idCli = Convert.ToInt32(txtID.Text);

                CAMADAS.DAL.Clientes dalCli = new CAMADAS.DAL.Clientes();
                dalCli.Delete(idCli);

                dtGrvClientes.DataSource = "";
                dtGrvClientes.DataSource = dalCli.Select();


                MessageBox.Show("Cliente Removido!", "Removido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limparCampos();
            }
            else
            {
                MessageBox.Show("É necessário selecionar um cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            gpbPesquisa.Visible = !gpbPesquisa.Visible;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Clientes bllCliente = new CAMADAS.BLL.Clientes();
            List<CAMADAS.MODEL.Clientes> lstCliente = new List<CAMADAS.MODEL.Clientes>();
            if (rdbTodos.Checked)
                lstCliente = bllCliente.Select();
            else if (rdbNome.Checked)
                lstCliente.Add(bllCliente.SelectByNome(txtFiltro.Text));
            else
            {
                int id = Convert.ToInt32(txtFiltro.Text);
                lstCliente.Add(bllCliente.SelectByID(id));
            }

            dtGrvClientes.DataSource = "";
            dtGrvClientes.DataSource = lstCliente;
        }
    }
}
