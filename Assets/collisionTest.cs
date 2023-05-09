using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit " + this.name);
    }
}
