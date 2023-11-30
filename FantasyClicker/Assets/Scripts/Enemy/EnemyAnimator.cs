using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayTakeDamageAnim()
    {
        anim.SetTrigger("TakeDamage");
    }

    public void PlayDeathAnim()
    {
        anim.SetTrigger("Death");
    }
}
