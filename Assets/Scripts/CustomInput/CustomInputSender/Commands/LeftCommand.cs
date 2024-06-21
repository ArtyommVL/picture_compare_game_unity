using Network;
using UnityEngine;

namespace CustomInput.CustomInputSender.Commands
{
    public class LeftCommand : ICommand
    {
        public UserInputField Execute()
        {
            return Input.GetKey(KeyCode.A) 
                ? UserInputField.Left 
                : (UserInputField)0;
        }
    }
}