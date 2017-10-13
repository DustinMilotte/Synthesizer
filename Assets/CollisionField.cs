using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionField : MonoBehaviour {
	private Oscillator myOsc;
	private SynthControl mySynthControl;

	public GameObject RightControllerParticleSystem;
	private ParticleSystem particles;

	void Start () {
		myOsc = GetComponent<Oscillator>();
		mySynthControl = GetComponent<SynthControl>();
		//RightControllerParticleSystem = GameObject.Find("RightControllerParticleSystem");
		particles = RightControllerParticleSystem.GetComponent<ParticleSystem>();
	}

	void OnTriggerStay(Collider col){ 
		Vector3 colPos = col.gameObject.transform.position;
		Debug.Log("Collision with " + col.gameObject.name);
		if (colPos.y < 1.2) {
				myOsc.PlaySound (0);
		} else if (colPos.y < 1.4) {
				myOsc.PlaySound (1);
		} else if (colPos.y < 1.6) {
				myOsc.PlaySound (2);
		} else if (colPos.y < 1.8) {
				myOsc.PlaySound (3);
		} else if (colPos.y < 2) {
			myOsc.PlaySound (4);
		} 

		mySynthControl.SetVolume(Mathf.Lerp(-80f, 0f, colPos.z));
		mySynthControl.SetCutoff(Mathf.Lerp(100f, 15000f, colPos.x));


		particles.Play();

	}

	void OnTriggerExit(){
		myOsc.StopSound();
		particles.Stop();
		Debug.Log("triggerexit");
	}
}
