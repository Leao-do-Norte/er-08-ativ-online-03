using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prog_backend.Interfaces;

namespace prog_backend.Classes
{
    public abstract class Pessoa : IPessoa
    {
        public string? nome {get;set;}
        public float rendimento{get;set;}
        public Endereco? endereco {get;set;}
        public abstract float CalcularImposto (float rendimento);
        public void VerificarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];
            // a string é quebrada exatamente no caractere '/' quando o 'split' é aplicado
            // portanto, as duas novas strings serão armazenadas num array
            // esse array eventualmente terá dois elementos, dessa forma, nas posições 0 e 1
        
            if (!Directory.Exists(pasta))
            // '!' == negação, ou seja, se o diretório não existir
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(caminho))
            {
                using (File.Create(caminho))
                {
                    // o 'File' não possui um método 'close' poranto é necessário utilizar o 'using' 
                    // que por sua vez é capaz de fechar (close) sozinho.
                }
                
            }
        }
    }
}