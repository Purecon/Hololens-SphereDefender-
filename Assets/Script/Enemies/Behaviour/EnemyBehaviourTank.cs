using UnityEngine;

public class EnemyBehaviourTank : EnemyBehaviour
{
    //Change color
    public Material[] colors;
    public int lives;

    public MeshRenderer rendererForColor;
    private int currentColor = 0;

    public ParticleSystem deathSplatPrefab;

    private void Start()
    {
        lives = colors.Length;
        currentColor = 0;
        rendererForColor.material = colors[currentColor];
    }

    public override void OnClickHandler()
    {
        deathPrefab.Play();
        base.OnClickHandler();
        currentColor++;
        lives--;

        //Destroy when out of lives
        if (lives <= 0)
        {
            Death();
        }
        else
        {
            Material currentMat = colors[currentColor];
            rendererForColor.material = currentMat;
            deathPrefab.startColor = currentMat.color;
            deathSplatPrefab.startColor = currentMat.color;
        }
    }
}
