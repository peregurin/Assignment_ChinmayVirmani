using UnityEngine;

public class RED : MonoBehaviour {

    public FoodInfo redFood;
    public Transform player;

    //public void CheckCollision()
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("SOME COLLISION HAS TAKEN PLACE");
        Vector3 diff = transform.position - player.position;
        //Debug.Log("HERE RED");
        if (Mathf.Abs(diff.x)<1 && Mathf.Abs(diff.y)<1 && Mathf.Abs(diff.z)<1)
        {
            Debug.Log("The snake head hit red food");
            gameObject.SetActive(false);
            FindObjectOfType<FoodScript>().Spawn();
            FindObjectOfType<FollowHeadsScript>().IncreaseSnakeLength();
        }
    }

}
