using Network;
using UnityEngine;

namespace CustomInput.CustomInputSender.Commands
{
    public class RightCommand : ICommand
    {
        public UserInputField Execute()
        {
            return Input.GetKey(KeyCode.D) 
                ? UserInputField.Right
                : (UserInputField)0;
        }
    }
}