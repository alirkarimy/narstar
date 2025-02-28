using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ActionPoint :MonoBehaviour, IInteractable
{
    public UnityEvent OnEnterPoint;

    public GameObject camera;
    public float cameraDisableDelay;
    public GameObject IndicatorArrow;


    public void ShowPoint()
    {
        camera.SetActive(true);
        StartCoroutine(nameof(DisableCamera));
        IndicatorArrow.SetActive(true);
    }

    IEnumerator DisableCamera()
    {
        yield return new WaitForSeconds(cameraDisableDelay);
        camera.SetActive(false);
    }

    public void Interact(GameObject interactedObject )
    {
        OnEnterPoint?.Invoke();
        IndicatorArrow.SetActive(false);
    }

    
}
