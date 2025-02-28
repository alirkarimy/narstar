using System;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovementController : MonoBehaviour
{

    public float speed;
    public float maxSpeed;
    public VariableJoystick variableJoystick;
    [SerializeField] Rigidbody rb;
    public Action OnStop;
    public Action OnMove;
    public Action OnStartMove;
    public bool isStop = true;
    public int moveIndicator = 1;
    Vector3 direction;



    Transform followTarget;


    public Animator anim;

    private float velocity;



    private void OnEnable()
    {
        isStop = true;

    }



    private void OnDisable()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStop = false;
            OnStartMove?.Invoke();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isStop = true;
            if (OnStop != null)
                OnStop();
        }
        else if (!isStop)
        {
            OnMove?.Invoke();
        }
        if (followTarget)
        {

        }
    }

    //public void FixedUpdate()
    //{
    //    direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
    //    if (direction!=Vector3.zero) transform.forward = direction;
    //    //rb.velocity = (direction * speed*moveIndicator * Time.fixedDeltaTime);
    //}


    void FixedUpdate()
    {
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        if (direction != Vector3.zero) transform.forward = -direction;

        speed =Mathf.Abs(variableJoystick.Horizontal) + Mathf.Abs(variableJoystick.Vertical);
        speed *= maxSpeed;
        speed = Mathf.Clamp(speed, 0f, maxSpeed);
        speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref velocity, 0.1f);
        anim.SetFloat("Speed", speed );
        rb.linearVelocity = (-direction * speed *40* moveIndicator * Time.fixedDeltaTime);
    }


    public bool Stopped => speed < 0.05f;

   
    //
    

    public void EnableAgentMode(bool enable)
    {

    }

   

    

   

}