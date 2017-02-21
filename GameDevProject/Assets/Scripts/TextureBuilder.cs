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

	private Color[,][] GetColorArrayFromTexture2D() {
		int numRows = terrainTiles.height / tileResolution;
		int numCols = terrainTiles.width / tileResolution;


		Color[,][] colors = new Color[numRows, numCols][];

		for (int y = 0; y < numRows; y++) {
			for (int x = 0; x < numCols; x++) {
				colors[y, x] = terrainTiles.GetPixels(x * tileResolution, y * tileResolution, tileResolution, tileResolution);
			}
		}


		return colors;
	}

	public void BuildTexture() {
		mb = this.GetComponentInParent<MeshBuilder>();


		int texWidth = mb.sizeX * tileResolution;
		int texHeight = mb.sizeY * tileResolution;
		Texture2D texture = new Texture2D(texWidth, texHeight);

		Color[,][] tiles = this.GetColorArrayFromTexture2D();

		for (int y = 0; y < mb.sizeY; y++) {
			for (int x = 0; x < mb.sizeX; x++) {
				Color[] p = tiles[Random.Range(0, 16), Random.Range(0, 16)];
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
