using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public GameObject levelChanger;
    public GameObject exitPanel;

    // Use this for initialization
    private void Update()
    {
        if (levelChanger.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            levelChanger.SetActive(false);
        }
        if(exitPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(false);
        }
    }

    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void OnClickStartLevel()
    {
        //SceneManager.LoadScene(1);
        levelChanger.SetActive(true);
    }
    public void levelBtn(int levels)
    {
        SceneManager.LoadScene(levels);
    }
    public void OnClickExitPanel()
    {
        exitPanel.SetActive(true);
        //Application.Quit();
    }

    public void _returnBack()
    {
        exitPanel.SetActive(false);
    }

    public void _Exit()
    {
        Application.Quit();
    }
}
