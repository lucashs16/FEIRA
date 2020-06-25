using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEIRA.CAMADAS;

namespace FEIRA.RELATORIO
{
    public class RelGerais
    {
        public static void relProduto()
        {
            CAMADAS.BLL.Produtos bllProduto = new CAMADAS.BLL.Produtos();
            List<CAMADAS.MODEL.Produtos> lstProdutos = new List<CAMADAS.MODEL.Produtos>();
            lstProdutos = bllProduto.Select();

            string pasta = Funcoes.diretorioPasta();
            string arquivo = pasta + @"\RelProduto_"+DateTime.Now.ToShortDateString().Replace("/","_")+"_"+ DateTime.Now.ToLongTimeString().Replace(":","_")+".html";
            StreamWriter sw = new StreamWriter(arquivo);
            using (sw)
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv='Content-Type' " +
                             "content='text/html; charset=utf-8'/>");
                sw.WriteLine(@"<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css' integrity='ha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk' crossorigin='anonymous'>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<h1>Relatório de Produtos</h1>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<table class='table table-striped'>");
                //Cabeçalho da tabela
                sw.WriteLine("<tr>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("ID");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("DESCRIÇÃO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("VALOR_VENDA");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("VALOR_COMPRA");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("VENCIMENTO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("FORNECEDOR");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("QUANTIDADE");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");

                int cont = 0;

                foreach (CAMADAS.MODEL.Produtos produto in lstProdutos.OrderBy(o => o.id))
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(produto.id);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(produto.descricao);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(produto.valor_venda);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(produto.valor_compra);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(produto.vencimento);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(produto.fornecedor);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='300px'>");
                    sw.WriteLine(produto.quantidade);
                    sw.WriteLine("</td>");
                    sw.WriteLine("</tr>");
                    cont++;
                }

                sw.WriteLine("</table>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<h3>");
                sw.WriteLine("Total de Produtos Cadastrados: " + cont.ToString());
                sw.WriteLine("</h3>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arquivo);
        }

        public static void relVendas()
        {
            CAMADAS.BLL.Vendas bllVenda = new CAMADAS.BLL.Vendas();
            List<CAMADAS.MODEL.Vendas> lstVendas = new List<CAMADAS.MODEL.Vendas>();
            lstVendas = bllVenda.Select();

            string pasta = Funcoes.diretorioPasta();
            string arquivo = pasta + @"\RelVendas_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".html";
            StreamWriter sw = new StreamWriter(arquivo);
            using (sw)
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv='Content-Type' " +
                             "content='text/html; charset=utf-8'/>");
                sw.WriteLine(@"<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css' integrity='ha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk' crossorigin='anonymous'>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<h1>Relatório de Vendas</h1>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<table class='table table-striped'>");
                //Cabeçalho da tabela
                sw.WriteLine("<tr>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("ID");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("DATA");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("QUANTIDADE");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("VALOR UNITARIO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("VALOR TOTAL");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");

                int cont = 0;
                float valorVenda = 0;

                foreach (CAMADAS.MODEL.Vendas venda in lstVendas.OrderBy(o => o.dataVenda))
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(venda.id);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(venda.dataVenda.ToShortDateString());
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(venda.quantidadeCompra);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(venda.valorProduto);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(venda.valorProduto * venda.quantidadeCompra);
                    sw.WriteLine("</td>");
                    sw.WriteLine("</tr>");
                    cont++;
                    valorVenda = valorVenda + (venda.valorProduto * venda.quantidadeCompra);
                }

                sw.WriteLine("</table>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<h3>");
                sw.WriteLine("Total de Vendas realizadas: " + cont.ToString());
                sw.WriteLine("<br>");
                sw.WriteLine("Total de Valor de Venda Total: " + valorVenda.ToString());
                sw.WriteLine("</h3>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arquivo);
        }

        public static void relClientes()
        {
            CAMADAS.BLL.Clientes bllCliente = new CAMADAS.BLL.Clientes();
            List<CAMADAS.MODEL.Clientes> lstClientes = new List<CAMADAS.MODEL.Clientes>();
            lstClientes = bllCliente.Select();

            string pasta = Funcoes.diretorioPasta();
            string arquivo = pasta + @"\RelCliente_" + DateTime.Now.ToShortDateString().Replace("/", "_") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "_") + ".html";
            StreamWriter sw = new StreamWriter(arquivo);
            using (sw)
            {
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv='Content-Type' " +
                             "content='text/html; charset=utf-8'/>");
                sw.WriteLine(@"<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css' integrity='ha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk' crossorigin='anonymous'>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<h1>Relatório de Produtos</h1>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<table class='table table-striped'>");
                //Cabeçalho da tabela
                sw.WriteLine("<tr>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("ID");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("NOME");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("RUA");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("NUMERO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("CIDADE");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("ESTADO");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("CPF");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("TELEFONE");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("E-mail");
                sw.WriteLine("</th>");
                sw.WriteLine("<th align='right' width='180px'>");
                sw.WriteLine("Nascimento");
                sw.WriteLine("</th>");
                sw.WriteLine("</tr>");

                int cont = 0;

                foreach (CAMADAS.MODEL.Clientes cliente in lstClientes.OrderBy(o => o.id))
                {
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(cliente.id);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(cliente.nome);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(cliente.rua);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(cliente.numero);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(cliente.cidade);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='180px'>");
                    sw.WriteLine(cliente.estado);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='300px'>");
                    sw.WriteLine(cliente.cpf);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='300px'>");
                    sw.WriteLine(cliente.telefone);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='300px'>");
                    sw.WriteLine(cliente.email);
                    sw.WriteLine("</td>");
                    sw.WriteLine("<td align='left' width='300px'>");
                    sw.WriteLine(cliente.nascimento);
                    sw.WriteLine("</td>");
                    sw.WriteLine("</tr>");
                    cont++;
                }

                sw.WriteLine("</table>");
                sw.WriteLine("<hr align='left' border:'5px' />");
                sw.WriteLine("<h3>");
                sw.WriteLine("Total de Clientes Cadastrados: " + cont.ToString());
                sw.WriteLine("</h3>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
            }
            System.Diagnostics.Process.Start(arquivo);
        }
    }
}
