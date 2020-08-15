using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public int musicToPlay;

    public static bool GameIsPaused = false;
    public bool isThereVideo = true;

    public Button sfxIcon;
    public Button musicIcon;

    private VideoPlayer videoPlayer;

    public Sprite sfxIcon_1;
    public Sprite sfxIcon_2;
    public Sprite musicIcon_1;
    public Sprite musicIcon_2;


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        ChangeMusicIcon();
        ChangeSoundIcon();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            if (isThereVideo)
                videoPlayer.Play();
    }

    public void MainMenuBtn()
    {
        SceneLoader.instance.LoadNextScene("MainMenu");
        AudioManager.instance.PlaySFX(1);
        Time.timeScale = 1f;
        if(isThereVideo)
            videoPlayer.Stop();
    }

    public void PauseBtn()
    {
        pauseMenu.SetActive(true);
        AudioManager.instance.PlaySFX(1);
        Time.timeScale = 0f;
        if (isThereVideo)
            videoPlayer.Pause();
    }

    public void BackBtn()
    {
        pauseMenu.SetActive(false);
        AudioManager.instance.PlaySFX(1);
        Time.timeScale = 1f;
        if (isThereVideo)
            videoPlayer.Play();
    }

    public void MusicBtn()
    {
        if (!AudioManager.instance.musicPlay)
            AudioManager.instance.musicPlay = true;
        else AudioManager.instance.musicPlay = false;

        if (AudioManager.instance.musicPlay == true)
            musicIcon.GetComponent<Image>().sprite = musicIcon_1;

        ChangeMusicIcon();

        AudioManager.instance.PlaySFX(1);
    }

    public void SFXBtn()
    {
        if (!AudioManager.instance.sfxPlay)
            AudioManager.instance.sfxPlay = true;
        else AudioManager.instance.sfxPlay = false;

        ChangeSoundIcon();

        AudioManager.instance.PlaySFX(1);
    }

    private void ChangeMusicIcon()
    {
        if (AudioManager.instance.musicPlay == true)
        {
            AudioManager.instance.PlayBGM(musicToPlay);
            musicIcon.GetComponent<Image>().sprite = musicIcon_1;
        }
        else
            musicIcon.GetComponent<Image>().sprite = musicIcon_2;
    }

    private void ChangeSoundIcon()
    {
        if (AudioManager.instance.sfxPlay == true)
        {
            sfxIcon.GetComponent<Image>().sprite = sfxIcon_1;
        }
        else
            sfxIcon.GetComponent<Image>().sprite = sfxIcon_2;
    }
}
