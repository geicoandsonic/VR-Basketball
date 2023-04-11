using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private bool hasChanged = false;
    public void Highlight(){
        if(hasChanged){
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.white);
        }
        else{
            this.gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
        }
        hasChanged = !hasChanged;
    }
}
