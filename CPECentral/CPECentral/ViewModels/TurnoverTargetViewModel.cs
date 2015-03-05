namespace CPECentral.ViewModels
{
    public class TurnoverTargetViewModel
    {
        public TurnoverTargetViewModel(int currentMonthProgress, int lastMonthProgress)
        {
            CurrentMonthProgress = currentMonthProgress;
            LastMonthProgress = lastMonthProgress;
        }

        public int CurrentMonthProgress { get; private set; }

        public int LastMonthProgress { get; private set; }
    }
}