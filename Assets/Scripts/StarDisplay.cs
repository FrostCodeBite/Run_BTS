using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    private Image[] stars;
    public string keyname="S";
    public Button[] bttns;
    public int levelChanger = 0;
    private MenuScript ms;

    // Use this for initialization
    void Awake()
    {
        stars = GetComponentsInChildren<Image>();
        ms = Camera.main.GetComponent<MenuScript>();
        bttns = ms.levelChanger.GetComponentsInChildren<Button>();
    }
    void Start () {
        if (PlayerPrefs.GetFloat(keyname) == 1f)
        {
            stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
        }
        else if (PlayerPrefs.GetFloat(keyname)==2f)
        {
            int unlockLevel = levelChanger + 1;
            bttns[unlockLevel].interactable = true;
            stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
            stars[2].color = new Color(stars[2].color.r, stars[2].color.g, stars[2].color.b, 255);
        }
        else if (PlayerPrefs.GetFloat(keyname) == 3f)
        {
            int unlockLevel = levelChanger + 1;
            bttns[unlockLevel].interactable = true;
            stars[1].color = new Color(stars[1].color.r, stars[1].color.g, stars[1].color.b, 255);
            stars[2].color = new Color(stars[2].color.r, stars[2].color.g, stars[2].color.b, 255);
            stars[3].color = new Color(stars[3].color.r, stars[3].color.g, stars[3].color.b, 255);
        }
	}

}
