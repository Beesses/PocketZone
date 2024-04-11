using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public sealed class EnemyController
{

    private List<EnemyModel> models;
    private SpawnPointsData spawnData;
    Vector3 direction;

    public EnemyController()
    {
        spawnData = (SpawnPointsData)AssetDatabase.LoadAssetAtPath("Assets/Data/Spawn.asset", typeof(SpawnPointsData));
        Debug.Log(spawnData.SpawnPositions);
        models = new List<EnemyModel>();
        models.Add(new EnemyModel((EnemyData)AssetDatabase.LoadAssetAtPath("Assets/Data/Flesh.asset", typeof(EnemyData)), spawnData.SpawnPositions[Random.Range(0, spawnData.SpawnPositions.Capacity)]));
        models.Add(new EnemyModel((EnemyData)AssetDatabase.LoadAssetAtPath("Assets/Data/Zombie.asset", typeof(EnemyData)), spawnData.SpawnPositions[Random.Range(0, spawnData.SpawnPositions.Capacity)]));
        models.Add(new EnemyModel((EnemyData)AssetDatabase.LoadAssetAtPath("Assets/Data/Zombie.asset", typeof(EnemyData)), spawnData.SpawnPositions[Random.Range(0, spawnData.SpawnPositions.Capacity)]));
        models.Add(new EnemyModel((EnemyData)AssetDatabase.LoadAssetAtPath("Assets/Data/Flesh.asset", typeof(EnemyData)), spawnData.SpawnPositions[Random.Range(0, spawnData.SpawnPositions.Capacity)]));
        foreach (var model in models)
        {
            model.MyHealth.Died += model.Died;
            model.Mono.GetDamage += model.MyHealth.TakeDamage;
            model.RemoveModel += Remove;
        }
    }

    public void Updating()
    {
        foreach (var model in models)
        {
            if(model.Mono.CurrentTarget != null)
            {
                model.target = model.Mono.CurrentTarget.gameObject.transform;
                direction = model.target.position - model.Prefab.transform.position;
            }
            else
            {
                model.target = null;
            }
        }
    }

    public void FixedUpdating()
    {
        foreach (var model in models)
        {
            if(model.target != null)
            {
                movement(model);
            }
        }
    }

    private void movement(EnemyModel model)
    {
        model.RB.MovePosition(model.Prefab.transform.position + direction.normalized * model.Speed * Time.fixedDeltaTime);
    }

    private void dropItem(Transform pos)
    {
        new ItemModel(pos);
    }

    private void Remove(EnemyModel model)
    {
        Debug.Log(model.Prefab.name);
        model.MyHealth.Died -= model.Died;
        model.Mono.GetDamage -= model.MyHealth.TakeDamage;
        model.RemoveModel -= Remove;
        dropItem(model.Prefab.transform);
        GameObject.Destroy(model.Prefab);
        models.Remove(model);
    }
}
