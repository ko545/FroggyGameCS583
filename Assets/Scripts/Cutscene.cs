using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Cutscene : MonoBehaviour
{
    public TextMeshProUGUI textHere;
    private int index = 0;
    public GoldManager goldMan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.Find("TextTMP"))
        {
            //used to stop the player from moving and hiding the timer
            goldMan.inCutscene = true;
            GameObject text = GameObject.Find("TextTMP");
            textHere = text.GetComponent<TextMeshProUGUI>();
            textHere.color = Color.brown;
            textHere.text = "HI! I'M YOUR FRIENDLY NEIGHBORHOOD PYRAMID SCHEMER";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (index <= 7)
        {
            //advance text when any input is pressed
            //this is really scuffed
            if (Input.anyKeyDown)
            {
                index++;
            }
            else if (index == 1)
            {
                textHere.color = Color.darkCyan;
                textHere.text = "SORRY I'M NOT INTERESTE--";
            }
            else if (index == 2)
            {
                textHere.color = Color.brown;
                textHere.text = "TOO LATE YOU OWE ME 250 GOLD";
            }
            else if (index == 3)
            {
                textHere.color = Color.darkCyan;
                textHere.text = "NOOOOOOOOOOOOOOOOOOOOOOOOO";
            }
            else if (index == 4)
            {
                textHere.color = Color.brown;
                textHere.text = "GO COLLECT GOLD AND DEPOSIT IT IN MY BLUE BOX";
            }
            else if (index == 5)
            {
                textHere.color = Color.brown;
                textHere.text = "YOU HAVE 90 SECONDS";
            }
            else if (index == 6)
            {
                textHere.color = Color.darkCyan;
                textHere.text = ":(";
            }
            else if (index == 7)
            {
                textHere.color = Color.brown;
                textHere.text = "OK YOU GET A BIT OF EXTRA TIME EVERYTIME YOU DEPOSIT GOLD";
            }
        }
        else
        {
            //disable this when its done
            goldMan.inCutscene = false;
            gameObject.SetActive(false);
        } 
    }
}
