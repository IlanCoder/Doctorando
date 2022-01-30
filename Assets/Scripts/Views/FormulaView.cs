using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Formulas;

public class FormulaView : MonoBehaviour {
  [SerializeField] SpriteRenderer clue1;
  [SerializeField] SpriteRenderer clue2;

	private void OnEnable() => FormulasManager.OnFormulaChanged += ChangeClueSprites;
  private void OnDisable() => FormulasManager.OnFormulaChanged -= ChangeClueSprites;

  void ChangeClueSprites(Formula formula) {
    clue1.sprite = formula.Clues[0].sprite;
    clue2.sprite = formula.Clues[1].sprite;
  }
}
