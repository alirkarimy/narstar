using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RedGreenLight : MonoBehaviour
{
    public enum LightColor
    {
        Green,
        Yellow,
        Red
    }
    
    public LightColor lightColor = LightColor.Green;
    public float greenTime = 10;
    public float redTime = 6;
    public LightColorOnOff[] lights;
    public GameObject hud;
    public TextMeshProUGUI timerText;
    public float timer;
    public UnityEvent OnGreen, OnRed, OnYellow;
    public int index = 0;
    private void OnEnable()
    {
        TurnGreen();
    }
    private void TurnTo(LightColor lightCol)
    {
        lightColor = lightCol;
    }
    public void TurnGreen()
    {
        TurnTo(LightColor.Green);
        OnGreen?.Invoke();
        Invoke("TurnYellow", greenTime);
        timer = greenTime;
        timerText.transform.parent.gameObject.SetActive(true);

        InvokeRepeating("SetTimer", 1, 1);
        timerText.SetText(timer.ToString());
        lights[2].light.color = lights[2].on;

        lights[0].light.color = lights[0].off;
        lights[1].light.color = lights[1].off;
    }
    private void SetTimer()
    {
        timer -= 1;
        if (timer < 0)
        {
            CancelInvoke("SetTimer");
            timerText.transform.parent.gameObject.SetActive(false);
        }
        else
            timerText.SetText(timer.ToString());

    }
    public void TurnYellow()
    {
        TurnTo(LightColor.Yellow);
        OnYellow?.Invoke();

        Invoke("TurnRed", 1);
        lights[1].light.color = lights[1].on;

        lights[0].light.color = lights[0].off;
        lights[2].light.color = lights[2].off;

    }
    public void TurnRed()
    {
        TurnTo(LightColor.Red);
        if(index++ > 0)
            OnRed?.Invoke();

        Invoke("TurnGreen", redTime);
        lights[0].light.color = lights[0].on;

        lights[1].light.color = lights[1].off;
        lights[2].light.color = lights[2].off;

    }

    public void ShowHUD()
    {
        hud?.SetActive(true);
    }
    public void HideHUD()
    {
        hud?.SetActive(false);
    }
}
