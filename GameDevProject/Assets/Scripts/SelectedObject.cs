using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedObject : MonoBehaviour {
	public Projector selectionMark;

	private void Start() {
		this.selectionMark.enabled = false;
	}
}
