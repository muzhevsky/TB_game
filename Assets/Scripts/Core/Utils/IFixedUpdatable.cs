namespace Core.Utils
{
    public interface IFixedUpdatable
    {
        void ActivateFixedUpdate();
        void FixedUpdate();
        void StopFixedUpdate();
    }
}