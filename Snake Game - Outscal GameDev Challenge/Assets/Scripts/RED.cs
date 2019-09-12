using UnityEngine;

public class RED : MonoBehaviour {

    public FoodInfo redFood;
    public Transform player;

    //public void CheckCollision()
    //{

    //}

    private void Update()
    {
        Debug.Log("the position of the food is " + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HERE");
        if (transform.position == player.position)
        {
            Debug.Log("The snake head hit red food");
            gameObject.SetActive(false);
            FindObjectOfType<FoodScript>().Spawn();
        }
    }

}
