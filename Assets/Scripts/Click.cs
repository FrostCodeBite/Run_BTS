using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    public bool ClickedIs = false;

    void OnMouseDown()
    {
        ClickedIs = true;
    }

    void OnMouseUp()
    {
        ClickedIs = false;
    }
}
