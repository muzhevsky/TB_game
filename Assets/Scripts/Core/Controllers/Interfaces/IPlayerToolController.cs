
using System;

namespace Core.Controllers.Interfaces
{
    public interface IPlayerToolController
    {
        void SecondaryAction();
        void PrimaryAction();
        event Action<string> OnError;
    }
}