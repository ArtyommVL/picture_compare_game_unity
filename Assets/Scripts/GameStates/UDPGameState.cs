using UnityEngine;

namespace GameStates
{
    public class UDPGameState : IGameStateMachine
    {
        public void Enter()
        {
            DebugMsg();
        }

        public void Exit()
        {
        }

        public void DebugMsg()
        {
            Debug.Log("UDP");
        }
    }
}