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
    public partial class formVendas : Form
    {
        public formVendas()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HabilitarBotoes(bool status)
        {
            cmbCliente.Enabled = !status;
            cmbProduto.Enabled = !status;
            dtpData.Enabled = !status;
            txtQuantidade.Enabled = !status;

            btnNovo.Enabled = status;
            btngravar.Enabled = !status;

        }

        private void LimparCampos()
        {
            txtQuantidade.Text = "";
            txtTotal.Text = "";
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formVendas_Load(object sender, EventArgs e)
        {
            HabilitarBotoes(true);

            CAMADAS.BLL.Vendas bllVenda = new CAMADAS.BLL.Vendas();
            dgvVenda.DataSource = "";
            dgvVenda.DataSource = bllVenda.Select();

            CAMADAS.BLL.Clientes bllCli = new CAMADAS.BLL.Clientes();
            cmbCliente.DisplayMember = "nome";
            cmbCliente.ValueMember = "id";
            cmbCliente.DataSource = bllCli.Select();

            CAMADAS.BLL.Produtos bllProdutos = new CAMADAS.BLL.Produtos();
            cmbProduto.DisplayMember = "descricao";
            cmbProduto.ValueMember = "id";
            cmbProduto.DataSource = bllProdutos.Select();
        }

        private void limparVenda()
        {
            lblEmpID.Text = "0";
            dtpData.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtClienteID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtClienteID_Leave(object sender, EventArgs e)
        {

        }

        private void cmbCliente_Leave(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarBotoes(false);
        }

        private void btngravar_Click(object sender, EventArgs e)
        {
            CAMADAS.MODEL.Vendas vendas = new CAMADAS.MODEL.Vendas();
            vendas.clienteId = Convert.ToInt32(cmbCliente.SelectedValue.ToString());
            vendas.produtoId = Convert.ToInt32(cmbProduto.SelectedValue.ToString());
            vendas.dataVenda = dtpData.Value;
            vendas.quantidadeCompra = Convert.ToInt32(txtQuantidade.Text);

            CAMADAS.BLL.Vendas bllVendas = new CAMADAS.BLL.Vendas();
            bllVendas.Insert(vendas);

            MessageBox.Show("Venda inserida com sucesso", "Venda inserida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvVenda.DataSource = "";
            dgvVenda.DataSource = bllVendas.Select();
            HabilitarBotoes(true);
            LimparCampos();
        }

        private void dgvVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "")
            {
                int produtoId = Convert.ToInt32(cmbProduto.SelectedValue);
                int quantidade = Convert.ToInt32(txtQuantidade.Text);

                CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();

                float valorTotal = bllProduto.GetValorTotal(produtoId, quantidade);

                if (valorTotal > -1)
                {
                    txtTotal.Text = valorTotal.ToString();
                }
                else
                {
                    txtQuantidade.Text = "";
                    txtTotal.Text = "";
                    MessageBox.Show("Estoque insuficiente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbProduto_Leave(object sender, EventArgs e)
        {

        }
    }
}
