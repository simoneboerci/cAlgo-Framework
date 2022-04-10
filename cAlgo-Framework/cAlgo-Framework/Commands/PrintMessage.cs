namespace cAlgoUnityFramework.Commands
{
    public class PrintMessage : ICommand
    {
        #region Private Variables

        private readonly string _message;

        #endregion

        #region Public Methods

        public PrintMessage(string message) => _message = message;  

        public void Execute()
        {
            Console.WriteLine(_message);
        }

        #endregion
    }
}
