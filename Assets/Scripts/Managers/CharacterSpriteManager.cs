using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteManager : MonoBehaviour {
  enum SPRITEPHASE {
    NEUTRAL,
    ALCHEMY,
    SCIENCE
	}

  public List<Sprite> MaleSprites;
  public List<Sprite> FemaleSprites;
  List<Sprite> selectedGenderSprites;

  SPRITEPHASE currentPhase = SPRITEPHASE.NEUTRAL;

  const int PHASE_CHANGE_VALUE = 6;

  void Awake() {
    //Check if female or male
  }

  private void OnEnable() => DualityManager.OnGetDualityScore += CheckNewDualitySprite;

  private void OnDisable() => DualityManager.OnGetDualityScore -= CheckNewDualitySprite;

  void CheckNewDualitySprite(float dualityScore) {
		switch (currentPhase) {
      case SPRITEPHASE.NEUTRAL:
        CheckBackToNeutral(dualityScore);
        break;
      case SPRITEPHASE.ALCHEMY:
        CheckBackToNeutral(dualityScore);
        break;
      case SPRITEPHASE.SCIENCE:
        CheckBackToNeutral(dualityScore);
        break;
		}
	}

  void CheckBackToNeutral(float dualityScore) {
    if(Mathf.Abs(dualityScore)< PHASE_CHANGE_VALUE) {
      ChangePhase(SPRITEPHASE.NEUTRAL);
		}
	}

  void ChangePhase(SPRITEPHASE newPhase) {
    currentPhase = newPhase;
    //ChangeSprite
	}

  void CheckFromNeutral(float dualityScore) {
    if (dualityScore >= PHASE_CHANGE_VALUE) {
      ChangePhase(SPRITEPHASE.SCIENCE);
      return;
    }
    if (dualityScore <= -PHASE_CHANGE_VALUE) {
      ChangePhase(SPRITEPHASE.ALCHEMY);
      return;
    }
  }
}
