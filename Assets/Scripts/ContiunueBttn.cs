using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContiunueBttn : MonoBehaviour
{
    public GameObject continueBttn;
    public int waitTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivateButtn", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateButtn()
    {
        continueBttn.SetActive(true);
    }

    public void ContinueBtn()
    {
        SceneLoader.instance.LoadNextScene("GameMaze");

        AudioManager.instance.PlaySFX(1);
    }
}
