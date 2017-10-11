using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionField : MonoBehaviour {
	private Oscillator myOsc;
	// Use this for initialization
	void Start () {
		myOsc = GetComponent<Oscillator>();
	}

	void OnCollisionStay(Collision col){
		if (col.gameObject.tag == "ball"){ 
			ContactPoint contactPoint = col.contacts[0];
			Debug.Log("Collision at: " + contactPoint.point);
			if (contactPoint.point.y < 1.2) {
				myOsc.PlaySound (0);
			} else if (contactPoint.point.y < 1.4) {
				myOsc.PlaySound (1);
			} else if (contactPoint.point.y < 1.6) {
				myOsc.PlaySound (2);
			} else if (contactPoint.point.y < 1.8) {
				myOsc.PlaySound (3);
			} else if (contactPoint.point.y < 2) {
				myOsc.PlaySound (4);
			} 
		}
	}

	void OnCollisionExit(){
		myOsc.StopSound();
	}
}
