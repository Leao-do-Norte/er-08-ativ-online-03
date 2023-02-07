# PROJETO BACKEND: CADASTRO DE PESSOA FÍSICA E JURÍDICA 🖋️

### DESCRIÇÃO
O cadastro de pessoas físicas conta com os seguintes dados:
 - nome, CPF e data de nascimento;

O cadastro de pessoas jurídicas conta com os seguintes dados:
 - CNPJ e razão social;

Ambos contam também com Endereço e Rendimento.

O sistema é capaz de armazenar os dados salvos em arquivos, nesse caso, em formato .csv

### TECNOLOGIAS
 - C#
 - .NET

### FUNCIONALIDADES
 - Sistema para validação de CNPJ e data de nascimento;
 - Cálculo de imposto de acordo com o rendimento.

### BUGS
 - Por alguma razão o programa não aceita a string do logradouro e não é possível executar a opção 2 - mostrar a pessoa física cadastrada.
Aparecendo a seguinte mensagem de erro no terminal:
    
    _Unhandled exception. System.FormatException: The input string ' xxxx' was not in a correct format._
 - Validação de data de nascimento pode apresentar erro se o cadastrado tiver 17 anos, 11 meses + alguns dias.
  (O sistema valida como maior de idade). Provavelmente se deve ao fato de estarmos trabalhando com o formato _string_ ao invés de _DateTime_.
    
### PRÉ-REQUISITOS DE INSTALAÇÃO
 - Visual Studio Code (ou outro aplicativo para edição de código-fonte);
 - .NET na versão estável mais atualizada.

### EXECUÇÃO DA APLICAÇÃO
 - Utilizando o VS Code: _Terminal_ > _Novo Terminal_ > _$ dotnet run_

### CONTRIBUIDORES
 - Ângelo Tavares (aluno/autor)
 - Luiz Lozano (professor)
