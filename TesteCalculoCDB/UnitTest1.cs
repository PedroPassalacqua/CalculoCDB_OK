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

        [TestMethod]
        public void TestValorNulo()
        {
            Assert.IsFalse(ConferePreenchimento(null, 5));
        }

        [TestMethod]
        public void TestMesesNulo()
        {
            Assert.IsFalse(ConferePreenchimento(1000, null));
        }

        [TestMethod]
        public void TestPreencheOK()
        {
            Assert.IsTrue(ConferePreenchimento(1000, 5));
        }

        public bool ConferePreenchimento(double? valor_inicial, int? num_meses)
        {
            if (!valor_inicial.HasValue || !num_meses.HasValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ConfereSaida(double? valor_inicial, int? num_meses)
        {
            if (valor_inicial == 1000 && num_meses == 5)
            {
                Calculo esperado = new Calculo();
                esperado.ValorBruto = 1045.8173228640485;
                esperado.Mes = 5;

                Calculo result = CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(1000, 5)[5];

                if (result.ValorBruto == esperado.ValorBruto)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(result.ValorBruto);
                    Console.WriteLine(esperado.ValorBruto);
                    return false;
                }
            }
            throw new NotImplementedException("Please create a test first.");
        }
    }
}