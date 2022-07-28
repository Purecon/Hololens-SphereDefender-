using UnityEngine;

public class EnemyBehaviourSplit : EnemyBehaviour
{
    //Prefab child
    [Header("Child&Parent")]
    public Collider colliderParent;
    public GameObject parent;
    public GameObject[] childs;

    public override void OnClickHandler()
    {
        deathPrefab.Play();
        base.OnClickHandler();

        //Spawn child
        foreach(GameObject child in childs)
        {
            child.SetActive(true);
        }

        Death();
    }

    public override void Death()
    {
        //Score
        scoreSO.currentScore += score;

        colliderParent.enabled = false;
        Destroy(parent, 0.2f);
    }

    //Garbage collecting unneeded object
    private void Update()
    {
        bool isDestroy = true;
        foreach (GameObject child in childs)
        {
            if (!child.Equals(null))
            {
                isDestroy = false;
            }
        }
        if (isDestroy)
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
