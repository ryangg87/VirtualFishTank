using UnityEngine;

public class Food : MonoBehaviour
{



    public GameObject foodPrefab;
    GameObject targetObject;
    private void Spawnfood()
    {
        Instantiate(foodPrefab, targetObject.transform.position, Random.rotation);
    
    }

}
