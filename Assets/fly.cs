using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public static fly Instance;
    public float speed = .2f;
    private float movementX;
    private float movementY;
    private float rotationX;
    private float rotationY;
    public int segmentIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thumbRightOutput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick); //For movement
        movementX = thumbRightOutput.x;
        movementY = thumbRightOutput.y;

        rotationX = rotationY = 0;
        Vector2 thumbLeftOutput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        rotationX = thumbLeftOutput.x;
        rotationY = thumbLeftOutput.y;
        this.transform.Rotate(0, this.transform.rotation.y + rotationX, 0);

        this.transform.position = new Vector3(transform.position.x +
            speed * -movementY, transform.position.y, transform.position.z
             + speed * movementX);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "HorseSpace")
        {
            segmentIndex = horseGamemode.Instance.checkHorseSegment(this.transform);
            col.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "HorseSpace")
        {
            col.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }


}
