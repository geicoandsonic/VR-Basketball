using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderDetection : MonoBehaviour
{
    public GameObject coloredSegement;
    public int indexVal;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "PlayerHand")
        {
            Debug.Log("entered space");
            fly.Instance.segmentIndex = indexVal;
            coloredSegement.GetComponent<MeshRenderer>().enabled = true;          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerHand")
        {
            Debug.Log("Left space");
            coloredSegement.GetComponent<MeshRenderer>().enabled = false;
            
        }
    }
}
