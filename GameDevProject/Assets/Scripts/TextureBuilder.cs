using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshBuilder))]
public class TextureBuilder : MonoBehaviour {
	public Texture2D terrainTiles;
	public int tileResolution = 32;

	private MeshBuilder mb;
	// Use this for initialization
	void Start () {
		
	}

	public void BuildTexture() {
		mb = this.GetComponentInParent<MeshBuilder>();
		int numTilesPerRow = terrainTiles.width / tileResolution;
		int numRows = terrainTiles.height / tileResolution;

		int texWidth = mb.sizeX * tileResolution;
		int texHeight = mb.sizeY * tileResolution;
		Texture2D texture = new Texture2D(texWidth, texHeight);

		for (int y = 0; y < mb.sizeY; y++) {
			for (int x = 0; x < mb.sizeX; x++) {
				int terrainTileOffset = Random.Range(0, 16) * tileResolution;
				int terrainTileOffset2 = Random.Range(0, 16) * tileResolution;
				Color[] p = terrainTiles.GetPixels(terrainTileOffset, terrainTileOffset2, tileResolution, tileResolution);
				texture.SetPixels(x * tileResolution, y * tileResolution, tileResolution, tileResolution, p);
			}
		}

		texture.filterMode = FilterMode.Bilinear;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.Apply();
		Debug.Log("hello..?");
		MeshRenderer meshRenderer = this.GetComponentInParent<MeshRenderer>();
		meshRenderer.sharedMaterials[0].mainTexture = texture;
	}
}
