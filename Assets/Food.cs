using UnityEngine;

public class Food : MonoBehaviour
{



    
    
  public void Spawnfood()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            Instantiate(gameObject, new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z), Quaternion.identity);
        }
    }

}
