using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTankController : MonoBehaviour {
    public AudioSource shot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F)) {
            shot.Stop();
            shot.pitch = Random.Range(0.8f, 1.2f);
            shot.Play();
        }
	}
}
