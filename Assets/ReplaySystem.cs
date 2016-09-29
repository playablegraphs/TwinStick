using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames;
	private Rigidbody m_Rigidbody;
	public bool isPlayBack;
	void Awake (){
		keyFrames = new MyKeyFrame[bufferFrames];
	}
	void Start () {
		m_Rigidbody = GetComponent<Rigidbody> ();
		isPlayBack = false;
	}
	// Update is called once per frame
	void Update () {
		if (!isPlayBack) {
			Record ();
		}
		else if(isPlayBack){
			PlayBack ();
		}
	}
	void PlayBack(){
		m_Rigidbody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		if (keyFrames [frame] != null) {
			this.transform.position = keyFrames [frame].position;
			this.transform.rotation = keyFrames [frame].rotation;
		}
		print ("Playing Frame: " + frame);
	}
	void Record ()
	{
		m_Rigidbody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		keyFrames [frame] = new MyKeyFrame (time, this.transform.position, this.transform.rotation);
		print ("Recording Frame: " + frame);
	}
}
/// <summary>
/// A Class for storing time,position, and rotatin.
/// </summary>
public class MyKeyFrame{
	public float time;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame(float time,Vector3 position,Quaternion rotation){
		this.time = time;
		this.position = position;
		this.rotation = rotation;
	
	
	}

	
}

