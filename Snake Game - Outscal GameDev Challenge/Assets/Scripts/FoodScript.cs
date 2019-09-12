using UnityEngine;
using System.Collections;

public class FoodScript : MonoBehaviour {

    private int chooser = 1;

    public void SpawnRed()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void SpawnBlue()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void Spawn()
    {
        chooser = Random.Range(0, 2);
        transform.position = new Vector3(Random.Range(-19, 20), 0.5f, Random.Range(-29, 30));
        if (chooser == 1)
        {
            SpawnRed();
        }
        else
        {
            SpawnBlue();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //transform.position.x == FindObjectOfType<PlayerMovement>().transform.position.x && transform.position.z == FindObjectOfType<PlayerMovement>().transform.position.z
    //    if (transform.position.x == FindObjectOfType<PlayerMovement>().transform.position.x)
    //    {
    //        Debug.Log("the snake head hit food");
    //        transform.GetChild(0).gameObject.SetActive(false);
    //        transform.GetChild(1).gameObject.SetActive(false);
    //        Spawn();
    //    }
        
    //}

    private void Start()
    {
        Spawn();
    }

    



}
