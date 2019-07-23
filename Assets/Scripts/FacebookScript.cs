using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookScript : MonoBehaviour {

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    Debug.LogError("Couldn't initiated");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            }
            );
        }
        else
            FB.ActivateApp();
    }

    public void FacebookShare()
    {
        FB.ShareLink(new System.Uri("https://www.facebook.com/"), "Check it out!",
            "Newly releasing Apps",
            new System.Uri("https://www.facebook.com/kim.sopagnaphea"));
    }
}
