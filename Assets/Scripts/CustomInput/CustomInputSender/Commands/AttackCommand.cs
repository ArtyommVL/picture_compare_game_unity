using Network;
using UnityEngine;

namespace CustomInput.CustomInputSender.Commands
{
    public class AttackCommand : ICommand
    {
        public UserInputField Execute()
        {
            return Input.GetKeyDown(KeyCode.F) 
                ? UserInputField.Attack 
                : (UserInputField)0;
        }
    }
}