using CustomInput.CustomInputSender.Commands;
using Network;

namespace CustomInput.CustomInputSender
{
    public class CustomInputHandler : ICommand, ICustomInput
    {
        private readonly ICommand[] _commands;

        public CustomInputHandler()
        {
            _commands = new ICommand[]
            {
                new AttackCommand(),
                new RightCommand(), new LeftCommand(),
                new MoveForwardCommand(),
                new BackCommand(),
            };
        }

        public UserInputField SetInputValues() 
            => Execute();

        public UserInputField Execute()
        {
            UserInputField commands = 0;

            foreach (var command in _commands)
            {
                commands |= command.Execute();
            }

            return commands;
        }
    }
}