using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothCamera : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public GameObject background;
    
    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.75f, target.position.z));
            Vector3 delta = new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z)-GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        Vector3 positionBG = new Vector3(background.transform.position.x, background.transform.position.y, background.transform.position.z);
        positionBG.x = Camera.main.transform.position.x + 1f;
        background.transform.position = Vector3.SmoothDamp(background.transform.position, positionBG, ref velocity, 1f);
    }
}
