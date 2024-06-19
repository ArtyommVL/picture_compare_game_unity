using Network;
using UnityEngine;

namespace CustomInput.CustomInputSender
{
    public class CustomInputHandler : ICustomInput
    {
        public UserInputField SetInputValues()
        {
            UserInputField inputValue = 0;
            
            if (Input.GetKey(KeyCode.A))
            {
                inputValue |= UserInputField.Left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputValue |= UserInputField.Right;
            }
            if (Input.GetKey(KeyCode.W))
            {
                inputValue |= UserInputField.Forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputValue |= UserInputField.Back;
            }
            if (Input.GetKey(KeyCode.F))
            {
                inputValue |= UserInputField.Attack;
            }
            
            return inputValue;
        }
    }
}