using UnityEngine;


public class BoidSimulationControl : MonoBehaviour
{
    //public Rigidbody rigibody;
    //public Vector3 velocity;
    //public float accelerationRate = 1f;
    // public float maxSpeed = 10f;
    //public float acclmax = 5f;
    // public float linercolvity;



    public enum ControlMode
    {

        seek,
        pursue,
        food,
        obstacle

    }

    public ControlMode controlMode = ControlMode.seek;
    public int controlModeInt = 0;
    public Food foodprefab = null;
    public GameObject boidprefab = null;
    public int numBoidsTospawn = 10;
    public Boid[] boids = new Boid[10];
    // Rigidbody targetObject;
    GameObject targetObject;
    public void Start()
    {
        //
        spawnfish();

        targetObject = GameObject.Find("target");

        //


        //boids = new Boid[10];

/*
        
        for (int i = 0; i < numBoidsTospawn; i++)
        {
            Vector3 position = new Vector3(Random.Range(-1.4f, 0.9f), Random.Range(0f, 1.4f), Random.Range(-0.9f, 0.9f));
            Quaternion rotation = Random.rotation;
            GameObject spawndBoid = Instantiate(boidprefab, position, rotation);
            spawndBoid.transform.localScale *= Random.Range(0.9f, 3f);
            spawndBoid.GetComponent<Renderer>().material.SetColor("_basecolor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));

            Boid boidcompent = spawndBoid.GetComponent<Boid>();
            boidcompent.maxSpeed = Random.Range(0.5f, 1.5f);
            boidcompent.acclmax = Random.Range(0.5f, 1.5f);

            boids[i] = boidcompent;
        }*/




    }
    //
    private void FixedUpdate()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        bool didhit = Physics.Raycast(ray, out hitInfo, 100);
        if (didhit)
        {
            targetObject.transform.position = hitInfo.point;


        }

    }
    //


    public void Update()
    {
        
       if(controlMode==ControlMode.seek)
        {
            
            for (int i = 0; i < numBoidsTospawn; i++)
            {
                Vector3 accel = boids[i].seek(targetObject.transform.position, boids[i].acclmax);

                if (Input.GetMouseButton(0))
                {
                    boids[i].ri.linearVelocity += accel * Time.fixedDeltaTime;
                    Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                    Debug.DrawRay(boids[i].transform.position, boids[i].ri.linearVelocity, Color.red);
                }
                //  boids[i].ri.linearVelocity += accel * Time.fixedDeltaTime;
                // Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                // boids[i].ri.linearVelocity -= accel * Time.fixedDeltaTime;
                // Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                else if (Input.GetMouseButton(1))
                {
                    boids[i].ri.linearVelocity -= accel * Time.fixedDeltaTime;
                    Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                    Debug.DrawRay(boids[i].transform.position, boids[i].ri.linearVelocity, Color.red);
                    //Debug.DrawRay(boids[i].transform.position, , Color.red);

                }



            }
            
        }
        if (Input.GetMouseButton(0) && controlMode == ControlMode.food)
        {

            foodprefab.Spawnfood();
        }

        if (Input.GetMouseButton(0) && controlMode == ControlMode.food)
        {
            for (int i = 0; i < numBoidsTospawn; i++)
            {

                float foodseekraduis = 0.5f;
                Collider[] colliders = Physics.OverlapSphere(boids[i].transform.position, foodseekraduis);
                foreach(Collider collider in colliders)
                {

                    Food food = collider.GetComponent<Food>();
                    Vector3 accel = boids[i].seek(collider.transform.position, boids[i].acclmax);
                    boids[i].ri.linearVelocity += accel * Time.fixedDeltaTime;


                }
            }
            
        }
       
        //if (purse == true)
        if (controlMode == ControlMode.pursue)
        {

            for (int i = 0; i < numBoidsTospawn; i++)
            {
                Vector3 accel = boids[i].pUrsue(targetObject.transform.position, boids[i].acclmax, boids[i].desiredsoeed);

                if (Input.GetMouseButton(0))
                {
                    boids[i].ri.linearVelocity += accel * Time.fixedDeltaTime;
                    Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                    Debug.DrawRay(boids[i].transform.position, boids[i].ri.linearVelocity, Color.red);
                }
                //  boids[i].ri.linearVelocity += accel * Time.fixedDeltaTime;
                // Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                // boids[i].ri.linearVelocity -= accel * Time.fixedDeltaTime;
                // Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                else if (Input.GetMouseButton(1))
                {
                    boids[i].ri.linearVelocity -= accel * Time.fixedDeltaTime;
                    Debug.DrawRay(boids[i].transform.position, accel, Color.green);
                    Debug.DrawRay(boids[i].transform.position, boids[i].ri.linearVelocity, Color.red);

                }

            }

        }
             

            // float dt = Time.deltaTime;
            // Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            // Vector3 acceleration = input.normalized * accelerationRate;
            // velocity += acceleration * dt;
            // velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            //linercolvity = velocity.y;
            //Vector3 linearVelocity = rigibody.linearVelocity;
            // transform.position += velocity * dt;

            //


            //  Debug.DrawRay(transform.position, rigibody.linearVelocity, Color.red);
            //
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

    public void spawnfish()
    {
        boids = new Boid[10];



        for (int i = 0; i < numBoidsTospawn; i++)
        {
            Vector3 position = new Vector3(Random.Range(-1.4f, 0.9f), Random.Range(0f, 1.4f), Random.Range(-0.9f, 0.9f));
            Quaternion rotation = Random.rotation;
            GameObject spawndBoid = Instantiate(boidprefab, position, rotation);
            spawndBoid.transform.localScale *= Random.Range(0.9f, 3f);
            spawndBoid.GetComponent<Renderer>().material.SetColor("_basecolor", Random.ColorHSV(0, 1, 0.5f, 1, 0.5f, 1));

            Boid boidcompent = spawndBoid.GetComponent<Boid>();
            boidcompent.maxSpeed = Random.Range(0.5f, 1.5f);
            boidcompent.acclmax = Random.Range(0.5f, 1.5f);

            boids[i] = boidcompent;
        }

    }
}
