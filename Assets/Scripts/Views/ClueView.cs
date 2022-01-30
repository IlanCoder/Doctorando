using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Clues;

[RequireComponent(typeof(Image))]
public class ClueView : MonoBehaviour
{
  public Clue clue;

	private void Start() {
		GetComponent<Image>().sprite = clue.sprite;
	}
}
