using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlanetaGargantua : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D acceleration;

    [Header("World")]
    [SerializeField] private Camera camera;
    [SerializeField] private Transform gargantua;

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
        MyVector2D planetaposition = new MyVector2D(transform.position.x, transform.position.y);
        MyVector2D positiongargantua = new MyVector2D(gargantua.position.x, gargantua.position.y);
        acceleration = positiongargantua - planetaposition;
    }
    public void Move()
    {
        position = position + velocity * Time.fixedDeltaTime;
        velocity = velocity + acceleration * Time.fixedDeltaTime;
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
