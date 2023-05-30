namespace Game.State
{
    public interface IAppState
    {
       
        
        public Entities.State GetState();
        public void AddLife();
        
    }
}