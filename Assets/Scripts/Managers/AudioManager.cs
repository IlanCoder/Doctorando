using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource scienceTrack;
	public AudioSource alchemyTrack;

	private void OnEnable() {
		DualityManager.OnGetDualityScore += CalculateDualitySong;
	}

	private void OnDisable() {
		DualityManager.OnGetDualityScore -= CalculateDualitySong;
	}

	void CalculateDualitySong(float dualityScore) {
		dualityScore /= 20;
		scienceTrack.volume = 0.5f + dualityScore;
		alchemyTrack.volume = 0.5f - dualityScore;
	}
}
