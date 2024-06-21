using Network;
using UnityEngine;

namespace CustomInput.CustomInputSender.Commands
{
    public class MoveForwardCommand : ICommand
    {
        public UserInputField Execute()
        {
            return Input.GetKey(KeyCode.W) 
                ? UserInputField.Forward 
                : (UserInputField)0;
        }
    }
}