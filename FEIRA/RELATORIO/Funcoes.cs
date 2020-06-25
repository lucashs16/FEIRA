using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEIRA.RELATORIO
{
    public class Funcoes
    {
        public static string diretorioPasta()
        {
            string pasta = @"c:\RELFEIRA";
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            return pasta;
        }
    }
}
