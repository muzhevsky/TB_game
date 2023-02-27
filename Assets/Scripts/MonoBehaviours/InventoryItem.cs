using Dto;
using TMPro;
using UnityEngine;

namespace MonoBehaviours
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text Title;
        [SerializeField] private TMP_Text Amount;

        public void Init(ResourceDto resource, float amount)
        {
            Title.text = resource.Title;
            Amount.text = amount.ToString();
        }
    }
}