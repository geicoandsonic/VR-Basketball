using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderDetection : MonoBehaviour
{
    public GameObject coloredSegement;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "PlayerHand")
        {
            Debug.Log("entered space");
            fly.Instance.segmentIndex = horseGamemode.Instance.checkHorseSegment(other.transform);
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
