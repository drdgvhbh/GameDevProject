using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapMouse : MonoBehaviour {
	private MeshBuilder tm;

	Vector3 currentTileCoord;
	public Transform hoverBoxInd;
	public MeshBuilder hoverBox;

	private void Start() {
		tm = this.GetComponentInParent<MeshBuilder>();
		if (hoverBox.GetComponentInParent<MeshBuilder>().tileSize != tm.tileSize) {
			hoverBox.GetComponentInParent<MeshBuilder>().tileSize = tm.tileSize;
			hoverBox.GetComponentInParent<MeshBuilder>().BuildMesh();
		}
	}
	// Update is called once per frame
	private void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;

		if (this.GetComponent<Collider>().Raycast(ray, out hitInfo, float.MaxValue)) {
			int x = Mathf.FloorToInt(hitInfo.point.x / tm.tileSize);
			int y = Mathf.FloorToInt(hitInfo.point.y / tm.tileSize);

			currentTileCoord.x = x;
			currentTileCoord.y = y;

			hoverBoxInd.transform.position = currentTileCoord * tm.tileSize;
		} else {

		}
	}
}
