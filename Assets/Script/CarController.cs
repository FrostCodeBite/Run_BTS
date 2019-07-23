using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float speed = 1500f;
	public float rotationSpeed = 15f;

	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;

	public Rigidbody2D rb;

	private float movement = 0f;
	private float rotation = 0f;

    private bool isPressedForward;
    private bool isPressedBackward;

	void Update ()
	{
        //
        //movement = -Input.GetAxisRaw("Vertical") * speed;
        if (isPressedForward)
        {
            movement = -1 * speed;
        }
        else
        {
            movement = 0;
            //rotation = 0;
        }

        if (isPressedBackward)
        {
            movement = 1 * speed;
            //rotation = -1;
        }
        else
        {
            movement = 0;
            //rotation = 0;
        }
        //rotation of wheel
        //rotation = Input.GetAxisRaw("Horizontal");
        /*if (Input.GetKey(KeyCode.P))
        {
            movement = -speed;
            rotation = rotationSpeed;
        }else if (Input.GetKey(KeyCode.Q))
        {
            movement = speed;
            rotation = -rotationSpeed;
        }*/

        
        
	}

	void FixedUpdate ()
	{
		if (movement == 0f)
		{
			backWheel.useMotor = false;
			frontWheel.useMotor = false;
		} else
		{
			backWheel.useMotor = true;
			frontWheel.useMotor = true;

			JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
			backWheel.motor = motor;
			frontWheel.motor = motor;
		}

        //rb.AddTorque(-rotation * Time.fixedDeltaTime);
        
    }

    public void PressedForward()
    {
        isPressedForward = true;
    }

    public void NotPressedForward()
    {
        isPressedForward = false;
    }
    public void PressedBackward()
    {
        isPressedBackward = true;
    }
    public void NotPressedBackward()
    {
        isPressedBackward = false;
    }
}
