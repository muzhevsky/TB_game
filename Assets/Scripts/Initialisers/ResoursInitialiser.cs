using Core.Controllers.Default;
using Core.Controllers.Interfaces;
using Core.Models;
using Core.Views;
using Core.Views.Interfaces;
using ScriptableObjects.Resources;
using UnityEngine;

namespace Initialisers
{
    public class ResoursInitialiser : MonoBehaviour
    {
        [SerializeField] private ResourceConfig _resourceConfig;
        [SerializeField] private ResearchableConfig _researchableConfig;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            // models
            var resourceModel = _resourceConfig.GetResourceModel();

            var researchableModel = _researchableConfig?.GetResourceModel();

            var objectComponentsModel = new ObjectComponentsModel();
            objectComponentsModel.BuildGameObject(gameObject)
                .BuildTransform(transform)
                .BuildCollider(GetComponent<Collider>());

            //controllers
            IResourceController resourceController =
                new DefaultResourceController(resourceModel, objectComponentsModel);

            IResearchableController researchableController = null;
            if (researchableModel != null)
                researchableController = new DefaultResearchableController(researchableModel);

            //views
            var resourceView = (IResourceView)gameObject.AddComponent(typeof(DefaultResourceView));
            resourceView.Init(resourceController);

            IResearchableView researchableView = null;
            if (researchableController != null)
            {
                researchableView = (IResearchableView)gameObject.AddComponent(typeof(DefaultResearchableView));
                researchableView.Init(researchableController);
            }
        }
    }
}