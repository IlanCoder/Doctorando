using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {
  public GameObject menu;

  void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			RayCast();
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1)) {
      PopUpMenu();
    }
  }

  void PopUpMenu() {
    menu.SetActive(!menu.activeSelf);
	}

	private void RayCast() {
    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    if (hit != null) {
      if(hit.transform.TryGetComponent<IngredientView>(out IngredientView view)) {
        SelectInrgedient(view);
			}
    }
  }

	void SelectInrgedient(IngredientView ingredient) {
    ingredient.AddToFormula();
	}
}
