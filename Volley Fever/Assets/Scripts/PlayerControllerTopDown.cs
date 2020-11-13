using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class PlayerControllerTopDown : MonoBehaviour
{
    private PlayerControls controls;
    private Rigidbody2D rb;
    public float speed;
    private Vector2 inputAxis;
    private Vector2 pos;
    private SpriteRenderer rend;
    private Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        controls = new PlayerControls();
        controls.Overworld.Move.performed += ctx => inputAxis = ctx.ReadValue<Vector2>();
        controls.Overworld.Move.canceled += ctx => inputAxis = Vector2.zero;
    }

    private void Update()
    {
        animator.SetFloat("SpeedX",Mathf.Abs(inputAxis.x));
        animator.SetFloat("SpeedY",Mathf.Abs(inputAxis.y));
    }
    private void Move()
    {
        rb.position += inputAxis * (speed * Time.fixedDeltaTime);
        if (inputAxis.x < 0)
        {
            rend.flipX = true;
        }

        if (inputAxis.x > 0)
        {
            rend.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        if (Gamepad.current.buttonEast.isPressed)
        {
            Debug.Log("Controller is working!");
        }
        
    }

    private void OnEnable()
    {
        controls.Overworld.Enable();
    }

    private void OnDisable()
    {
        controls.Overworld.Disable();
    }
}
