using UnityEngine;

public class Boid : MonoBehaviour
{
    public Rigidbody ri;
    private void Awake()
    {

       ri = GetComponent<Rigidbody>();
       ri.linearVelocity = Random.insideUnitSphere;
        GetComponent<Renderer>().material.SetColor("_basecolor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));

    }
    public void asingtovolicity()
    {



        transform.forward = Vector3.RotateTowards(transform.forward, ri.linearVelocity.normalized, Mathf.Deg2Rad * 1800 * Time.deltaTime, 100);
     }
}
