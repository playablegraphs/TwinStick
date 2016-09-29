using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	private ReplaySystem replaySystem;
	// Use this for initialization
	void Start () {
		replaySystem = GameObject.FindObjectOfType<ReplaySystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (CrossPlatformInputManager.GetButton("Fire1")) {
			replaySystem.isPlayBack = true;
		} else
			replaySystem.isPlayBack = false;*/
	}
	public void setPlayback(bool boolean){
		replaySystem.isPlayBack = boolean;
	}

}
