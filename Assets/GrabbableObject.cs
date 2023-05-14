using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public bool isGrabbed = false;
    public bool hasBeenGrabbed = false;
    public int velocityModifier = 3;
    [SerializeField] private bool isGettingPoint;
    public AudioSource audio;
    public int totalPoints = 0;
    public void Grab(Vector3 currPos){
        isGrabbed = true;
        if(Vector3.Distance(this.transform.position,currPos) > 2)
        {
            StartCoroutine(LerpPosition(currPos, 1));
        }
        else
        {
            //Debug.Log(Vector3.Distance(this.transform.position, currPos));
        }
        
    }

    public void Awake()
    {
        isGettingPoint = false;
    }
    public void releaseGrab()
    {
        isGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrabbed){
            this.transform.SetParent(ControllerManager.Instance.transform);
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            hasBeenGrabbed = true;
        }
        else if(hasBeenGrabbed)
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
            hasBeenGrabbed = false;
            this.transform.SetParent(null);
            this.GetComponent<Rigidbody>().useGravity = true;
            if(angleAndSpeed.Instance != null) //We only show this info on practice mode
            {
                angleAndSpeed.Instance.onBallThrown();
            }
            
            this.GetComponent<Rigidbody>().velocity = velocityModifier*OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        }
        if(transform.position.y < -1)
        {
            this.transform.position = new Vector3(transform.position.x, -1, transform.position.z);
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = false;
            if(angleAndSpeed.Instance != null)
            {
                angleAndSpeed.Instance.ballLanded();
            }
            
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        audio.Play();
        OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
    }

    public void OnTriggerEnter(Collider col)
    {
       
        Debug.Log(col.tag);
        if(col.tag == "Hoop")
        {
            isGettingPoint = true;
            Debug.Log("hit hoop");
        }
        if (isGettingPoint)
        {
            switch (fly.Instance.segmentIndex)
            {
                case (0):
                    horseGamemode.Instance.getPoint('H');
                    Debug.Log("H");
                    break;
                case (1):
                    horseGamemode.Instance.getPoint('O');
                    Debug.Log("O");
                    break;
                case (2):
                    horseGamemode.Instance.getPoint('R');
                    Debug.Log("R");
                    break;
                case (3):
                    horseGamemode.Instance.getPoint('S');
                    Debug.Log("S");
                    break;
                case (4):
                    horseGamemode.Instance.getPoint('E');
                    Debug.Log("E");
                    break;

            }
            isGettingPoint = false;
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        audio.Play();
    }
}
