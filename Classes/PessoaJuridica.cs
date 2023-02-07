using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using prog_backend.Interfaces;

namespace prog_backend.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? cnpj {get;set;}
        //public string? cnpjInfo {get; set;}
        public string? razaoSocial {get;set;}
        public string caminho {get; private set;} = "Database/PessoaJuridica.csv";
        public override float CalcularImposto(float rendimento){

            if (rendimento <= 3000)
            {
                return rendimento*0.03f;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento*0.05f;
            }
            else if (rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento*0.07f;
            }
            else
            {
                return rendimento*0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj){
            // formatos possíveis:
            // xxxxxxxx0001xx     : 14 dígitos
            // xx.xxx.xxx/0001-xx : 18 dígitos

            // para usar o Regex deve ser adicionado 'using System.Text.RegularExpressions;'

            bool retornoCnpjValido = Regex.IsMatch(cnpj,@"(^(\d{14}) | (\d{2}.\d{3}.\d{3}/\d{4}-\d{2})$)");

            // o símbolo '@' indica que os caracteres seguintes são do tipo string
            //  ^\d{14}$ --> verificar se tem 14 dígitos decimais ininterruptos

            if (retornoCnpjValido)
            {
                string substringCnpj14 = cnpj.Substring(8,4);

                // Substring(8,4) --> bypassa os 8 primeiros dígitos e analisa os 4 seguintes

                if (substringCnpj14 == "0001")
                {
                    return true;
                }
            }

            string substringCnpj18 = cnpj.Substring(11,4);

                if (substringCnpj18 == "0001")
                {
                    return true;
                }

            return false;

            // sem este último "return false" a funçâo dá erro
        }

        public void Inserir(PessoaJuridica pj)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pj.razaoSocial}, {pj.cnpj}, {pj.rendimento}, {pj.endereco.logradouro}, {pj.endereco.numero}, {pj.endereco.complemento}, {pj.endereco.endComercial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {
            VerificarPastaArquivo(caminho);
            
            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPJ = new PessoaJuridica();
                Endereco cadaEnd = new Endereco();

                cadaPJ.razaoSocial = atributos[0];
                cadaPJ.cnpj = atributos[1];
                cadaPJ.rendimento = float.Parse(atributos[2]);
                cadaEnd.logradouro = atributos[3];
                cadaEnd.numero = int.Parse(atributos[4]);
                cadaEnd.complemento = atributos[5];
                cadaEnd.endComercial = bool.Parse(atributos[6]);
                cadaPJ.endereco = cadaEnd;
                listaPJ.Add(cadaPJ);
            }

            return listaPJ;
        }
    }
}