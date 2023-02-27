namespace Core.Utils
{
    public interface IUpdatable
    {
        void ActivateUpdate();
        void Update();
        void StopUpdate();
    }
}