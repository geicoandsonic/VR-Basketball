using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    public Image[] gameModePanels;
    public int index;
    public bool hasMoved;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        hasMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 thumbInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        if(thumbInput.y > 0 && !hasMoved)
        {
            hasMoved = true;
            gameModePanels[index].color = Color.white;
            index++;
            if(index > gameModePanels.Length-1)
            {
                index = 0;
            }
            gameModePanels[index].color = Color.yellow;
            StartCoroutine(wait(.2f));
        }
        else if(thumbInput.y < 0 && !hasMoved)
        {
            hasMoved = true;
            gameModePanels[index].color = Color.white;
            index--;
            if (index < 0)
            {
                index = gameModePanels.Length-1;
            }
            gameModePanels[index].color = Color.yellow;
            StartCoroutine(wait(.2f));
        }
        else if (OVRInput.Get(OVRInput.Button.One))
        {
            if(index != gameModePanels.Length - 1) //This implies you hit quit if the index is equal to gameModePanels.Length -1 since it is always last
            {
                SceneManager.LoadScene(index + 1); //Since index 0 is the intro scene
            }
            else
            {
                Application.Quit();
            }
        }
    }

    IEnumerator wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        hasMoved = false;
    }
}
