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
    public partial class formProdutos : Form
    {
        public formProdutos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            habilitaControles(false);
            habilitaBotoes(true);
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();

            CAMADAS.BLL.TipoProdutos bllTipoProduto = new CAMADAS.BLL.TipoProdutos();
            cmbTipoProduto.DisplayMember = "descricao";
            cmbTipoProduto.ValueMember = "id";
            cmbTipoProduto.DataSource = bllTipoProduto.Select();

            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProduto.Select();
            limparControle();
        }

        private void habilitaControles(bool status)
        {
            txtDesc.Enabled = status;
            txtVenda.Enabled = status;
            txtCompra.Enabled = status;
            dtpVencimento.Enabled = status;
            txtForc.Enabled = status;
            txtQtde.Enabled = status;
            cmbTipoProduto.Enabled = status;
        }

        private void habilitaBotoes(bool status)
        {
            btnInserir.Enabled = status;
            btnRemover.Enabled = status;
            btnEditar.Enabled = status;
            btnCancelar.Enabled = !status;
            btnGravar.Enabled = !status;
        }

        private void limparControle()
        {
            lblID.Text = "0";
            txtDesc.Text = string.Empty;
            txtVenda.Text = null;
            txtCompra.Text = null;
            dtpVencimento.Text = null;
            txtForc.Text = null;
            txtQtde.Text = null;

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            limparControle();
            habilitaControles(true);
            habilitaBotoes(false);
            txtDesc.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "0")
            {
                habilitaControles(true);
                habilitaBotoes(false);
                txtDesc.Focus();
            }
            else MessageBox.Show("Não há dados para atualizar", "Atualizar", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();

            if (lblID.Text != "0")
            {
                string msg = "Deseja remover o atual produto?";
                DialogResult resposta = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                if (resposta == DialogResult.Yes)
                {
                    int idProduto = Convert.ToInt32(lblID.Text);
                    bllProduto.Delete(idProduto);
                }
            }
            else MessageBox.Show("Não há dados para remover", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProduto.Select();
            limparControle();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            limparControle();
            habilitaControles(false);
            habilitaBotoes(true);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
            string msg = "";
            if (lblID.Text == "0")
                msg = "Deseja inserir um novo produto?";
            else msg = "Deseja alterar o produto atual?";
            DialogResult resposta = MessageBox.Show(msg, "Gravar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resposta == DialogResult.Yes)
            {
                CAMADAS.MODEL.Produtos produto = new CAMADAS.MODEL.Produtos();
                produto.id = Convert.ToInt32(lblID.Text);
                produto.descricao = txtDesc.Text;
                produto.valor_venda = Convert.ToSingle(txtVenda.Text);
                produto.valor_compra = Convert.ToSingle(txtCompra.Text);
                produto.vencimento = dtpVencimento.Value;
                produto.fornecedor = txtForc.Text;
                produto.quantidade = Convert.ToInt32(txtQtde.Text);
                produto.tipoProdutoId = Convert.ToInt32(cmbTipoProduto.SelectedValue);
                if (lblID.Text == "0")
                    bllProduto.Insert(produto);
                else bllProduto.Update(produto);

                MessageBox.Show("Dados Gravados", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Dados Não Gravados", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = bllProduto.Select();

            limparControle();
            habilitaControles(false);
            habilitaBotoes(true);
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            lblID.Text = dgvProdutos.SelectedRows[0].Cells["id"].Value.ToString();
            txtDesc.Text = dgvProdutos.SelectedRows[0].Cells["descricao"].Value.ToString();
            txtVenda.Text = dgvProdutos.SelectedRows[0].Cells["valor_venda"].Value.ToString();
            txtCompra.Text = dgvProdutos.SelectedRows[0].Cells["valor_compra"].Value.ToString();
            dtpVencimento.Value = Convert.ToDateTime(dgvProdutos.SelectedRows[0].Cells["vencimento"].Value);
            txtForc.Text = dgvProdutos.SelectedRows[0].Cells["fornecedor"].Value.ToString();
            txtQtde.Text = dgvProdutos.SelectedRows[0].Cells["quantidade"].Value.ToString();
            int tipoProdutoId = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells["tipoProdutoId"].Value.ToString());
            cmbTipoProduto.SelectedValue = tipoProdutoId;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            gpbPesquisa.Visible = !gpbPesquisa.Visible;
        }

        private void rdbID_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltrar.Text = "Informe o ID: ";
            txtFiltro.Text = "";
            lblFiltrar.Visible = true;
            txtFiltro.Visible = true;
            txtFiltro.Focus();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltrar.Visible = false;
            txtFiltro.Visible = false;
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
            List<CAMADAS.MODEL.Produtos> lstProduto = new List<CAMADAS.MODEL.Produtos>();
            lstProduto = bllProduto.Select();
            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = lstProduto;
        }

        private void rdbDescricao_CheckedChanged(object sender, EventArgs e)
        {
            lblFiltrar.Text = "Informe a Descrição";
            txtFiltro.Text = string.Empty;
            lblFiltrar.Visible = true;
            txtFiltro.Visible = true;
            txtFiltro.Focus();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
            List<CAMADAS.MODEL.Produtos> lstProduto = new List<CAMADAS.MODEL.Produtos>();
            if (rdbTodos.Checked)
                lstProduto = bllProduto.Select();
            else if (rdbDescricao.Checked)
                lstProduto.Add(bllProduto.SelectByDescricao(txtFiltro.Text));
            else
            {
                int id = Convert.ToInt32(txtFiltro.Text);
                lstProduto.Add(bllProduto.SelectByID(id));
            }

            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = lstProduto;
        }
    }
}
