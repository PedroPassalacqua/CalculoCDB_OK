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

        [TestMethod]
        public void TestAliquota()
        {
            Assert.IsTrue(ConfereAliquotaImposto(50));
        }

        public bool ConferePreenchimento(double? valor_inicial, int? num_meses)
        {
            if (CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(valor_inicial, num_meses).Count == 0)
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

                Calculo result = CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(1000, 5)[4];

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

        public bool ConfereAliquotaImposto(int meses)
        {
            double aliq = 0;
            bool retorno = false;
            for (int mes = 1; mes <meses; mes++){
                aliq = CalculoCDB.Controllers.CalculoCdbController.AliquotaImposto(mes);
                if (mes <= 06)
                {
                    retorno = aliq == (22.5 / 100)?true:false;
                }
                else
                {
                    if (mes > 06 && mes <= 12)
                    {
                        retorno = aliq == (20 / 100) ? true : false;
                    }
                    else
                    {
                        if (mes > 12 && mes <= 24)
                        {
                            retorno = aliq == (17.5 / 100) ? true : false;
                        }
                        else
                        {
                            retorno = aliq == 0.15 ? true : false;
                        }
                    }
                }
            }
            return retorno;
        }

        public bool ConfereValores(double? valor_inicial, int? num_meses)
        {
            if (valor_inicial == 1000 && num_meses == 5)
            {
                Calculo esperado = new Calculo();
                esperado.ValorBruto = 1045.8173228640485;
                esperado.Mes = 5;

                Calculo result = CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(1000, 5)[4];

                if (result.ValorLiquido == ((esperado.ValorBruto - (double)esperado.ValorBruto) * CalculoCDB.Controllers.CalculoCdbController.AliquotaImposto(esperado.Mes)))
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