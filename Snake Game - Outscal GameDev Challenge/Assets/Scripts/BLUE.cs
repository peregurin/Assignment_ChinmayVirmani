using UnityEngine;

public class BLUE : MonoBehaviour {

    public FoodInfo blueFood;
    public Transform player;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("SOME COLLISION HAS TAKEN PLACE");
        Vector3 diff = transform.position - player.position;
        //Debug.Log("HERE BLUE");
        if (Mathf.Abs(diff.x)<1 && Mathf.Abs(diff.y)<1 && Mathf.Abs(diff.z)<1)
        {
            Debug.Log("The snake head hit blue food");
            gameObject.SetActive(false);
            FindObjectOfType<FoodScript>().Spawn();
            FindObjectOfType<FollowHeadsScript>().IncreaseSnakeLength();
        }
    }

}
