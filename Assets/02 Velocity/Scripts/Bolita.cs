using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;
    [Range(0f, 1f)][SerializeField] private float dampingFactor = 0.9f;

    [Header("World")]
    [SerializeField] Camera camera;

    private int currentAccelerationCounter = 0;
    private readonly MyVector2D[] directions = new MyVector2D[4]
    {
        new MyVector2D (x:0, y:-9.8f),new MyVector2D (x:9.8f, y:0f),new MyVector2D (x:0, y:9.8f),new MyVector2D (x:-9.8f, y:0f)
    };
    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.green);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            acceleration = directions[(++currentAccelerationCounter) % directions.Length];
            velocity *= 0;
        }
    }
    public void Move()
    {
        position = position + velocity * Time.fixedDeltaTime;
        velocity = velocity + acceleration * Time.fixedDeltaTime;

        if (position.x > camera.orthographicSize)
        {
            velocity.x *= -1;
            velocity *= dampingFactor;
            position.x = camera.orthographicSize;
        }

        else if (position.x < -camera.orthographicSize)
        {
            velocity.x *= -1;
            velocity *= dampingFactor;
            position.x = -camera.orthographicSize;
        }

        if (position.y > camera.orthographicSize)
        {
            velocity.y *= -1;
            velocity *= dampingFactor;
            position.y = camera.orthographicSize;
        }

        else if (position.y < -camera.orthographicSize)
        {
            velocity.y *= -1;
            velocity *= dampingFactor;
            position.y = -camera.orthographicSize;
        }

           transform.position = new Vector3(position.x, position.y);
    }
    private void CheckBounds(ref float x, ref float displacementX, float halfWidth)
    {
        if (Mathf.Abs(x) > halfWidth)
        {
            displacementX = displacementX * -1;
            x = Mathf.Sign(x) * camera.orthographicSize;
        }
    }
}
