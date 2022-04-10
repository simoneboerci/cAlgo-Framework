namespace cAlgoUnityFramework.Commands
{
    public class PrintErrorMessage : ICommand
    {
        #region Private Variables

        private readonly string _message;

        #endregion

        #region Public Methods

        public PrintErrorMessage(string message) => _message = message;

        public void Execute()
        {
            Console.Error.WriteLine(_message);
        }

        #endregion
    }
}
