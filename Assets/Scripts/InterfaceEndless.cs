using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceEndless : MonoBehaviour {

    public CarScriptWithoutFinish car;
    public Text distanceText;
    public Image[] stars;
    public string keyname = "S";

    private bool isPause = false;
    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
        if (car.finishPanel.activeSelf)
        {
            PlayerPrefs.SetFloat(keyname, car.distanceTarget);
            PlayerPrefs.Save();

            for (int i = 0; i < car.controlCars.Length; i++)
            {
                car.controlCars[i].ClickedIs = false;
                car.controlCars[i].gameObject.SetActive(false);
            }
            distanceText.text = "Your Distance: " + car.distanceTarget.ToString() + " Km";

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
            /*else if (Input.GetMouseButtonDown(1))
            {
                SceneManager.LoadScene(1);
            }*/
            if (car.distanceTarget >= Mathf.Round(0f) && car.distanceTarget <= Mathf.Round(40f))
            {
                stars[0].color = new Color(stars[0].color.r, stars[0].color.g, stars[0].color.b, 255);
                if (PlayerPrefs.GetFloat(keyname) != 3f && PlayerPrefs.GetFloat(keyname) != 2f)
                {
                    PlayerPrefs.SetFloat(keyname, 1f);
                    PlayerPrefs.Save();
                }

            }
            else if (car.distanceTarget > Mathf.Round(40f) && car.distanceTarget <= Mathf.Round(60f))
            {
                stars[0].color = new Color(stars[0].color.r, stars[0].color.g, stars[0].color.b, 255);
                stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
                if (PlayerPrefs.GetFloat(keyname) != 3f)
                {
                    PlayerPrefs.SetFloat(keyname, 2f);
                    PlayerPrefs.Save();
                }
            }
            else if (car.distanceTarget > Mathf.Round(60f) && car.distanceTarget <= Mathf.Round(75f))
            {
                stars[0].color = new Color(stars[0].color.r, stars[0].color.g, stars[0].color.b, 255);
                stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
                stars[2].color = new Color(stars[2].color.r, stars[2].color.g, stars[2].color.b, 255);
                PlayerPrefs.SetFloat(keyname, 3f);
                PlayerPrefs.Save();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isPause && !car.finishPanel.activeSelf)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
    }

    public void _Retry()
    {
        SceneManager.LoadScene("PlayChampionScene");
    }
    public void pauseOn()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isPause = true;
    }

    public void _continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
    }

    public void goToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
