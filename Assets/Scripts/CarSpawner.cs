using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Car[] cars;
    public bool spawn = true;
    public float spawnTimer = 2;
    public int index = 0;
    public Transform spawnPoint;
    public RedGreenLight light;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        while (true)
        {
            while (light.lightColor == RedGreenLight.LightColor.Red) yield return null;
            Instantiate(cars[index++ % cars.Length ],spawnPoint.position,spawnPoint.rotation).GetComponent<Car>().Init(light);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
