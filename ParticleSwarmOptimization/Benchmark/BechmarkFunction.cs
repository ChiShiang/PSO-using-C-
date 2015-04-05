using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSO;

namespace Benchmark
{
    class BenchmarkFunction
    {
        public double AckleyFunction(double[] present)
        {
            double result, subeq1 = 0, subeq2 = 0, constant = 1.0 / present.Length;
            for (int i = 0; i < present.Length; i++)
            {
                subeq1 += Math.Pow(present[i], 2);
                subeq2 += Math.Cos(2 * Math.PI * present[i]);
            }
            subeq1 = 20 * Math.Exp(-0.2 * Math.Sqrt(constant * subeq1));
            subeq2 = Math.Exp(constant * subeq2);
            result = 20 + Math.Exp(1) - subeq1 - subeq2;
            return result;
        }
        public bool AckleyFunctionTarget()
        {
            // target is maximum return true, else return false
            return false;
        }
        //-----------------------------------------------------------------------
        public double CrossInTrayFunction(double[] present)
        {
            double result, eq;
            eq = Math.Abs(Math.Sin(present[0]) * Math.Sin(present[1]) * Math.Exp(Math.Abs(100 - (Math.Sqrt(Math.Pow(present[0], 2) + Math.Pow(present[1], 2)) / Math.PI)) + 1));
            result = -0.0001 * Math.Pow(eq, 0.1);
            return result;
        }
        public bool CrossInTrayFunctionTarget()
        {
            return false;
        }
        //-----------------------------------------------------------------------
        public double EggholderFunction(double[] present)
        {
            double result, eq1, eq2;
            eq1 = -(present[1] + 47) * Math.Sin(Math.Sqrt(Math.Abs(present[1] + (present[0] / 2.0) + 47)));
            eq2 = present[0] * Math.Sin(Math.Sqrt(Math.Abs(present[0] - (present[1] + 47))));
            result = eq1 - eq2;
            return result;
        }
        public bool EggholderFunctionTarget()
        {
            return true;
        }
        //-----------------------------------------------------------------------

    }
}
