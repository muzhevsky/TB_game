namespace Internal.Utils
{
    public interface IUpdatable
    {
        void Activate();
        void Update();
        void StopUpdate();
    }
}