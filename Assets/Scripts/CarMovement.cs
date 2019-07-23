using UnityEngine;
using System.Collections;


public class CarMovement : MonoBehaviour
{
    WheelJoint2D[] wheelJoint2Ds;
    JointMotor2D frontWheel;
    JointMotor2D backWheel;

    public float maxSpeed = -1000;
    private float maxBackSpeed = 2500f;
    private float acceleration = 250f;
    private float deacceleration = -100f;
    public float brackForce = 3000f;
    private float gravity = 9.8f;
    private float angleCar = 0;

    public Click[] controlCar;

    void Start()
    {
        wheelJoint2Ds = gameObject.GetComponents<WheelJoint2D>();
        backWheel = wheelJoint2Ds[1].motor;
        frontWheel = wheelJoint2Ds[0].motor;
    }

    void FixedUpdate()
    {
        angleCar = transform.localEulerAngles.z;
        if (angleCar >= 180)
        {
            angleCar = angleCar - 60;
        }
        if (controlCar[0].ClickedIs == true)
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (acceleration - gravity * (angleCar / 180) * 80) * Time.deltaTime, maxSpeed, maxBackSpeed);
        }
        if ((controlCar[0] == false && backWheel.motorSpeed < 0) || (controlCar[0].ClickedIs == false && backWheel.motorSpeed == 0 && angleCar < 0))
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (deacceleration - gravity * (angleCar / 180) * 80) * Time.deltaTime, maxSpeed, 0);
        }
        else if ((controlCar[0].ClickedIs == false && backWheel.motorSpeed > 0)||(controlCar[0].ClickedIs==false&&backWheel.motorSpeed==0&&angleCar>0))
        {
            backWheel.motorSpeed = Mathf.Clamp(backWheel.motorSpeed - (-deacceleration - gravity * (angleCar / 180) * 80) * Time.deltaTime, 0, maxBackSpeed);
        }
        wheelJoint2Ds[1].motor = backWheel;
        wheelJoint2Ds[0].motor = frontWheel;
    }
}

