using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CalculoCDB.API.Controllers
{
    public class CalculoCdbController : Controller
    {
        [System.Web.Mvc.HttpGet]
        [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
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

        private static double ValorCDI()
        {
            double cdi = 0.9 / 100;
            return cdi;
        }

        private static double ValorTB()
        {
            double tb = 108 / 100;
            return tb;
        }
    }
}