using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MeshBuilder))]
public class TileMapEditor : Editor {

	//float v = 0.5f;
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		/*EditorGUILayout.BeginVertical();
		v = EditorGUILayout.Slider(v, 0, 2.0f);
		EditorGUILayout.EndVertical()
		*/
		if (GUILayout.Button("Regenerate")) {
			MeshBuilder tm = (MeshBuilder)this.target;
			tm.BuildMesh();
		}

	}
}
