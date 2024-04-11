using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyService : BaseService
{

    private EnemyController controller;

    public EnemyService(GameContext context)
    {
        context.AddToList(this);
        controller = new EnemyController();
    }

    public override void OnAwake()
    {

    }
    public override void OnUpdate()
    {
        controller.Updating();
    }

    public override void OnFixedUpdate()
    {
        controller.FixedUpdating();
    }


    public override void OnLateUpdate()
    {

    }
}
