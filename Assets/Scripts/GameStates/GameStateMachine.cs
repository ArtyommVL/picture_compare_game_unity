using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace GameStates
{
    public class GameStateMachine : IEnumerable<IGameStateMachine>
    {
        private IGameStateMachine[] _states;

        [Inject]
        public void Init(IGameStateMachine[] states)
        {
            _states = states;
            EnterState<MainGameState>();
        }
        
        public IEnumerator<IGameStateMachine> GetEnumerator()
        {
            return (IEnumerator<IGameStateMachine>) _states.GetEnumerator();
        }
        
        public void EnterState<TGameState>() where TGameState : IGameStateMachine
        {
            foreach (IGameStateMachine service in _states)
            {
                if (service is TGameState desired)
                {
                    desired.Enter();
                    break;
                }
            }
        }
        
        /*private IEnumerable<IGameStateMachine> InitializeStates()
        {
            yield return new MainGameState();
            yield return new UDPGameState();
            yield return new UDPRCGameState();
            yield break;
        }*/
        
        public IGameStateMachine[] GetAllStates()
        {
            return _states;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}