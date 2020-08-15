using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{

    public Text dialogText;

    public string[] dialogLines;

    public int currentLines;

    public GameObject bCell;

    public GameObject tCell;

    public GameObject pauseMenu;

    private bool isGamepaused;

    // Start is called before the first frame update
    void Start()
    {
            dialogText.text = dialogLines[currentLines];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !pauseMenu.activeSelf)
        {
            currentLines++;

            if (currentLines < dialogLines.Length)
            {
                dialogText.text = dialogLines[currentLines];
            }
            if (currentLines == 7)
                tCell.SetActive(true);
            if (currentLines == 8)
                bCell.SetActive(true);
            if (currentLines == 9)
                AudioManager.instance.PlaySFX(2);
            if (currentLines == 14)
               SceneLoader.instance.LoadNextScene("Story 1 Game Instruction");
        }
    }
}
