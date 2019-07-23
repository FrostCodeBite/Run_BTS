using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarScript : MonoBehaviour {

    WheelJoint2D[] wheelJoints;
    JointMotor2D backWheel;
    JointMotor2D frontWheel;


    public float maxSpeed = -1000;
    private float maxBackSpeed = 1500f;
    private float acceleration = 250f;
    private float deacceleration = -100f;
    public float brakeForce = 3000f;
    private float gravity = 9.8f;
    private float angleCar = 0;

    public Click[] controlCars;

    public bool ground = false;
    public LayerMask Map;
    public Transform bwheel;

    public Transform target;
    public Transform finish;
    public float distanceFloat = 0f;
    public float distanceTarget = 0f;
    public Text distanceText;
    public GameObject finishPanel;

    // Use this for initialization
    void Start () {
        wheelJoints = gameObject.GetComponents<WheelJoint2D>();
        backWheel = wheelJoints[0].motor;
        frontWheel = wheelJoints[1].motor;
	}

    void Update()
    {
        distanceText.text = "Distance: "+ distanceFloat.ToString()+" Km";
        distanceFloat = Mathf.Round(finish.position.x-target.position.x);
        distanceTarget = Mathf.Round(target.position.x);
        //distanceFloat = Mathf.Round(Vector3.Distance(target.position, finish.position));
        ground = Physics2D.OverlapCircle(bwheel.transform.position, 0.17f, Map);
    }

    // Update is called once per frame
    void FixedUpdate() {
        frontWheel.motorSpeed = backWheel.motorSpeed;
        angleCar = transform.localEulerAngles.z;
        if (angleCar >= 180)
        {
            angleCar = angleCar - 360;
        }
        /*if (ground == true)
        {
            
        }*/

        if (controlCars[0].ClickedIs == true)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (acceleration - gravity * Mathf.PI * (angleCar / 180) * 80 * Time.deltaTime), maxSpeed, maxBackSpeed);
        }
        else if ((controlCars[0].ClickedIs == false && backWheel.motorSpeed < 0) || (controlCars[0].ClickedIs == false && backWheel.motorSpeed == 0 && angleCar < 0))
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (deacceleration - gravity * Mathf.PI * (angleCar / 180) * 80 * Time.deltaTime), maxSpeed, 0);
        }
        if ((controlCars[0].ClickedIs == false && backWheel.motorSpeed > 0) || (controlCars[0].ClickedIs == false && backWheel.motorSpeed == 0 && angleCar > 0))
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (-deacceleration - gravity * Mathf.PI * (angleCar / 180) * 80 * Time.deltaTime), 0, maxBackSpeed);
        }

        //
        else if (controlCars[0].ClickedIs == false&&backWheel.motorSpeed<0)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - deacceleration * Time.deltaTime,maxSpeed,0);
        }
        else if (controlCars[0].ClickedIs == false && backWheel.motorSpeed > 0)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - deacceleration * Time.deltaTime, 0, maxBackSpeed);
        }

        if(controlCars[1].ClickedIs == true && backWheel.motorSpeed > 0)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - brakeForce * Time.deltaTime, 0, maxBackSpeed);
        }
        else if (controlCars[1].ClickedIs == true && backWheel.motorSpeed < 0)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed + brakeForce * Time.deltaTime, maxSpeed, 0);
        }

        wheelJoints[0].motor = backWheel;
        wheelJoints[1].motor = frontWheel;
	}

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(bwheel.transform.position, 0.17f);
    }*/

    void OnTriggerEnter2D(Collider2D trigger)
    {
        /*if(trigger.gameObject.tag == "Head")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/
        if (trigger.CompareTag("Collidable"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            finishPanel.SetActive(true);
        }
        /*else if (trigger.CompareTag("FinishTag"))
        {
            finishPanel.SetActive(true);
        }*/
        if (trigger.gameObject.name == "Finish")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            finishPanel.SetActive(true);
        }
    }
}
