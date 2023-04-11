using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public bool isGrabbed = false;
    public bool hasBeenGrabbed = false;
    [SerializeField] private bool isGettingPoint;
    public void Grab(Vector3 currPos){
        isGrabbed = true;
        if(Vector3.Distance(this.transform.position,currPos) > 2)
        {
            StartCoroutine(LerpPosition(currPos, 1));
        }
        else
        {
            Debug.Log(Vector3.Distance(this.transform.position, currPos));
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
            
            this.GetComponent<Rigidbody>().velocity = 3*OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
        }
        if(transform.position.y < -1)
        {
            this.transform.position = new Vector3(transform.position.x, -1, transform.position.z);
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = false;
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
    }

    public void OnTriggerEnter(Collider col)
    {
        /*while(col.tag == "Hoop") May cause crashes
        {
            isGettingPoint = true;          
        }
        if (isGettingPoint)
        {
            Debug.Log("Point");
            isGettingPoint = false;
        }*/
        
    }
}
