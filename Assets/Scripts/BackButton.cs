using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public string backScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.instance.LoadNextScene(backScene);
        }
    }
    public void BackBtn()
    {
        SceneLoader.instance.LoadNextScene(backScene);

        AudioManager.instance.PlaySFX(1);
    }
}
