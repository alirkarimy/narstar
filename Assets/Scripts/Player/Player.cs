using UnityEngine;

public class Player : MonoBehaviour
{


    public Animator animator;

    public void Die()
    {
        animator.CrossFade("Die", 0.2f);
    }


    public void OnInteract(IInteractable interactable)
    {
        if (interactable != null)
        {
            interactable.Interact(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            OnInteract(interactable);
        }
    }

}
