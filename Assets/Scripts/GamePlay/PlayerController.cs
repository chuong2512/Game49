using System.Collections;
using System.Collections.Generic;
using JumpFrog;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    private bool play;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        play = true;
    }

    public void Play()
    {
      
    }

    public bool onButton;
    Vector3 offset;
    Vector3 mousePosition;
    public float maxSpeed = 10;
    Vector2 mouseForce;
    Vector3 lastPosition;

    void Update()
    {
        if (play && GameManager.Instance.currentState == State.Playing)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePosition.y = transform.position.y;
            
            if (onButton)
            {
                mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
                mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
                lastPosition = mousePosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                onButton = true;
                offset = transform.position - mousePosition;
            }

            if (Input.GetMouseButtonUp(0) && onButton)
            {
                Rigidbody2D.velocity = Vector2.zero + Vector2.down;
                onButton = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (onButton)
        {
            Rigidbody2D.MovePosition(mousePosition + offset);
        }
    }
}