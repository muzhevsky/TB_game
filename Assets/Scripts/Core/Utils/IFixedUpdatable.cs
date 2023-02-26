namespace Core.Utils
{
    public interface IFixedUpdatable
    {
        void Activate();
        void FixedUpdate();
        void StopUpdate();
    }
}