using TMPro;
using UnityEngine;

namespace MonoBehaviours
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text Title;
        [SerializeField] private TMP_Text Amount;

        public void Init(string resourceName, string amount)
        {
            Title.text = resourceName;
            Amount.text = amount;
        }
    }
}