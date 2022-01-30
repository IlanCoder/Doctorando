using System;
using System.Collections.Generic;
using UnityEngine;
using Formulas;
using Ingredients;

public class DualityManager : MonoBehaviour {
  [SerializeField]float currentDualityValue = 0;
  public float DualityValue { get { return currentDualityValue; } }

  public static event Action<float> OnGetDualityScore;

  private void OnEnable() => Formula.OnFormulaSolve += CalculateRoundDuality;

  private void OnDisable() => Formula.OnFormulaSolve -= CalculateRoundDuality;

  void CalculateRoundDuality(List<Ingredient> ingredients) {
    if (ingredients.Count <= 0) return;
    Ingredient.DUALITY roundDuality = ingredients[0].IngredientDuality;
    for(int i = 1; i < ingredients.Count; i++) {
      if (roundDuality != ingredients[i].IngredientDuality)
        return;
		}
    float roundScore = GetDualityScore(ingredients);
		switch (roundDuality) {
      case Ingredient.DUALITY.ALCHEMY:
        currentDualityValue -= roundScore;
        break;
      case Ingredient.DUALITY.SCIENCE:
        currentDualityValue += roundScore;
        break;
		}
    OnGetDualityScore?.Invoke(currentDualityValue);
	}

 float GetDualityScore(List<Ingredient> ingredients) {
    float roundScore = 0;
    foreach(Ingredient ingredient in ingredients) {
      if (ingredient.used) continue;
			if (ingredient.IngredientQuality == Ingredient.QUALITY.GOOD) {
        roundScore++;
        continue;
			}
      roundScore += 0.5f;
      ingredient.used = true;
		}
    return roundScore;
	}
}
