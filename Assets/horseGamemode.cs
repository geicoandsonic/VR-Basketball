using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horseGamemode : MonoBehaviour
{
    public Transform[] segmentLocations;
    public static horseGamemode Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update

    // Update is called once per frame

    public int checkHorseSegment(Transform player)
    {
        float dist = 500f;
        int index = -1;
        int countOfSeg = 0;
        foreach(Transform segment in segmentLocations)
        {
            float distBetween = Vector3.Distance(player.position, segment.position);
            if(distBetween < dist)
            {
                dist = distBetween;
                index = countOfSeg;
            }
            countOfSeg++;
        }
        return index;
    }
}
