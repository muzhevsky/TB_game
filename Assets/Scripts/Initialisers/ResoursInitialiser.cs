using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Initialisers;
using Internal.Controllers;
using Internal.Models;
using Internal.Views.Interfaces;
using ScriptableObjects;
using UnityEngine;
using Views;

public class ResoursInitialiser : MonoBehaviour, IInitialiser
{
    [SerializeField] private ResourceConfig _resourceConfig;
    [SerializeField] private ResearchableConfig _researchableConfig;
    void Start()
    {
        Init();
    }

    public void Init()
    {
        // models
        ResourceModel resourceModel = _resourceConfig.GetResourceModel();
        
        ResearchableModel researchableModel = _researchableConfig?.GetResourceModel();
        
        ObjectComponentsModel objectComponentsModel = new ObjectComponentsModel();
        objectComponentsModel.BuildGameObject(gameObject)
            .BuildTransform(transform)
            .BuildCollider(GetComponent<Collider>());

        //controllers
        IResourceController resourceController = new DefaultResourceController(resourceModel, objectComponentsModel);
        
        IResearchableController researchableController = null;
        if (researchableModel != null)
            researchableController = new DefaultResearchableController(researchableModel);
        
        //views
        IResourceView resourceView = (IResourceView)gameObject.AddComponent(typeof(DefaultResourceView));
        resourceView.InitResourceController(resourceController);
        
        IResearchableView researchableView = null;
        if (researchableController != null)
        {
            researchableView = (IResearchableView)gameObject.AddComponent(typeof(DefaultResearchableView));
            researchableView.InitResearchableController(researchableController);
        }
        
    }
}
