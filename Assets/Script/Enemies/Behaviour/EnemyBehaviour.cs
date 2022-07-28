using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    public int score;
    public ParticleSystem deathPrefab;

    public AudioSource audioClicked;

    public AudioSource audioCollide;

    public ScoreSO scoreSO;

    public virtual void OnClickHandler()
    {
        //On click sound
        audioClicked.Play();
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            audioCollide.Play();
            //Debug.Log("Dead");
            Destroy(gameObject, 0.5f);
        }
    }

    public virtual void Death()
    {
        //Score
        scoreSO.currentScore += score;

        Destroy(gameObject, 0.2f);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
    }
    */
}
