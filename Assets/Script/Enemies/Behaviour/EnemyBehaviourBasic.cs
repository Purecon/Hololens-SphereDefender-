public class EnemyBehaviourBasic : EnemyBehaviour
{
    public override void OnClickHandler()
    {
        deathPrefab.Play();
        base.OnClickHandler();

        Death();
    }
}
