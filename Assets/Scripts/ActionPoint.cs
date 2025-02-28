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
        gameObject.SetActive(true);
       if(camera) camera?.SetActive(true);
        StartCoroutine(nameof(DisableCamera));
        if(IndicatorArrow) IndicatorArrow?.SetActive(true);
    }

    IEnumerator DisableCamera()
    {
        yield return new WaitForSeconds(cameraDisableDelay);
        if(camera)camera.SetActive(false);
    }

    public void Interact(GameObject interactedObject )
    {
        OnEnterPoint?.Invoke();
        if(IndicatorArrow) IndicatorArrow.SetActive(false);
    }

    
}
