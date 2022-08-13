using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolita : MonoBehaviour
{
    private MyVector2D position;
    private MyVector2D displacement;
    [SerializeField] private MyVector2D velocity;
    [Header("World")]
    [SerializeField] Camera camera;
    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    void Update()
    {
        position.Draw(Color.blue);
        displacement.Draw(position, Color.red);
        Move();
    }

    public void Move()
    {
        position = position + velocity * Time.deltaTime;

        if (Mathf.Abs(position.x) > camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
        }

        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y);
    }

}
