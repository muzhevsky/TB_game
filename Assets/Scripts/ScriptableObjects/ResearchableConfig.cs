using DefaultNamespace;
using Internal.Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResearchableConfig")]
    public class ResearchableConfig : ScriptableObject
    {
        [SerializeField] private ResearchableType _type;
        [SerializeField] private float _researchNeed;
        public ResearchableModel GetResourceModel()
        {
            var result = new ResearchableModel
            {
                ResearchableType = _type,
                ResearchNeed = _researchNeed
            };
            return result;
        }
    }
}