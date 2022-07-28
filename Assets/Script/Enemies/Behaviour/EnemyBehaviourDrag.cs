using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourDrag : EnemyBehaviour
{
    public Material colorChange;
    public MeshRenderer rendererForColor;
    public float targetMultiplier = 1.5f;
    
    GameObject sphere;
    bool deathAnimationPlayed = false;

    [Header("Distance")]
    public float initialDistance;
    public float currentDistance;

    void Start()
    {
        sphere = GameObject.FindGameObjectWithTag("Sphere");
        initialDistance = Vector3.Distance(transform.position, sphere.transform.position);
        currentDistance = initialDistance;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, sphere.transform.position);

        if(currentDistance >= initialDistance * targetMultiplier)
        {
            if (!deathAnimationPlayed)
            {
                deathAnimationPlayed = true;

                rendererForColor.material = colorChange;
                deathPrefab.Play();
                audioCollide.Play();
                Death();
            }
        }
    }


    public override void Death()
    {
        //Score
        scoreSO.currentScore += score;

        Destroy(gameObject, 0.5f);
    }
}
