using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpawnSO", menuName = "Data/SpawnPoints")]
public sealed class SpawnPointsData : ScriptableObject
{
    public List<Vector2> SpawnPositions;
}
