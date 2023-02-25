using Internal.Controllers;
using UnityEngine.UI;

namespace Views.Interfaces
{
    public interface IPlayerUIView
    {
        IPlayerUIView InitSuitController(IPlayerUIController controller);
        IPlayerUIView InitHPBar(Image bar);
        IPlayerUIView InitBoosterBar(Image bar);
        void DrawHP(float value);
        void DrawBoosterCap(float value);
        void ShowTip(string text);
    }
}