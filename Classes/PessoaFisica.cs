using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using prog_backend.Interfaces;

namespace prog_backend.Classes
{
    public class PessoaFisica: Pessoa, IPessoaFisica
    {
        public string? cpf {get;set;}
        //public DateTime dataNasc {get;set;}
        public string? dataNascimento {get;set;}
        public string caminho { get; private set; } = "Database/PessoaFisica.csv";
        public override float CalcularImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return (rendimento*0.02f);
            }
            else if (rendimento > 3500 && rendimento <= 6000)
            {
                return (rendimento*0.035f);
            }
            else
            {
                return (rendimento*0.05f);
            }
        }

        public bool ValidarDataNascimento(string dataNasc)
        {   
            DateTime dataConvertida;
            if(DateTime.TryParse(dataNasc, out dataConvertida)){
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays / 365;
                if (anos >= 18){
                    return true;
                }
                return false;  
            } 
            return false; 
        }

        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);

            string[] pfString = {$"{pf.nome}, {pf.cpf}, {pf.dataNascimento}, {pf.rendimento}, {pf.endereco.logradouro}, {pf.endereco.numero}, {pf.endereco.complemento}, {pf.endereco.endComercial}"};

            File.AppendAllLines(caminho, pfString);
        }

        public List<PessoaFisica> Ler()
        {
            VerificarPastaArquivo(caminho);

            List<PessoaFisica> listaPF = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);


            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaFisica cadaPF = new PessoaFisica();
                Endereco cadaEnd = new Endereco();

                cadaPF.nome = atributos[0];
                cadaPF.cpf = atributos[1];
                cadaPF.dataNascimento = atributos[2];
                cadaPF.rendimento = float.Parse(atributos[3]);
                cadaEnd.logradouro = atributos[4];
                cadaEnd.numero = int.Parse(atributos[5]);
                cadaEnd.complemento = atributos[6];
                cadaEnd.endComercial = bool.Parse(atributos[7]);
                cadaPF.endereco = cadaEnd;
                listaPF.Add(cadaPF);
            }
            return listaPF;
        }
    }
}