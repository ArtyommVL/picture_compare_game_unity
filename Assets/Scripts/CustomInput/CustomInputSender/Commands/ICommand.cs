using Network;

namespace CustomInput.CustomInputSender.Commands
{
    public interface ICommand
    {
        public UserInputField Execute();
    }
}