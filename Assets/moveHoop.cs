using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHoop : MonoBehaviour
{

    public List<Transform> teleportLocations = new List<Transform>();
    public Transform hoop;
    public float speed;
    private bool spotChosen;
    private int prevSpot = -1;
    private int spot = -2;
    // Start is called before the first frame update
    void Start()
    {
        spotChosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spotChosen)
        {
            spot = Random.Range(0, teleportLocations.Count-1);
            if (spot == prevSpot) //Make sure that the spot we lerp to is not the same as the previous one
            {
                spot += 1;
                if (spot > teleportLocations.Count)
                {
                    spot = 0;
                }
                
            }
            prevSpot = spot;
            spotChosen = true;
        }        
        var step = speed * Time.deltaTime;
        hoop.position = Vector3.MoveTowards(hoop.position, teleportLocations[spot].position, step);
        if (Vector3.Distance(hoop.position, teleportLocations[spot].position) < 0.001f)
        {
            hoop.position = teleportLocations[spot].position;
            spot = -2;
            spotChosen = false;
        }
    }
}
