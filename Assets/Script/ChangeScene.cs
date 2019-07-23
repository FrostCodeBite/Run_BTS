using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public void changeScene(string sceneName)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(sceneName);
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
