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
        [SerializeField] private string _description;
        [SerializeField] private Sprite _descriptionSprite;
        
        public ResearchableModel GetResourceModel()
        {
            var result = new ResearchableModel
            {
                ResearchableType = _type,
                ResearchNeed = _researchNeed,
                ResearchConfig = this
            };
            return result;
        }
        
        
        public string Description
        {
            get => _description;
            private set => _description = value;
        }
        
        public Sprite DescriptionSprite
        {
            get => _descriptionSprite;
            private set => _descriptionSprite = value;
        }
    }
}