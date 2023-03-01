using Core.Models;
using Enums;
using UnityEngine;

namespace ScriptableObjects.Resources
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ResearchableConfig")]
    public class ResearchableConfig : ScriptableObject
    {
        [SerializeField] private ResearchableType _type;
        [SerializeField] private float _researchNeed;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _descriptionSprite;


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

        public ResearchableType Type
        {
            get => _type;
            private set => _type = value;
        }

        public float ResearchNeed
        {
            get => _researchNeed;
            private set => _researchNeed = value;
        }

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
    }
}