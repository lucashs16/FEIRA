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
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
        }

        private void movimentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formClientes formCli = new formClientes();
            formCli.MdiParent = this;
            formCli.Show();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formProdutos formProd = new formProdutos();
            formProd.MdiParent = this;
            formProd.Show();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formSobre formSb = new formSobre();
            formSb.ShowDialog();
        }

        private void formMenu_Load(object sender, EventArgs e)
        {

        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formVendas formVendas = new formVendas();
            formVendas.MdiParent = this;
            formVendas.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RELATORIO.RelGerais.relProduto();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RELATORIO.RelGerais.relClientes();
        }

        private void vendasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RELATORIO.RelGerais.relVendas();
        }

        private void tipoProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTipoProdutos formTipoProdut = new formTipoProdutos();
            formTipoProdut.MdiParent = this;
            formTipoProdut.Show();
        }

    }
}
