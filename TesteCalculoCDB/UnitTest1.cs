using CalculoCDB;
using System.Drawing;

namespace TesteCalculoCDB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValor1000Meses5()
        {
            Assert.IsTrue(ConfereSaida(1000, 5));
        }

        public bool ConfereSaida(decimal? valor_inicial, int? num_meses)
        {

            if (valor_inicial == 1000 && num_meses == 5)
            {
                Calculo esperado = new Calculo();
                esperado.Valor = 1045.817322864049M;
                esperado.Mes = 5;

                Calculo result = CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(1000, 5)[5];

                if (result.Valor == esperado.Valor)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(result.Valor);
                    Console.WriteLine(esperado.Valor);
                    return false;
                }
            }
            throw new NotImplementedException("Please create a test first.");
        }
    }
}