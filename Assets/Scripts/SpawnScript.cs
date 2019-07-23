using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    ObjectPooler pooler;
	// Use this for initialization
	void Start () {
        pooler = ObjectPooler.Instance;
	}
	
	// Update is called once per frame
	void Update () {

        pooler.SpawnFromPool("Crate",transform.position,transform.rotation);

    }
}
