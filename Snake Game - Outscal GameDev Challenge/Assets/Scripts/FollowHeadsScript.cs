using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHeadsScript : MonoBehaviour {

    private int countFollowHeads = 0;
    public Transform prefab;
    private Transform parent;

    private void Start()
    {
        parent = FindObjectOfType<PlayerMovement>().transform;
    }
    public void IncreaseSnakeLength()
    {
        //Debug.Log("YOLO");
        
        Vector3 position;
        countFollowHeads++;
        if (FindObjectOfType<PlayerMovement>().lastDirection == FindObjectOfType<PlayerMovement>().North)
        {
            position = new Vector3(0.0f, countFollowHeads * -1.0f, 0.0f);
            Instantiate(prefab, position, Quaternion.identity, parent);
            //prefab.rotation.Set(90.0f, 0.0f, 0.0f, 1.0f);
        }
        else if(FindObjectOfType<PlayerMovement>().lastDirection == FindObjectOfType<PlayerMovement>().East)
        {
            position = new Vector3(countFollowHeads * -1.0f, 0.0f, 0.0f);
            Instantiate(prefab, position, Quaternion.identity, parent);
            //prefab.SetParent(parent);
            //prefab.rotation.Set(90.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (FindObjectOfType<PlayerMovement>().lastDirection == FindObjectOfType<PlayerMovement>().West)
        {
            position = new Vector3(countFollowHeads * 1.0f, 0.0f, 0.0f);
            Instantiate(prefab, position, Quaternion.identity, parent);
            //prefab.SetParent(parent);
            //prefab.rotation.Set(90.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            position = new Vector3(0.0f, countFollowHeads * 1.0f, 0.0f);
            Instantiate(prefab, position, Quaternion.identity, parent);
            //prefab.SetParent(parent);
            //prefab.rotation.Set(90.0f, 0.0f, 0.0f, 1.0f);
        }
        //prefab.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("YOLO");
    //    Debug.Log("the snake collided with itself");
        
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("YOLO");
    //        Debug.Log("the snake collided with itself");

    //    }
    //}


}
