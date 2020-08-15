using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutMenu : MonoBehaviour
{
    public string optionMenu;
    public string credits;
    public string tnc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.instance.LoadNextScene(optionMenu);
        }
    }
    public void TnCBtn()
    {
        SceneManager.LoadScene(tnc);
        AudioManager.instance.PlaySFX(1);
    }
    public void CreditsBtn()
    {
        SceneManager.LoadScene(credits);
        AudioManager.instance.PlaySFX(1);
    }
    public void BackBtn()
    {
        SceneManager.LoadScene(optionMenu);
        AudioManager.instance.PlaySFX(1);
    }
}
