using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScoreSO/Score")]
public class ScoreSO : ScriptableObject
{
    public int currentScore;
    public int highScore;
}
