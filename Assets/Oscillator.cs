using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

	public double frequency = 440.0;
	public float gain;
	public float volume;
	public float noteLength;
	public float[] frequencies;
	public int thisFreq;
	public bool ballHit;
	public enum Waveform {sine, square};
	public Waveform myWave;

	private bool playingSound = false;
	private bool readyToPlay = true;
	private float timeSinceNoteStarted;
	private double increment;
	private double phase;
	private double samplingFrequency = 48000.0;



	void Start()
	{
		frequencies = new float[8];
		frequencies [0] = 440;
		frequencies [1] = 494;
		frequencies [2] = 554;
		frequencies [3] = 587;
		frequencies [4] = 659;
		frequencies [5] = 740;
		frequencies [6] = 831;
		frequencies [7] = 880;
	}

	void Update()
	{
		if (playingSound)
		{
			readyToPlay = false;
			timeSinceNoteStarted += Time.deltaTime;
		
		}
		if (timeSinceNoteStarted >= noteLength){
			readyToPlay = true;
			timeSinceNoteStarted = 0f;
			StopSound();
			playingSound = false;
		}

	}


	public void PlaySound (int note)
	{
		
//		if (readyToPlay){
//			Debug.Log("PlaySound called. Note: " + note.ToString());
//			gain = volume;
//			frequency = frequencies [note];
//			playingSound = true;
//		}	

		gain = volume;
		frequency = frequencies [note];
	}


	public void StopSound(){
		gain = 0f;
		//thisFreq += 1;
		//thisFreq = thisFreq % frequencies.Length;
	}
	void OnAudioFilterRead(float [] data, int channels)
	{
		increment = frequency * 2.0 * Mathf.PI / samplingFrequency;

		for (int i = 0; i < data.Length; i += channels) {
			phase += increment;
			if (myWave == Waveform.sine) { 
				data [i] = (float)(gain * Mathf.Sin ((float)phase));
			} else if (myWave == Waveform.square) {
				if (gain * Mathf.Sin ((float)phase) >= 0 * gain) {
					data [i] = (float)gain * 0.6f;
				} else {
					data [i] = (-(float)gain) * 0.6f;
				}
			}
			if (channels == 2) {
				data [i + 1] = data [i];
			}

			if (phase > (Mathf.PI * 2)) {
				phase = 0.0;
			}
		}
	}

}
