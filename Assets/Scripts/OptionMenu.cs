using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public int musicToPlay;

    public Button sfxIcon;
    public Button musicIcon;
    public Button language;

    public Sprite sfxIcon_1;
    public Sprite sfxIcon_2;

    public Sprite musicIcon_1;
    public Sprite musicIcon_2;

    public Sprite language_1;
    public Sprite language_2;
    public Sprite language_3;
    public Sprite language_4;

    public GameObject dataClear;

    // Start is called before the first frame update
    void Start()
    {
        ChangeMusicIcon();
        ChangeSoundIcon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneLoader.instance.LoadNextScene("MainMenu");
        }
    }

    public void BackBtn()
    {
        SceneLoader.instance.LoadNextScene("MainMenu");
        AudioManager.instance.PlaySFX(1);
    }

    public void CreditBtn()
    {
        SceneLoader.instance.LoadNextScene("CreditsScene");
        AudioManager.instance.PlaySFX(1);
    }

    public void ResetBtn()
    {
        SaveSystem.ClearData();
        dataClear.SetActive(false);
        dataClear.SetActive(true);
        AudioManager.instance.PlaySFX(1);
    }

    public void LanguageBtn()
    {
        if (LanguageController.instance.languageCount < 4)
            LanguageController.instance.languageCount++;
        else LanguageController.instance.languageCount = 1;

        switch (LanguageController.instance.languageCount)
        {
            case 1:
                language.GetComponent<Image>().sprite = language_1;
                break;
            case 2:
                language.GetComponent<Image>().sprite = language_2;
                break;
            case 3:
                language.GetComponent<Image>().sprite = language_3;
                break;
            case 4:
                language.GetComponent<Image>().sprite = language_4;
                break;

        }
        AudioManager.instance.PlaySFX(1);
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
