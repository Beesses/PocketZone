using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerService : BaseService
{

    private PlayerController playerController;
    private CameraService cameraService;
    private InventoryController inventoryController;

    public PlayerService(GameContext context)
    {
        context.AddToList(this);
        inventoryController = new InventoryController();
        playerController = new PlayerController(inventoryController);
        cameraService = new CameraService(context, playerController.Target());
    }

    public override void OnAwake()
    {

    }
    public override void OnUpdate()
    {
        playerController.Updating();
    }

    public override void OnFixedUpdate()
    {
        playerController.FixedUpdating();
    }


    public override void OnLateUpdate()
    {

    }
}
