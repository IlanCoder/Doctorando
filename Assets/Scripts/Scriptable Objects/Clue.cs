using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clues {
  [CreateAssetMenu(menuName = "Clue", order = 1)]
  public class Clue : ScriptableObject {
		#region ENUMS
		public enum SHAPE {
			NONE = 0,
			CIRCLE = 1,
			SQUARE = 2,
			TRIANGLE = 3
		}

		public enum COLOR {
			NONE = 0,
			RED = 1,
			BLUE = 2,
			GREEN = 3
		}
		#endregion

		#region VARS
		public Sprite sprite;
		[SerializeField] private SHAPE clueShape;
		[SerializeField] private COLOR clueColor;
		#endregion

		#region PUBLIC_FUNCTIONS
		public bool HasShape(out SHAPE shape) {
			shape = clueShape;
			if (clueShape == SHAPE.NONE) return false;
			return true;
		}

		public bool HasColor(out COLOR color) {
			color = clueColor;
			if (clueColor == COLOR.NONE) return false;
			return true;
		}
		#endregion
	}
}
