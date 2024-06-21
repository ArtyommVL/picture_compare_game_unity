using Network;
using UnityEngine;

namespace CustomInput.CustomInputSender.Commands
{
    public class BackCommand : ICommand
    {
        public UserInputField Execute()
        {
            return Input.GetKey(KeyCode.S) 
                ? UserInputField.Back 
                : (UserInputField)0;
        }
    }
}