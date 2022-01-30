using System;
using System.Collections.Generic;
using UnityEngine;
using Ingredients;

[RequireComponent(typeof(SpriteRenderer))]
public class IngredientView : MonoBehaviour
{
	SpriteRenderer spriteRenderer;
	[SerializeField] Ingredient ingredient;

	public static event Action<Ingredient> OnIngredientSelected;

	private void OnEnable() => IngredientsManager.OnUnlockGroup += TryUnlock;
	private void OnDisable() => IngredientsManager.OnUnlockGroup -= TryUnlock;

	private void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = ingredient.sprite;
		spriteRenderer.enabled = false;
	}

	void TryUnlock() {
		if (ingredient.unlocked == spriteRenderer.enabled) return;
		spriteRenderer.enabled = ingredient.unlocked;
	}

	public void AddToFormula() {
		OnIngredientSelected.Invoke(ingredient);
	}
}
