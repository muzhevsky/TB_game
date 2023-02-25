using DefaultNamespaceasd;
using Dto;
using Internal.Controllers;
using MonoBehaviours;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Interfaces
{
    public interface IPlayerUIView
    {
        IPlayerUIView InitSuitController(IPlayerUIController controller);
        IPlayerUIView InitHPBar(Image bar);
        IPlayerUIView InitBoosterBar(Image bar);
        IPlayerUIView InitBatteryBar(Image bar);
        IPlayerUIView InitWarningText(Text text);
        IPlayerUIView InitTip(Tip tip);

        void DrawHP(float value);
        void DrawBoosterCap(float value);
        void DrawBattery(float value);
        void DrawError(string text);
        void ShowTip(TipDto tipDto);
    }
}