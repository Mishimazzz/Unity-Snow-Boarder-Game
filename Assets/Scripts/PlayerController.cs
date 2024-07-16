using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //add torque to the player
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    bool canMove = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();//looking for the surface effector 2d in unity, using in multiple way (such as speed up/down)
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
        RotatePlayer();
        RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
        
    }

    void RotatePlayer()
        {
            if (Input.GetKey(KeyCode.LeftArrow)){
                rb2d.AddTorque(torqueAmount);
            }

            else if(Input.GetKey(KeyCode.RightArrow)){
                rb2d.AddTorque(-torqueAmount);
            }
        }
}
