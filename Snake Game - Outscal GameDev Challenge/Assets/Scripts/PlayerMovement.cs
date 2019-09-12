using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //private Transform player;
    public enum Direction { NORTH, SOUTH, EAST, WEST, STOP};
    public float delayTime = 0.5f;
    public Direction lastDirection = Direction.NORTH;
    //private Vector3 pos;
    // private int count = 0;

    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(delayTime));
    }
    IEnumerator ExecuteAfterTime(float delayTime)
    {
        Direction direction;
        if (Input.GetKey("w"))
        {
            direction = Direction.NORTH;
            lastDirection = Direction.NORTH;
        }
        else if (Input.GetKey("a"))
        {
            direction = Direction.WEST;
            lastDirection = Direction.WEST;
        }
        else if (Input.GetKey("s"))
        {
            direction = Direction.SOUTH;
            lastDirection = Direction.SOUTH;
        }
        else if (Input.GetKey("d"))
        {
            direction = Direction.EAST;
            lastDirection = Direction.EAST;
        }
        else
        {
            direction = lastDirection;
        }
        Move(direction);
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(ExecuteAfterTime(delayTime));
    }

    public void Move(Direction direction)
    {
        if(direction == Direction.NORTH)
        {
            transform.Translate(0.0f, 1.0f, 0.0f);
            //pos = transform.position;
        }
        else if (direction == Direction.SOUTH)
        {
            transform.Translate(0.0f, -1.0f, 0.0f);
            //pos = transform.position;
        }
        else if (direction == Direction.WEST)
        {
            transform.Translate(-1.0f, 0.0f, 0.0f);
            //pos = transform.position;
        }
        else if (direction == Direction.EAST)
        {
            transform.Translate(1.0f, 0.0f, 0.0f);
            //pos = transform.position;
        }
        else if(direction == Direction.STOP)
        {
            //transform.Translate(0.0f, 0.0f, 0.0f);
            //transform.position = pos;
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("The snake head hit a wall");
            lastDirection = Direction.STOP; 
        }

    }

    private void Update()
    {
        Debug.Log("the pos of the snake head is" + transform.position);
    }



}
