using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPECentral.Data.EF5;

namespace CPECentral
{
    internal static class ToolGenerator
    {
        internal static void GenerateMetricHSSDrills()
        {
            const int toolGroupId = 49;
            const string toolDescriptionFormat = "DRILL (M): Ø{0:00.00} HSS JOBBER";
            double[] existingSizes = {5.1d, 3.8d};

            using (var cpe = new CPEUnitOfWork()) {
                for (double i = 0.1; i < 20; i += 0.1) {
                    if (existingSizes.Any(s => Math.Abs(s - i) < 0.05)) {
                        continue;
                    }
                    var newTool = new Tool {
                        Description = string.Format(toolDescriptionFormat, i),
                        ToolGroupId = toolGroupId
                    };

                    cpe.Tools.Add(newTool);
                }

                cpe.Commit();
            }
        }
    }
}