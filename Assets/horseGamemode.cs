using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class horseGamemode : MonoBehaviour
{
    public Transform[] segmentLocations;
    public static horseGamemode Instance;
    public TMP_Text text;
    public TMP_Text timer;
    public float time = 0;
    public float finalTime = 0;
    public bool[] lettersGotten;
    public GameObject winScreen;
    public TMP_Text finalText;
    private void Awake()
    {
        Instance = this;
        lettersGotten = new bool[5];
        winScreen.SetActive(false);
    }

    public void Update()
    {
        time += Time.deltaTime;
        timer.text = time.ToString();
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
            Debug.Log(distBetween);
            if(distBetween < dist)
            {
                Debug.Log("Changing distance");
                dist = distBetween;
                index = countOfSeg;
            }
            countOfSeg++;
        }
        Debug.Log(index);
        return index;
    }

    public void getPoint(char letter)
    {
        switch (letter)
        {
            case ('H'):
                lettersGotten[0] = true;
                break;
            case ('O'):
                lettersGotten[1] = true;
                break;
            case ('R'):
                lettersGotten[2] = true;
                break;
            case ('S'):
                lettersGotten[3] = true;
                break;
            case ('E'):
                lettersGotten[4] = true;
                break;
        }
        updateUI();
    }

    public void updateUI()
    {
        int totalPoints = 0;
        text.text = "Score: ";
        int index = 0;
        foreach(bool letter in lettersGotten)
        {
            if(letter == true)
            {
                switch (index)
                {
                    case (0):
                        text.text += "H";
                        totalPoints += 1;
                        break;
                    case (1):
                        text.text += "O";
                        totalPoints += 1;
                        break;
                    case (2):
                        text.text += "R";
                        totalPoints += 1;
                        break;
                    case (3):
                        text.text += "S";
                        totalPoints += 1;
                        break;
                    case (4):
                        text.text += "E";
                        totalPoints += 1;
                        break;
                }
            }
            if(totalPoints == 5)
            {
                Win();
            }
            index++;
        }
    }

    public void Win()
    {
        finalTime = time;
        finalText.text = "Final time " + finalTime + " seconds. Great work!";
        timer.text = "";
        text.text = "";
        winScreen.SetActive(true);
    }
}
