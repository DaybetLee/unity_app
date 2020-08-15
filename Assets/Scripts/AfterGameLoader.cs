using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterGameLoader : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuBtn()
    {
        SceneLoader.instance.LoadNextScene("MainMenu");
        AudioManager.instance.PlaySFX(1);
    }

    public void retryBtn()
    {
        SceneLoader.instance.LoadNextScene("GameMaze");
        AudioManager.instance.PlaySFX(1);
    }

    public void continueBtn()
    {
        SceneLoader.instance.LoadNextScene("EndOfPrototypeGame");
        AudioManager.instance.PlaySFX(1);
    }
}
