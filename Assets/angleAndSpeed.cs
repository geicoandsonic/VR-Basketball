using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class angleAndSpeed : MonoBehaviour
{
    public static angleAndSpeed Instance;
    public GameObject basketBall; 
    public TMP_Text angleText;
    public TMP_Text speedText; 

    private bool ballThrown = false; // flag to track if ball is thrown
    private Vector3 throwVector; // store the throw vector
    private float throwAngle; // store the throw angle
    private float throwSpeed; // store the throw speed


    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        if (ballThrown && basketBall != null)
        {
            // calculate the throw vector
            Vector3 direction = basketBall.transform.position - transform.position;
            throwVector = new Vector3(direction.x, 0, direction.z);
            /*
            // calculate the throw angle
            throwAngle = Vector3.Angle(Vector3.up, throwVector);
            if (throwVector.x < 0)
            {
                throwAngle = 360 - throwAngle;
            }
            */
            // Throw Speed
            throwSpeed = throwVector.magnitude;
            Rigidbody rb = basketBall.GetComponent<Rigidbody>();
            Vector3 velocity = rb.velocity;
            angleText.text = "Angle: " + Mathf.Atan2(velocity.y, Mathf.Sqrt(velocity.x * velocity.x + velocity.z * velocity.z)) * Mathf.Rad2Deg;
            speedText.text = "Speed: " + throwSpeed.ToString("F2") + " units/sec";
            ballThrown = false;
        }
    }

    public void onBallThrown()
    {
        ballThrown = true;
    }

    public void ballLanded()
    {
        ballThrown = false;
        
    }
}
