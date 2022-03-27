using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Caches
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayHurtAnimationOnGotHit(CurrentHealth currentHealth)
    {
        if (currentHealth.current <= 0) return;

        if (currentHealth.previous > currentHealth.current)
            animator.Play("Hurt");
    }

    public void OnIsAliveChanged(bool value)
    {
        animator.SetBool("b_is_alive", value);
    }
}
