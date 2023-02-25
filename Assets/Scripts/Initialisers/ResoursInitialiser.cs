using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Initialisers;
using Internal.Controllers;
using Internal.Models;
using ScriptableObjects;
using UnityEngine;

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
        
        //controllers
        IResourceController resourceController = new DefaultResourceController();
    }
}
