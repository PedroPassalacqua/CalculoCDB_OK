﻿using Microsoft.AspNetCore.Mvc;
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
                double aliq = 0;

                for (int contador = 1; contador <= num_meses; contador++)
                {
                    valor_final = valor_final * (1 + (cdi * tb));

                    Calculo calculo = new Calculo();
                    calculo.Mes = contador;
                    calculo.ValorBruto = valor_final;
                    aliq = AliquotaImposto(contador);
                    calculo.ValorLiquido = valor_final - ((double)valor_final * aliq);

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

        public static double AliquotaImposto(int mes)
        {
            if (mes <= 06)
            { 
                return (22.5 / 100); 
            }
            else
            {
                if (mes > 06 && mes <= 12)
                { 
                    return (20 / 100); 
                }
                else
                {
                    if (mes > 12 && mes <= 24)
                    {
                        return (17.5 / 100);
                    }
                    else
                    {
                        return 0.15;
                    }
                }
            }
        }
    }
}
