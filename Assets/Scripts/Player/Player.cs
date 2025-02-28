using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gameOver;

    public Animator animator;

    public void Die()
    {
        animator.CrossFade("Die", 0.2f);
        gameOver.SetActive(true);
    }


    public void Teleport(Transform point)
    {
        transform.position = point.position;
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
