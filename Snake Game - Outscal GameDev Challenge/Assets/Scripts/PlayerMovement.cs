using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //private Transform player;
    public enum Direction { NORTH, SOUTH, EAST, WEST};
    public Direction North = Direction.NORTH;
    public Direction East = Direction.EAST;
    public Direction South = Direction.SOUTH;
    public Direction West = Direction.WEST;
    public Transform child;
    public float delayTime = 0.5f;
    public Direction lastDirection = Direction.NORTH;
    private Vector3 pos;
    //private int countFollowHeads = 0;

    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(delayTime));
    }
    IEnumerator ExecuteAfterTime(float delayTime)
    {
        Direction direction;
        if (Input.GetKey("w"))
        {
            if(lastDirection != Direction.SOUTH)
            {
                direction = Direction.NORTH;
                lastDirection = Direction.NORTH;
            }
            else
            {
                direction = lastDirection;
            }
        }
        else if (Input.GetKey("a"))
        {
            if(lastDirection != Direction.EAST)
            {
                direction = Direction.WEST;
                lastDirection = Direction.WEST;
            }
            else
            {
                direction = lastDirection;
            }

        }
        else if (Input.GetKey("s"))
        {
            if(lastDirection != Direction.NORTH)
            {
                direction = Direction.SOUTH;
                lastDirection = Direction.SOUTH;
            }
            else
            {
                direction = lastDirection;
            }
        }
        else if (Input.GetKey("d"))
        {
            if(lastDirection != Direction.WEST)
            {
                direction = Direction.EAST;
                lastDirection = Direction.EAST;
            }
            else
            {
                direction = lastDirection;
            }
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
            pos = transform.position;
            transform.Translate(0.0f, 0.0f, 1.0f);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).Translate(0.0f, 0.0f, -1.0f);
                Vector3 temp = transform.GetChild(i).position;
                transform.GetChild(i).position = pos;
                pos = temp;
            }
        }
        else if (direction == Direction.SOUTH)
        {
            pos = transform.position;
            transform.Translate(0.0f, 0.0f, -1.0f);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).Translate(0.0f, 0.0f, 1.0f);
                Vector3 temp = transform.GetChild(i).position;
                transform.GetChild(i).position = pos;
                pos = temp;
            }
        }
        else if (direction == Direction.WEST)
        {
            pos = transform.position;
            transform.Translate(-1.0f, 0.0f, 0.0f);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).Translate(1.0f, 0.0f, 0.0f);
                Vector3 temp = transform.GetChild(i).position;
                transform.GetChild(i).position = pos;
                pos = temp;
            }
        }
        else if (direction == Direction.EAST)
        {
            pos = transform.position;
            transform.Translate(1.0f, 0.0f, 0.0f);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).Translate(-1.0f, 0.0f, 0.0f);
                Vector3 temp = transform.GetChild(i).position;
                transform.GetChild(i).position = pos;
                pos = temp;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Ground")
        {
            //Debug.Log("Some collision has taken place");
            if (collision.gameObject.tag == "Wall")
            {
                Debug.Log("The snake head hit a wall");
                //lastDirection = Direction.STOP; 
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "body")
            {
                Debug.Log("the snake hit itself");
                Destroy(gameObject);
            }
        }

    }

    //public void childCollision()
    //{
    //    Debug.Log("Child Col");
    //    Destroy(gameObject);
    //}



}
