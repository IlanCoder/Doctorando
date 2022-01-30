using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clues;
using Ingredients;

namespace Formulas {
  [CreateAssetMenu(menuName = "Formula", order = 2)]
  public class Formula : ScriptableObject {
		#region VARS
		[SerializeField] List<Clue> clues = new List<Clue>();
    public List<Clue> Clues { get { return clues; } }
		[SerializeField]List<Ingredient> ingredients = new List<Ingredient>();
		#endregion

		#region OBSERVERS
		public static event Action<List<Ingredient>> OnFormulaSolve;
		public static event Action OnFormulaFull;
		#endregion

		#region PUBLIC_FUNCTIONS
		public void ClearIngredients() {
			ingredients.Clear();
		}

		public void AddIngredient(Ingredient ingredient) {
			if (ingredients.Count >= clues.Count) return;
			ingredients.Add(ingredient);
			if (ingredients.Count == clues.Count) {
				OnFormulaFull?.Invoke();
			}
		}

		public float SolveMediocrity() {
			float mediocrityLevel = 0;
			for(int i = 0; i < Clues.Count; i++) {
				Clue tempClue = Clues[i];
				if (tempClue.HasColor(out Clue.COLOR clueColor)) {
					mediocrityLevel += SolveColor(clueColor, ingredients[i]);
				}
				if (tempClue.HasShape(out Clue.SHAPE clueShape)) {
					mediocrityLevel += SolveShape(clueShape, ingredients[i]);
				}
			}
			OnFormulaSolve?.Invoke(ingredients);
			return mediocrityLevel;
		}
		#endregion

		#region PRIVATE_FUNCTIONS
		private float SolveColor(Clue.COLOR clueColor, Ingredient ingredient){
			if (clueColor != ingredient.IngredientColor) {
				return 1;
			}	
			if (ingredient.IngredientQuality == Ingredient.QUALITY.BAD) return 0.5f;
			return 0;
		}

		private float SolveShape(Clue.SHAPE clueShape, Ingredient ingredient) {
			if (clueShape != ingredient.IngredientShape) {
				return 1;
			}
			if (ingredient.IngredientQuality == Ingredient.QUALITY.BAD) return 0.5f;
			return 0;
		}
		#endregion
	}
}
