using UnityEngine;

namespace RWS.State
{
    public class AppState : IAppState
    {
        private Entities.State state;
        
        
        
        public AppState()
        {
            state = new Entities.State();
        }
        
        
        public Entities.State GetState()
        {
            return state;
        }
        
        public void AddLife()
        {
            state.lives++;
            Debug.Log(state.lives);
        }
    }
}