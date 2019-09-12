using UnityEngine;

public class BLUE : MonoBehaviour {

    public FoodInfo blueFood;
    public Transform player;

    private void Update()
    {
        Debug.Log("the position of the food is " + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HERE");
        if (transform.position == player.position)
        {
            Debug.Log("The snake head hit blue food");
            gameObject.SetActive(false);
            FindObjectOfType<FoodScript>().Spawn();
        }
    }

}
