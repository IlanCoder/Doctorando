using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteManager : MonoBehaviour {
  enum SPRITEPHASE {
    NEUTRAL,
    ALCHEMY,
    SCIENCE
	}

  public SpriteRenderer character;
  public List<Sprite> maleSprites;
  public List<Sprite> femaleSprites;
  List<Sprite> selectedGenderSprites;
  [SerializeField] bool male;

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
        CheckFromNeutral(dualityScore);
        break;
      case SPRITEPHASE.SCIENCE:
        CheckFromNeutral(dualityScore);
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
		if (male) {
      character.sprite = maleSprites[(int)currentPhase];
      return;
		}
    character.sprite = femaleSprites[(int)currentPhase];
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
