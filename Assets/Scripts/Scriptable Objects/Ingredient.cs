using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clues;

namespace Ingredients {
  [CreateAssetMenu(menuName = "Ingredient", order = 3)]
  public class Ingredient : ScriptableObject {
		#region ENUMS
		public enum DUALITY {
			SCIENCE = 0,
			ALCHEMY = 1
		}

		public enum QUALITY {
			GOOD = 0,
			BAD = 1
		}
		#endregion

		#region VARS
		public Sprite sprite;
		[SerializeField] DUALITY ingredientDuality;
		public DUALITY IngredientDuality { get { return ingredientDuality; } }
		[SerializeField] QUALITY ingredientQuality;
		public QUALITY IngredientQuality { get { return ingredientQuality; } }
		[SerializeField] Clue.SHAPE ingredientShape;
		public Clue.SHAPE IngredientShape { get { return ingredientShape; } }
		[SerializeField] Clue.COLOR ingredientColor;
		public Clue.COLOR IngredientColor { get { return ingredientColor; } }

		public bool unlocked = false;
		public bool used = false;
		#endregion

		public void Unlock() {
			unlocked = true;
			used = false;
		}
	}
}
