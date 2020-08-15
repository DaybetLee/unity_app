using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{

    public GameObject textDisplay;
    public int secondsLeft = 59;
    public bool deduction = false;
    public bool startTimer = false;
    public bool timerEnded = false;

    public static CountdownController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        textDisplay.GetComponent<Text>().text = "01:00";
    }

    // Update is called once per frame
    void Update()
    {
        if (deduction == false && secondsLeft > 0 && startTimer == true)
        {
            StartCoroutine(Countdown());
        }else if (secondsLeft == 0)
            timerEnded = true;
    }

    IEnumerator Countdown()
    {
        deduction= true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;

        deduction = false;
    }
}
