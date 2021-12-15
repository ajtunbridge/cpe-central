namespace CPECentral.ViewModels
{
    public class TurnoverTargetViewModel
    {
        public TurnoverTargetViewModel(int currentMonthProgress, int lastMonthProgress, int fiscalYearProgress,
            decimal totalTurnoverThisMonth, decimal totalTurnoverLastMonth, decimal totalTurnoverFiscalYear)
        {
            CurrentMonthProgress = currentMonthProgress;
            LastMonthProgress = lastMonthProgress;
            FiscalYearProgress = fiscalYearProgress;
            TotalTurnoverThisMonth = totalTurnoverThisMonth;
            TotalTurnoverLastMonth = totalTurnoverLastMonth;
            TotalTurnoverFiscalYear = totalTurnoverFiscalYear;
        }

        public int CurrentMonthProgress { get; private set; }

        public int LastMonthProgress { get; private set; }

        public int FiscalYearProgress { get; private set; }

        public decimal TotalTurnoverThisMonth { get; private set; }

        public decimal TotalTurnoverLastMonth { get; private set; }

        public decimal TotalTurnoverFiscalYear { get; private set; }
    }
}