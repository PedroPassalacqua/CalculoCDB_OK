using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace CalculoCDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoCdbController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculo>>> Index(double? valor_inicial, int? num_meses)
        {

            return CalculoCDB(valor_inicial, num_meses).ToList();

        }

        public static List<Calculo> CalculoCDB(double? valor_inicial, int? num_meses)
        {
            List<Calculo> mesesCalculoCDB = new List<Calculo>();

            if (valor_inicial.HasValue)
            {
                double valor_final = (double)valor_inicial;
                double cdi = ValorCDI();
                double tb = ValorTB();

                Calculo mesinicio = new Calculo();
                mesinicio.Mes = 0;
                mesinicio.ValorBruto = valor_final;
                mesinicio.ValorLiquido = valor_final;

                mesesCalculoCDB.Add(mesinicio);
                for (int contador = 1; contador <= num_meses; contador++)
                {
                    valor_final = valor_final * (1 + (cdi * tb));

                    Calculo calculo = new Calculo();
                    calculo.Mes = contador;
                    calculo.ValorBruto = valor_final;
                    calculo.ValorLiquido = valor_final - ((valor_final- (double)valor_inicial)* AliquotaImposto(contador));

                    mesesCalculoCDB.Add(calculo);
                }
            }

            return mesesCalculoCDB;
        }

        private static double ValorCDI()
        {
            double cdi = (0.9 / 100);
            return cdi;
        }

        private static double ValorTB()
        {
            double tb = (108 / 100);
            return tb;
        }

        private static double AliquotaImposto(int mes)
        {
            if (mes <= 06)
                return (22.5 / 100);
            if (mes > 06 && mes <= 12)
                return (20 / 100);
            if (mes > 12 && mes <= 24)
                return (17.5 / 100);
            return (15 / 100);
        }
    }
}
