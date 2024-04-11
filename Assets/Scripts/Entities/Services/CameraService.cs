using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraService : BaseService
{
    private CameraController controller;
    public CameraService(GameContext context, Transform target)
    {
        context.AddToList(this);
        controller = new CameraController(new CameraModel((CameraData)AssetDatabase.LoadAssetAtPath("Assets/Data/CameraData.asset", typeof(CameraData)), target));
    }

    public override void OnAwake()
    {

    }

    public override void OnUpdate()
    {

    }

    public override void OnFixedUpdate()
    {
        controller.FixedUpdating();
    }

    public override void OnLateUpdate()
    {

    }
}