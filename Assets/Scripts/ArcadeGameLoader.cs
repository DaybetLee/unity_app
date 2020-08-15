using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeGameLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeachandDestroyBtn()
    {

        SceneLoader.instance.LoadNextScene("ArcadeGameMaze");
        AudioManager.instance.PlaySFX(1);
    }

    public void Game2Btn()
    {


        AudioManager.instance.PlaySFX(1);
    }
}
