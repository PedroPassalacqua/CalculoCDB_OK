**************************************************************************

             B3 - PROJETO DE AVALIAÇÃO PARA DESENVOLVEDOR

             Diretoria de Desenv. Sistemas de Middle e Back Office
             
**************************************************************************

--------------------------------------------------------------------------

             CANDIDATO: PEDRO LOEWENBERG PASSALACQUA

             EMAIL: PEDROPASSALACQUA@HOTMAIL.COM

             CELULAR: 11 99128-4559

--------------------------------------------------------------------------


INSTRUÇÕES PARA EXECUÇÃO DOS TESTES:

1) Testes do Serviço

- Rodar o projeto CalculoCDB no Visual Studio para subir o serviço

- O Visual Studio deve abrir um browser com o teste pelo swagger

- Para rodar os testes automatizados parar o debug do Visual Studio e executar a opção TEste>Executar todos os testes do menu

2) Testes do app Angular

- Abrir o Visual Studio Code e abrir a pasta CalculoCDB.Angular desta solução no Visual Studio Code 

- Rodar o projeto CalculoCDB no Visual Studio para subir o serviço

- Startar o Debug no Visual Studio Code (F5)

- Aguarde a inicialização

- utilizar a aplicação 

- Para rodar os testes automatizados executar a opção Terminal>New Terminal e digitar o comando "npm test"


********************************************************************************************

        NOTAS DE DESENVOLVIMENTO

Durante o desenvolvimento ocorre erro de integração necessitando habilitar o CORS. 
Devido a isso desenvolvemos primeiramente o projeto API CalculoCDB em .NET 4.7.2, e depois 
reimplementado em .NET 6.0, onde foi possível resolver o problema.
Após o término, Ainda criei o projeto CalculoCDB.API em 4.7.2 para tentar habilitar o CORS 
no 4.7.2 sem sucesso por falta de tempo e falta de informação disponível.
Qualquer forma sendo aceita versão 4.7.2 ou superior, a versão .NET 6.0 é bem posterior por 
esse ponto de vista.

********************************************************************************************