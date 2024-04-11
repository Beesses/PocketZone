using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EntityService : BaseService
{

    public EntityService(GameContext context)
    {
        context.AddToList(this);
        new PlayerService(context);
        new EnemyService(context);
    }
    public override void OnAwake()
    {

    }
    public override void OnUpdate()
    {

    }

    public override void OnFixedUpdate()
    {

    }


    public override void OnLateUpdate()
    {

    }
}
