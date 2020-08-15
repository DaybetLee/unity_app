using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsBack1 : MonoBehaviour
{
    public string aboutMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackBtn()
    {
        SceneManager.LoadScene(aboutMenu);
        AudioManager.instance.PlaySFX(1);
    }
}
