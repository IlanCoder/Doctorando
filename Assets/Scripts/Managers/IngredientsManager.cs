using System;
using System.Collections.Generic;
using UnityEngine;
using Ingredients;

public class IngredientsManager : MonoBehaviour {
  [SerializeField] List<IngredientsGroup> ingGroups = new List<IngredientsGroup>();

	public static event Action OnUnlockGroup;

	private void Awake() {
		foreach(IngredientsGroup group in ingGroups) {
			foreach(Ingredient ingredient in group.IngredientsInGroup) {
				ingredient.unlocked = false;
			}
		}
	}

	private void OnEnable() => FormulasManager.OnIndexChanged += UnlockGroup;
	private void OnDisable() => FormulasManager.OnIndexChanged -= UnlockGroup;

	void UnlockGroup(int index) {
		if (index >= ingGroups.Count) return;
		foreach(Ingredient ingredient in ingGroups[index].IngredientsInGroup) {
			ingredient.Unlock();
		}
		OnUnlockGroup?.Invoke();
	}
}
