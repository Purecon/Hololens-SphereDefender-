using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemySO/Wave")]
public class EnemyWaveSO : ScriptableObject
{
    public GameObject enemyPrefab;
    public int enemyAmount;
    public bool isTutorial = false;
}
