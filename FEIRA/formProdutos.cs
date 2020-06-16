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
        }

        private void habilitaControles(bool status)
        {
            txtDesc.Enabled = status;
            txtVenda.Enabled = status;
            txtCompra.Enabled = status;
            txtVenc.Enabled = status;
            txtForc.Enabled = status;
            txtQtde.Enabled = status;
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
            txtVenc.Text = null;
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
            habilitaControles(true);
            habilitaBotoes(false);

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
           
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
            CAMADAS.MODEL.Produtos produto = new CAMADAS.MODEL.Produtos();
            string msg = "";
            if (lblID.Text == "0")
                msg = "Deseja inserir um novo produto?";
            else msg = "Deseja alterar o produto atual?";
            DialogResult resposta = MessageBox.Show(msg, "Gravar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            limparControle();
            habilitaControles(false);
            habilitaBotoes(true);
        }
    }
}
