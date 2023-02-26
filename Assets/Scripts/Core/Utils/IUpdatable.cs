namespace Core.Utils
{
    public interface IUpdatable
    {
        void Activate();
        void Update();
        void StopUpdate();
    }
}