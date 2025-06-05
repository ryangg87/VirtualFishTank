using UnityEngine;

public class Boid : MonoBehaviour
{
    
    public Rigidbody ri;
    public Vector3 velocity;

    public float accelerationRate = 1f;
    public float maxSpeed = 10f;
    public float acclmax = 5f;


    public float desiredsoeed = 5;

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
    //
    public Vector3 seek(Vector3 target,float acceleration)
    {

        
        Vector3 toTarget = target - transform.position;

        Vector3 totargetNormalized = toTarget.normalized;
        Vector3 accel = totargetNormalized * acceleration;

        return accel;
    }
    public Vector3 pUrsue(Vector3 target, float acceleration,float desiredsoeed)
    {

        //taget is the postion of the mosue tranfor psot get the postion of the fish
        //to toaget is the displamcet 
        Vector3 toTarget = target - transform.position;
        //to tgaget.
        //sam vector but with a leanght of 1
        Vector3 totargetNormalized = toTarget.normalized;
        //disrespped is the dircation and the spped

        Vector3 desiredVolocity = totargetNormalized * desiredsoeed;
        //how much you want to change your volite //devlat is the difrice in volcitys riquel
        //wher i wan tto be goign - whern i am goign 
        Vector3 deltavel = desiredVolocity - ri.linearVelocity;
        //acle give the rate at what you acllrate actacion give mangutin .normald gie us driaction with out mangutes 
        Vector3 accel = deltavel.normalized * acceleration;



        return accel;
    }
    //

    public void Update()
    {


    }
    public void FixedUpdate()
    {
        float speed = ri.linearVelocity.magnitude;
        if(speed> maxSpeed)
        {
            ri.linearVelocity = ri.linearVelocity * maxSpeed / speed;
        }
        asingtovolicity();
    }
   
    internal Vector3 seek(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    internal Vector3 pUrsue(Vector3 position, float acclmax, object desiredsoeed)
    {
        throw new System.NotImplementedException();
    }
}
