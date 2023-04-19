
using System;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{

    public GameObject selectedObject;
    public GameObject grabbedObject;
    public GameObject RCatcher;
    public static ControllerManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        GetButtonPressed();
        GetTriggerPressed();
    }
    public bool GetTriggerPressed(){
        if((OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0 || OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0))
        {
            GrabObject();
            return true;
        }
        else{
            if(grabbedObject != null)
            {
                if(grabbedObject.gameObject.TryGetComponent(out GrabbableObject grabby)){
                    grabby.releaseGrab();
                }
            }
            grabbedObject = null;
            return false;
        }
    }

    public void GrabObject(){
        Vector3 currPos = GetPosition();
        if (grabbedObject == null)
        {
            currPos = GetPosition();
            int layerMask = 1 << 6;
            Collider[] nearbyObj = Physics.OverlapSphere(currPos, 20, layerMask);
            float smallestDistance = 20.5f;
            foreach (var col in nearbyObj)
            {
                float temp = Vector3.Distance(col.transform.position, currPos);
                if (smallestDistance > temp)
                {
                    smallestDistance = temp;
                    Debug.Log(col.name);
                    grabbedObject = col.gameObject;
                }

            }
        }
        if(grabbedObject != null){
            if(grabbedObject.gameObject.TryGetComponent(out GrabbableObject grabby)){
                grabby.Grab(RCatcher.transform.position);
            }
        }
        
    }

    public Vector3 GetPointingDir(){
        return this.transform.TransformDirection(Vector3.forward);
    }

    public Vector3 GetPosition(){
        return this.transform.position;
    }

    public bool GetButtonPressed(){
        if(OVRInput.GetUp(OVRInput.Button.Any)){
            CastRay();
            return true;
        }
        return false;
    }

    public void CastRay(){
        RaycastHit hit;
        Vector3 forwardRay = GetPointingDir();
        if (Physics.Raycast(transform.position, forwardRay, out hit, 10)){
            selectedObject = hit.collider.gameObject;
            if(selectedObject.gameObject.TryGetComponent(out SelectableObject selecty)){
                selecty.Highlight();
            }
        }
        else{
            selectedObject = null;
        }
    }
}
