using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject readygo;
    public GameObject joystick;
    public GameObject gameover;
    public GameObject winning;
    public bool gameEnd = false;
    public GameObject winningScore;
    public bool arcadeGame = false;
    public int level = 1;
    public Dictionary<string, string[]> highscore;

    //testing


    // Start is called before the first frame update
    void Start()
    {
        readygo.SetActive(true);
        StartCoroutine(InitiateGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownController.instance.timerEnded == true && PlayerController.instance.virusEaten == false)
        {
            gameover.SetActive(true);
            joystick.SetActive(false);
        }
        else if (CountdownController.instance.timerEnded == false && PlayerController.instance.virusEaten == true)
        {
            winning.SetActive(true);
            joystick.SetActive(false);
            winningScore.GetComponent<Text>().text = (60 - CountdownController.instance.secondsLeft) + " Seconds";
            if (!arcadeGame)
            {
                SavePlayer();
            }
            else
            { 
                ///
            }
        }


    }

    IEnumerator InitiateGame()
    {
        yield return new WaitForSeconds(4);
        joystick.SetActive(true);
        CountdownController.instance.startTimer = true;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
}
