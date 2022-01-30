using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
	public Sprite badEnding;
	public Sprite scienceEnding;
	public Sprite mageEnding;
	public GameObject endingScreen;

	float mediocrityScore = 0;
	const int SCORE_ENDGAME_REQ = 10;

	private void OnEnable() {
		DualityManager.OnGetDualityScore += CalculateDualityEnding;
		FormulasManager.OnFormulasFinished += CalculateFormulasEnding;
		FormulasManager.OnFormulaSolved += CalculateMediocrity;
	}

	private void OnDisable() {
		DualityManager.OnGetDualityScore -= CalculateDualityEnding;
		FormulasManager.OnFormulasFinished -= CalculateFormulasEnding;
		FormulasManager.OnFormulaSolved -= CalculateMediocrity;
	}

	void CalculateDualityEnding(float dualityScore) {
		if (Mathf.Abs(dualityScore) >= SCORE_ENDGAME_REQ) {
			EnableGoodEnding(dualityScore);
		}
	}

	

	void CalculateFormulasEnding() {
		EnableBadEnding();
	}

	void CalculateMediocrity(float mediocrityValue) {
		mediocrityScore += mediocrityValue;
		if (mediocrityScore >= SCORE_ENDGAME_REQ) {
			EnableBadEnding();
		}
	}

	private void EnableGoodEnding(float dualityScore) {
		if (dualityScore < 0) {
			endingScreen.GetComponent<Image>().sprite = mageEnding;
		}
		else {
			endingScreen.GetComponent<Image>().sprite = scienceEnding;
		}
		endingScreen.SetActive(true);
	}

	private void EnableBadEnding() {
		endingScreen.GetComponent<Image>().sprite = badEnding;
		endingScreen.SetActive(true);
	}
}
