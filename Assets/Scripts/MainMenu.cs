using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string storyScene;
    public string optionMenu;
    public string gallery;
    public string leaderboard;
    public GameObject arcadeBtn;
    public GameObject startBtn;
    public GameObject menu;
    public int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
        //Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        if (level > 0)
            arcadeBtn.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StoryBtn()
    {
        SceneLoader.instance.LoadNextScene("Story_1");
        AudioManager.instance.PlaySFX(1);
    }

    public void ArcadeBtn()
    {
        SceneLoader.instance.LoadNextScene("Arcade");
        AudioManager.instance.PlaySFX(1);
    }
    public void GalleryBtn()
    {
        SceneLoader.instance.LoadNextScene("Gallery");
        AudioManager.instance.PlaySFX(1);
    }
    public void OptionBtn()
    {
        SceneLoader.instance.LoadNextScene("OptionMenu");

        AudioManager.instance.PlaySFX(1);
    }
    public void LeaderboardBtn()
    {
        SceneLoader.instance.LoadNextScene("LeaderBoard");

        AudioManager.instance.PlaySFX(1);
    }
    public void StartBtn()
    {
        startBtn.SetActive(false);
        menu.SetActive(true);

        AudioManager.instance.PlaySFX(1);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
    }

}
