using CustomInput.CustomInputSender.Commands;
using Network;

namespace CustomInput.CustomInputSender
{
    public class CustomInputHandler : ICommand
    {
        private readonly ICommand[] _commands;

        public CustomInputHandler(ICommand[] commands)
        {
            _commands = commands;
        }

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