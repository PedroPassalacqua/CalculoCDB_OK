using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CalculoCDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoCdbController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculo>>> Index(decimal? valor_inicial, int? num_meses)
        {

            return CalculoCDB(valor_inicial, num_meses).ToList();

        }

        public static List<Calculo> CalculoCDB(decimal? valor_inicial, int? num_meses)
        {
            List<Calculo> mesesCalculoCDB = new List<Calculo>();

            if (valor_inicial.HasValue)
            {
                decimal valor_final = (decimal)valor_inicial;
                decimal cdi = ValorCDI();
                decimal tb = ValorTB();

                Calculo mesinicio = new Calculo();
                mesinicio.Mes = 0;
                mesinicio.Valor = valor_final;
                mesesCalculoCDB.Add(mesinicio);
                for (int contador = 1; contador <= num_meses; contador++)
                {
                    valor_final = valor_final * (1 + (cdi * tb));

                    Calculo calculo = new Calculo();
                    calculo.Mes = contador;
                    calculo.Valor = valor_final;
                    mesesCalculoCDB.Add(calculo);
                }
            }

            return mesesCalculoCDB;
        }

        private static decimal ValorCDI()
        {
            decimal cdi = 0.9M / 100;
            return cdi;
        }

        private static decimal ValorTB()
        {
            decimal tb = 108 / 100;
            return tb;
        }
    }
}
