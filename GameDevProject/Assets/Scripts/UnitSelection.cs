using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unit selection from an RTS perspective.
/// <remarks>
/// Includes the RTS box selection mechanic. 
/// </remarks>
/// </summary>
public class UnitSelection : MonoBehaviour {
	public RectTransform selectionBox;
	private bool isSelecting;
	private Vector3 mousePosition;
	private Camera mainCamera;

	/// <summary>
	/// Intializes the selection box to inactivate
	/// </summary>
	private void Start() {
		mainCamera = Camera.main;
		this.isSelecting = false;
		this.selectionBox.gameObject.SetActive(false);
	}

	/// <summary>
	/// Activates the selection box if the left mouse button is pressed down.
	/// Otherwise, it disables it.
	/// </summary>
	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			this.isSelecting = true;
			this.mousePosition = Input.mousePosition;
			this.selectionBox.gameObject.SetActive(true);
		} else if (Input.GetMouseButtonUp(0)) {
			this.isSelecting = false;
			this.selectionBox.gameObject.SetActive(false);
			GetSelectableObjectsWithinBounds();
		}
		if (this.isSelecting) {
			this.DrawSelectionBox();
		}
	}
	/// <summary>
	/// Draws the selection box again to prevent it from wobbling on the screen.
	/// </summary>
	private void LateUpdate() {
		if (this.isSelecting) {
			this.DrawSelectionBox();
		}
	}

	/// <summary>
	/// Draws the selection box on the screen based on user mouse input.
	/// </summary>
	private void DrawSelectionBox() {
		Vector2 hypotenuse = new Vector2(Input.mousePosition.x - this.mousePosition.x, Input.mousePosition.y - this.mousePosition.y);
		Vector2 boxAnchor = new Vector2(this.mousePosition.x - (Screen.width / 2), this.mousePosition.y - (Screen.height / 2));
		Vector2 sizeDelta = new Vector2(0.0f, 0.0f);

		if (hypotenuse.x > 0) {
			boxAnchor.x = boxAnchor.x + this.selectionBox.sizeDelta.x / 2;
			sizeDelta.x = hypotenuse.x;
		} else {
			boxAnchor.x = boxAnchor.x - this.selectionBox.sizeDelta.x / 2;
			sizeDelta.x = (float)System.Math.Abs(hypotenuse.x);
		}

		if (hypotenuse.y > 0) {
			boxAnchor.y = boxAnchor.y + this.selectionBox.sizeDelta.y / 2;
			sizeDelta.y = hypotenuse.y;
		} else {
			boxAnchor.y = boxAnchor.y - this.selectionBox.sizeDelta.y / 2;
			sizeDelta.y = (float)System.Math.Abs(hypotenuse.y);
		}

		selectionBox.localPosition = boxAnchor;
		selectionBox.sizeDelta = sizeDelta;
	}

	/// <summary>
	/// Finds the collection of selectable GameObjects within the selection box.
	/// </summary>
	/// <returns>
	/// Returns the collection.
	/// </returns>
	public GameObject[] GetSelectableObjectsWithinBounds() {
		Bounds viewportBounds = Utils.GetViewportBounds(mainCamera, mousePosition, Input.mousePosition);
		Collider2D[] colliders = Physics2D.OverlapAreaAll(viewportBounds.min, viewportBounds.max, LayerMask.GetMask(Global.Selectable), int.MinValue, int.MaxValue);
		GameObject[] selected = new GameObject[colliders.Length];
		for (int i = 0; i < colliders.Length; i++) {
			selected[i] = colliders[i].gameObject;
			Debug.Log(selected[i].name);
		}
		return selected;
	}
}
