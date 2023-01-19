using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 direction = Vector2.left;
    private List<Transform> blocks;

    private void Update()
    {
        Movement();
        blocks = new List<Transform>();
        blocks.Add(this.transform);
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3((Mathf.Round(this.transform.position.x) + direction.x),
        (Mathf.Round(this.transform.position.y) + direction.y), 0f);
    }

}
