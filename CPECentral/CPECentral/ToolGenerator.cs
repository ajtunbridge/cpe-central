#region Using directives

using CPECentral.Data.EF5;

#endregion

namespace CPECentral
{
    internal static class ToolGenerator
    {
        internal static void GenerateMetricHSSDrills()
        {
            const int toolGroupId = 2;
            const string toolDescriptionFormat = "DRILL (M): Ø{0:00.00} HSS JOBBER";

            using (var cpe = new CPEUnitOfWork()) {
                for (double i = 0.1; i < 20; i += 0.1) {
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