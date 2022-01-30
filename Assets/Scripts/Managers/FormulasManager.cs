using System;
using System.Collections.Generic;
using UnityEngine;
using Formulas;

public class FormulasManager : MonoBehaviour {
  [SerializeField] List<Formula> formulas = new List<Formula>();
  int formulaIndex = -1;

  public static event Action OnFormulasFinished;
  public static event Action<float> OnFormulaSolved;
  public static event Action<int> OnIndexChanged;
  public static event Action<Formula> OnFormulaChanged;

  private void OnEnable() {
    Formula.OnFormulaFull += SolveFormula;
    IngredientView.OnIngredientSelected += AddIngredient;
  }
  private void OnDisable() {
    Formula.OnFormulaFull -= SolveFormula;
    IngredientView.OnIngredientSelected -= AddIngredient;
  }
  private void Start() {
    ChangeFormula();	
	}

	void SolveFormula() {
    float formulaMediocrity = GetCurrentFormula().SolveMediocrity();
    OnFormulaSolved?.Invoke(formulaMediocrity);
    ChangeFormula();
	}

  void ChangeFormula() {
    if (formulaIndex >= formulas.Count - 1) {
      OnFormulasFinished?.Invoke();
      return;
		}
    formulaIndex++;
    GetCurrentFormula().ClearIngredients();
    OnIndexChanged?.Invoke(formulaIndex);
    OnFormulaChanged?.Invoke(GetCurrentFormula());
  }

  public Formula GetCurrentFormula() {
    return formulas[formulaIndex];
	}

  void AddIngredient(Ingredients.Ingredient ingredient) {
    GetCurrentFormula().AddIngredient(ingredient);
	}
}
