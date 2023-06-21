using CalculoCDB;
using System.Drawing;

namespace TesteCalculoCDB
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestValorPositivo()
        {
            Assert.IsFalse(ConferePreenchimento(-1000, 5));
        }

        [TestMethod]
        public void TesteMesesMaiorQ1()
        {
            Assert.IsFalse(ConferePreenchimento(1000, 1));
        }

        [TestMethod]
        public void TesteVlLiqMenorQVlBruto()
        {
            Assert.IsTrue(ConfereVlLiqMenorQVlBruto());
        }


        [TestMethod]
        public void TestValor1000Meses5()
        {
            Assert.IsTrue(ConfereSaida());
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

        public bool ConfereVlLiqMenorQVlBruto()
        {
            double valor_inicial = 1000;
            int num_meses = 50;

            Calculo esperado = new Calculo();
            esperado.ValorBruto = 1049.5540120180824;
            esperado.Mes = 5;

            bool retorno = false;

            var res = CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(valor_inicial, num_meses);

            for (int c = 0; c < 50; c++)
            {
                Calculo result = res[c];
                if (result.ValorBruto > result.ValorLiquido)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        public bool ConfereSaida()
        {
            double valor_inicial = 1000;
            int num_meses = 50;

            Calculo esperado5 = new Calculo();
            esperado5.ValorBruto = 1049.5540120180824;
            esperado5.ValorLiquido = 1038.4043593140138;
            esperado5.Mes = 5;

            Calculo esperado10 = new Calculo();
            esperado10.ValorBruto = 1101.5636241432533;
            esperado10.ValorLiquido = 1081.2508993146025;
            esperado10.Mes = 10;

            Calculo esperado15 = new Calculo();
            esperado15.ValorBruto = 1156.1505212127304;
            esperado15.ValorLiquido = 1128.8241800005026;
            esperado15.Mes = 15;

            Calculo esperado25 = new Calculo();
            esperado25.ValorBruto = 1273.5733582022062;
            esperado25.ValorLiquido = 1232.5373544718752;
            esperado25.Mes = 25;

            var result = CalculoCDB.Controllers.CalculoCdbController.CalculoCDB(valor_inicial, num_meses);

            bool retorno = false;

            if (result[4].ValorBruto == esperado5.ValorBruto)
            {
                retorno = true;
            }
            else
            {
                Console.WriteLine("erro mes 5");
                retorno = false;
                return retorno;
            }
            if (result[9].ValorBruto == esperado10.ValorBruto)
            {
                retorno = true;
            }
            else
            {
                Console.WriteLine("erro mes 10");
                retorno = false;
                return retorno;
            }
            if (result[14].ValorBruto == esperado15.ValorBruto)
            {
                retorno = true;
            }
            else
            {
                Console.WriteLine("erro mes 15");
                retorno = false;
                return retorno;
            }
            if (result[24].ValorBruto == esperado25.ValorBruto)
            {
                retorno = true;
            }
            else
            {
                Console.WriteLine("erro mes 25");
                retorno = false;
                return retorno;
            }

            return retorno;
        }

        public bool ConfereAliquotaImposto(int meses)
        {
            double aliq = 0;
            bool retorno = false;
            for (int mes = 1; mes <meses; mes++){
                aliq = CalculoCDB.Controllers.CalculoCdbController.AliquotaImposto(mes);
                if (mes <= 06)
                {
                    retorno = aliq == 0.225?true:false;
                    if (retorno == false)
                    {
                        Console.WriteLine("erro aliq ate 06 meses");
                        return retorno;
                    }
                }
                else
                {
                    if (mes > 06 && mes <= 12)
                    {
                        retorno = aliq == 0.20 ? true : false;
                        if (retorno == false)
                        {
                            Console.WriteLine("erro aliq 07 a 12 meses");
                            return retorno;
                        }
                    }
                    else
                    {
                        if (mes > 12 && mes <= 24)
                        {
                            retorno = aliq == 0.175 ? true : false;
                            if (retorno == false)
                            {
                                Console.WriteLine("erro aliq 13 a 24 meses");
                                return retorno;
                            }
                        }
                        else
                        {
                            retorno = aliq == 0.15 ? true : false;
                            if (retorno == false)
                            {
                                Console.WriteLine("erro aliq maior que 25 meses");
                                return retorno;
                            }
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

                if (result.ValorLiquido == esperado.ValorBruto - (((double)esperado.ValorBruto - (double)valor_inicial) * CalculoCDB.Controllers.CalculoCdbController.AliquotaImposto((int)num_meses)))
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