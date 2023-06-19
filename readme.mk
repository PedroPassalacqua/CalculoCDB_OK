**************************************************************************

             B3 - PROJETO DE AVALIA��O PARA DESENVOLVEDOR

             Diretoria de Desenv. Sistemas de Middle e Back Office
             
**************************************************************************

--------------------------------------------------------------------------

             CANDIDATO: PEDRO LOEWENBERG PASSALACQUA

             EMAIL: PEDROPASSALACQUA@HOTMAIL.COM

             CELULAR: 11 99128-4559

--------------------------------------------------------------------------


INSTRU��ES PARA EXECU��O DOS TESTES:

1) Testes do Servi�o

- Rodar o projeto CalculoCDB no Visual Studio para subir o servi�o

- O Visual Studio deve abrir um browser com o teste pelo swagger

- Para rodar os testes automatizados parar o debug do Visual Studio e executar a op��o TEste>Executar todos os testes do menu

2) Testes do app Angular

- Abrir o Visual Studio Code e abrir a pasta CalculoCDB.Angular desta solu��o no Visual Studio Code 

- Rodar o projeto CalculoCDB no Visual Studio para subir o servi�o

- Startar o Debug no Visual Studio Code (F5)

- Aguarde a inicializa��o

- utilizar a aplica��o 

- Para rodar os testes automatizados executar a op��o Terminal>New Terminal e digitar o comando "npm test"


********************************************************************************************

        NOTAS DE DESENVOLVIMENTO

Durante o desenvolvimento ocorre erro de integra��o necessitando habilitar o CORS. 
Devido a isso desenvolvemos primeiramente o projeto API CalculoCDB em .NET 4.7.2, e depois 
reimplementado em .NET 6.0, onde foi poss�vel resolver o problema.
Ap�s o t�rmino, Ainda criei o projeto CalculoCDB.API em 4.7.2 para tentar habilitar o CORS 
no 4.7.2 sem sucesso por falta de tempo e falta de informa��o dispon�vel.
Qualquer forma sendo aceita vers�o 4.7.2 ou superior, a vers�o .NET 6.0 � bem posterior por 
esse ponto de vista.

********************************************************************************************