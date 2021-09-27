using Code.GameController;

namespace Code.UserInput
{
    public sealed class InputController :
        ILogicUpdatable
    {
        public IUserInput UserInput { get; private set; }

        public InputController(IUserInput userInput)
        {
            UserInput = userInput;
        }

        public void Update(float delta)
        {
            UserInput.GetInput();
        }
    }
}