using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingredients {
	[CreateAssetMenu(menuName = "Ingredient Group", order = 4)]
	public class IngredientsGroup : ScriptableObject {
		#region VARS
		[SerializeField] List<Ingredient> ingredientsInGroup = new List<Ingredient>();
		public List<Ingredient> IngredientsInGroup { get { return ingredientsInGroup; } }
		#endregion
	}
}
