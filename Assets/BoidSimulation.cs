using UnityEngine;

public class BoidSimulationControl : MonoBehaviour
{
    
   public enum ControlMode
    {
         
        seek,
        pursue,
        food,
        obstacle

    }

    public ControlMode controlMode = ControlMode.seek;
    public int controlModeInt = 0;
    public GameObject boidprefab = null;
    public int numBoidsTospawn = 10;
  
    public void Start()
    {

       
        for (int i = 0; i < numBoidsTospawn; i++)
        {
            Vector3 position = new Vector3(Random.Range(-1.4f, 0.9f), Random.Range(0f, 1.4f), Random.Range(-0.9f, 0.9f));
            Quaternion rotation = Random.rotation;
            GameObject spawndBoid = Instantiate(boidprefab, position, rotation);
            spawndBoid.transform.localScale *= Random.Range(0.9f, 3f);
            spawndBoid.GetComponent<Renderer>().material.SetColor("_basecolor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));
           


        }
    }
    public void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            controlMode = ControlMode.seek;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            controlMode = ControlMode.pursue;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            controlMode = ControlMode.food;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            controlMode = ControlMode.obstacle;
        }
    }
    
}
