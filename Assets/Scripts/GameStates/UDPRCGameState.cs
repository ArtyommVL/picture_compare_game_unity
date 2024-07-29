using UnityEngine;

namespace GameStates
{
    public class UDPRCGameState : IGameStateMachine
    {
        public void Enter()
        {
            DebugMsg();
        }

        public void DebugMsg()
        {
            Debug.Log("UDPRC");
        }
        
        public void Exit()
        {
        }
    }
}