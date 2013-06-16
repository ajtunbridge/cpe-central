namespace CPECentral
{
    public interface IDialogService
    {
        bool AskQuestion(string question);
        void Notify(string message);
        void ShowError(string errorMessage);
    }
}