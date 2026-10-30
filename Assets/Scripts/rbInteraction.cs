using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class rbInteraction : MonoBehaviour
{
    public GoldManager goldMan;
    public TextMeshProUGUI currentGold;
    public TextMeshProUGUI totalGold;

    public TextMeshProUGUI timerTex;
    public float remainingTIme;
    public bool timerToggle = true;
    
    // worst code ive written in my life
    // checks for a tag and does an appropriate action if its detected
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            goldMan.goldCountCurrent += 5;
            print("got 5 gold");
        }
        else if (other.gameObject.CompareTag("GoldBig"))
        {
            Destroy(other.gameObject);
            goldMan.goldCountCurrent += 15;
            print("got 15 gold");
        }
        else if (other.gameObject.CompareTag("GoldHuge"))
        {
            Destroy(other.gameObject);
            goldMan.goldCountCurrent += 45;
            print("got 45 gold");
        }
        else if (other.gameObject.CompareTag("DepositBox"))
        {
            print("deposit here");
            //only deposit if you have more than 0 gold
            if (goldMan.goldCountCurrent > 0)
            {
                goldMan.goldCountTotal += goldMan.goldCountCurrent;
                //extra time bonus
                remainingTIme += (goldMan.goldCountCurrent + 20);
                goldMan.goldCountCurrent = 0;
                // go to win screen if you have enough
                if (goldMan.goldCountTotal > 250)
                {
                    SceneManager.LoadScene("Win");
                }
            }
        }
        else if (other.gameObject.CompareTag("Vehicle"))
        {
            //you got hit by car
            print("vehicle");
            kill();
        }
        else if (other.gameObject.CompareTag("Start"))
        {
            print("load scene");
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.gameObject.CompareTag("Quit"))
        {
            print("quit");
            Application.Quit();
        }
        currentGold.text = goldMan.goldCountCurrent.ToString();
        totalGold.text = goldMan.goldCountTotal.ToString();

    }
    
    void Start() {
        if (GameObject.Find("GoldCounter"))
        {
            GameObject curGol = GameObject.Find("GoldCounter");
            currentGold = curGol.GetComponent<TextMeshProUGUI>();
            currentGold.text = "0";
        }

        if (GameObject.Find("GoldCounterTotal"))
        {
            GameObject totGol = GameObject.Find("GoldCounterTotal");
            totalGold = totGol.GetComponent<TextMeshProUGUI>();
            totalGold.text = "0";
        }
    }
    void Update()
    {
        //checks if timer should run
        if (goldMan.inCutscene) { timerToggle = false; timerTex.text = ""; }
        else timerToggle = true;

        //countdown timer code
        if (timerToggle)
        {
            if (remainingTIme >= 0)
            {
                remainingTIme -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(remainingTIme / 60);
                int seconds = Mathf.FloorToInt(remainingTIme % 60);
                timerTex.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (remainingTIme < 0)
            {
                timerToggle = false;
                remainingTIme = 0;
                timerTex.text = "TIMES UP";
                print("no time");
                //timerTex.color = Color.red;
                kill();
            }            
        }
    }

    void kill()
    {
        SceneManager.LoadScene("Lose");
    }
}
