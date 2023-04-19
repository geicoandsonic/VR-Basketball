using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    [SerializeField] private bool isGettingPoint;
    public void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Basketball")
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
}
