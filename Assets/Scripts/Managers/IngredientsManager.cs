using System;
using System.Collections.Generic;
using UnityEngine;
using Ingredients;

public class IngredientsManager : MonoBehaviour {
  [SerializeField] List<IngredientsGroup> ingGroups = new List<IngredientsGroup>();

	public static event Action OnUnlockGroup;

	private void OnEnable() => FormulasManager.OnIndexChanged += UnlockGroup;
	private void OnDisable() => FormulasManager.OnIndexChanged -= UnlockGroup;

	void UnlockGroup(int index) {
		if (index >= ingGroups.Count) return;
		foreach(Ingredient ingredient in ingGroups[index].IngredientsInGroup) {
			ingredient.unlocked = true;
		}
		OnUnlockGroup?.Invoke();
	}
}
