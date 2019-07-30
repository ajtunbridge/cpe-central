namespace CPECentral.ViewModels
{
    public class TurnoverTargetViewModel
    {
        public TurnoverTargetViewModel(int currentMonthProgress, int lastMonthProgress, int fiscalYearProgress)
        {
            CurrentMonthProgress = currentMonthProgress;
            LastMonthProgress = lastMonthProgress;
            FiscalYearProgress = fiscalYearProgress;
        }

        public int CurrentMonthProgress { get; private set; }

        public int LastMonthProgress { get; private set; }

        public int FiscalYearProgress { get; private set; }
    }
}