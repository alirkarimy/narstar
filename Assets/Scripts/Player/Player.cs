using UnityEngine;

public class Player : MonoBehaviour
{
    


    public void OnInteract(IInteractable interactable)
    {
        if (interactable != null)
        {
            interactable.Interact();
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
