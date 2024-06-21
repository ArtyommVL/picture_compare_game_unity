using CustomInput.CustomInputSender.Commands;
using Network;

namespace CustomInput.CustomInputSender
{
    public class CustomInputHandler : ICommand, ICustomInput
    {
        private readonly ICommand _moveAttack = new AttackCommand();
        private readonly ICommand _moveRight = new RightCommand();
        private readonly ICommand _moveLeft = new LeftCommand();
        private readonly ICommand _moveForward = new MoveForwardCommand();
        private readonly ICommand _moveBack = new BackCommand();

        public UserInputField SetInputValues()
        {
            return Execute();
        }

        public UserInputField Execute()
        {
            UserInputField commands = 0;
            
            commands |= _moveAttack.Execute();
            commands |= _moveRight.Execute();
            commands |= _moveLeft.Execute();
            commands |= _moveForward.Execute();
            commands |= _moveBack.Execute();

            return commands;
        }
    }
}