using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MeshBuilder : MonoBehaviour {
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;
	private MeshCollider meshCollider;

	public int sizeX;
	public int sizeY;
	public float tileSize;

	// Use this for initialization
	private void Start () {
		BuildMesh();
		if (this.GetComponentInParent<TextureBuilder>() != null) {
			this.GetComponentInParent<TextureBuilder>().BuildTexture();
		}
	}

	public void BuildMesh() {
		int numTiles = sizeX * sizeY;
		int vSizeX = sizeX + 1;
		int vSizeY = sizeY + 1;
		int numVerts = vSizeX * vSizeY;
		int numTris = numTiles * 2;

		Vector3[] vertices = new Vector3[numVerts];
		Vector3[] normals = new Vector3[numVerts];
		Vector2[] uv = new Vector2[numVerts];

		int[] triangles = new int[numTris * Global.NumberOfVerticesInTri];

		// Generate vertices
		for (int y = 0; y < vSizeY; y++) {
			for (int x = 0; x < vSizeX; x++) {
				vertices[y * vSizeX + x] = new Vector3(x * tileSize, -y * tileSize, 0);
				normals[y * vSizeX + x] = Vector3.back;
				uv[y * vSizeX + x] = new Vector2((float)x / vSizeX, 1f - (float)y / vSizeY);
			}
		}

		Debug.Log("Vertices initialized.");

		// Generate triangles
		for (int y = 0; y < sizeY; y++) {
			for (int x = 0; x < sizeX; x++) {
				int squareIndex = y * sizeX + x;
				int triOffset = squareIndex * 6;
				triangles[triOffset + 0] = y * vSizeX + x;
				triangles[triOffset + 1] = y * vSizeX + vSizeX + x + 1;
				triangles[triOffset + 2] = y * vSizeX + vSizeX + x;

				triangles[triOffset + 3] = y * vSizeX + x + 1;
				triangles[triOffset + 4] = y * vSizeX + vSizeX + x + 1;
				triangles[triOffset + 5] = y * vSizeX + x;


			}
		}

		/*Debug.Log("vSizeX: " + vSizeX);
		for (int i = 0; i < triangles.Length; i++) {
			Debug.Log("P" + i + " " + triangles[i]);
		}
		*/

		Debug.Log("Triangles intialized.");

		// Create a new Mesh and populate with the data
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		mesh.uv = uv;

		this.meshFilter = this.GetComponentInParent<MeshFilter>();
		this.meshCollider = this.GetComponentInParent<MeshCollider>();

		this.meshFilter.mesh = mesh;
		this.meshCollider.sharedMesh = mesh;
		Debug.Log("Mesh intialized.");

	}

}
