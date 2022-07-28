using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySO/Spawner")]
public class EnemySpawnerSO : ScriptableObject
{
    [SerializeField]
    public List<EnemyWaveSO> waves;
}
