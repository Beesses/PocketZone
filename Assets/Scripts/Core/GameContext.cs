using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameContext : MonoBehaviour
{
    //List<IAwake> OnAwakeList = new List<IAwake>();
    List<IUpdate> OnUpdateList = new List<IUpdate>();
    List<IFixedUpdate> OnFixedUpdateList = new List<IFixedUpdate>();
    List<ILateUpdate> OnLateUpdateList = new List<ILateUpdate>();

    public void AddToList(BaseService script)
    {
        //OnAwakeList.Add(script);
        OnUpdateList.Add(script);
        OnFixedUpdateList.Add(script);
        OnLateUpdateList.Add(script);
    }

    private void Awake()
    {
        new EntityService(this);
    }

    private void Update()
    {
        foreach (var feature in OnUpdateList)
        {
            feature.OnUpdate();
        }
    }

    private void FixedUpdate()
    {
        foreach (var feature in OnFixedUpdateList)
        {
            feature.OnFixedUpdate();
        }
    }
    private void LateUpdate()
    {
        foreach (var feature in OnLateUpdateList)
        {
            feature.OnLateUpdate();
        }
    }
}