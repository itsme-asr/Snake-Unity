using System.Collections.Generic;
using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 direction = Vector2.left;
    private List<Transform> blocks;

    [SerializeField] private Transform blockPreFab;
    private void Start()
    {
        blocks = new List<Transform>();
        blocks.Add(this.transform);
    }
    private void Update()
    {
        Movement();
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
        //Debug.Log(blocks.Count);
        for (int i = blocks.Count - 1; i > 0; i--)
        {
            //Debug.Log(blocks.Count + " " + i);
            blocks[i].position = blocks[i - 1].position;
        }

        this.transform.position = new Vector3((Mathf.Round(this.transform.position.x) + direction.x),
    (Mathf.Round(this.transform.position.y) + direction.y), 0f);


    }
    private void growBlock()
    {
        Transform block = Instantiate(this.blockPreFab);
        //Debug.Log(blocks.Count);
        block.position = blocks[blocks.Count - 1].position;
        blocks.Add(block);
    }
    private void resetState()
    {
        for (int i = 1; i < blocks.Count; i++)
        {
            Destroy(blocks[i].gameObject);
        }

        blocks.Clear();
        blocks.Add(this.transform);

        this.transform.position = Vector3.zero;
        direction = Vector2.left;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            growBlock();
        }
        else if (other.tag == "Walls")
        {
            resetState();
        }

    }
}
