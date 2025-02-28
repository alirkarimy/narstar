using UnityEngine;

public class Car : MonoBehaviour,IInteractable
{
    public float speed = 3;
    public float turq = 20;

    public RedGreenLight light;

    public bool IsDangerous => light.lightColor != RedGreenLight.LightColor.Red;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Init(RedGreenLight light)
    {
        this.light = light;
        Invoke("SelfDestruct",10);
    }

    // Update is called once per frame
    void Update()
    {
        if (light.lightColor == RedGreenLight.LightColor.Red)
        {
            if (turq < 100)
                transform.position += transform.forward * Time.deltaTime * turq;
            turq /= 1.2f;
        }
        else
        {
            turq = speed;

            transform.position += transform.forward * Time.deltaTime * speed;

        }
    }
    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    public void Interact(GameObject interactedObject)
    {
        if(interactedObject.TryGetComponent<Player>(out Player player)){
            if (!IsDangerous) return;
            player.Die();
        }
    }
}
