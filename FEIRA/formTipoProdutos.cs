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
    public partial class formTipoProdutos : Form
    {
        public formTipoProdutos()
        {
            InitializeComponent();
        }

        private void formTipoProdutos_Load(object sender, EventArgs e)
        {
            habilitaControles(false);
            habilitaBotoes(true);
            CAMADAS.BLL.TipoProdutos bllTipoProduto = new CAMADAS.BLL.TipoProdutos();

            dgvTipoProdutos.DataSource = "";
            dgvTipoProdutos.DataSource = bllTipoProduto.Select();
            limparControle();
        }

        private void limparControle()
        {
            lblID.Text = "0";
            txtDesc.Text = string.Empty;
        }

        private void habilitaControles(bool status)
        {
            txtDesc.Enabled = status;
        }

        private void habilitaBotoes(bool status)
        {
            btnInserir.Enabled = status;
            btnRemover.Enabled = status;
            btnEditar.Enabled = status;
            btnCancelar.Enabled = !status;
            btnGravar.Enabled = !status;
        }



        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

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
            CAMADAS.BLL.TipoProdutos bllTipoProdutos = new CAMADAS.BLL.TipoProdutos();

            if (lblID.Text != "0")
            {
                string msg = "Deseja remover o atual tipo de produto?";
                DialogResult resposta = MessageBox.Show(msg, "Remover", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);
                if (resposta == DialogResult.Yes)
                {
                    int idProduto = Convert.ToInt32(lblID.Text);
                    bllTipoProdutos.Delete(idProduto);
                }
            }
            else MessageBox.Show("Não há dados para remover", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            dgvTipoProdutos.DataSource = "";
            dgvTipoProdutos.DataSource = bllTipoProdutos.Select();
            limparControle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparControle();
            habilitaControles(false);
            habilitaBotoes(true);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            CAMADAS.BLL.TipoProdutos bllTipoProduto = new CAMADAS.BLL.TipoProdutos();
            string msg = "";
            if (lblID.Text == "0")
                msg = "Deseja inserir um novo produto?";
            else msg = "Deseja alterar o produto atual?";
            DialogResult resposta = MessageBox.Show(msg, "Gravar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (resposta == DialogResult.Yes)
            {
                CAMADAS.MODEL.TipoProdutos tipoProduto = new CAMADAS.MODEL.TipoProdutos();
                tipoProduto.id = Convert.ToInt32(lblID.Text);
                tipoProduto.descricao = txtDesc.Text;
                if (lblID.Text == "0")
                    bllTipoProduto.Insert(tipoProduto);
                else bllTipoProduto.Update(tipoProduto);

                MessageBox.Show("Dados Gravados", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Dados Não Gravados", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dgvTipoProdutos.DataSource = "";
            dgvTipoProdutos.DataSource = bllTipoProduto.Select();

            limparControle();
            habilitaControles(false);
            habilitaBotoes(true);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTipoProdutos_DoubleClick(object sender, EventArgs e)
        {
            lblID.Text = dgvTipoProdutos.SelectedRows[0].Cells["id"].Value.ToString();
            txtDesc.Text = dgvTipoProdutos.SelectedRows[0].Cells["descricao"].Value.ToString();
        }
    }
}
