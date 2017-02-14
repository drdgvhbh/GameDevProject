using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility Class
/// </summary>
public static class Utils {
	/// <summary>
	/// A texture used specifically for the unit selection box
	/// </summary>
	public static Texture2D whiteTexture {
		set {
			if (whiteTexture == null) {
				whiteTexture = new Texture2D(1, 1);
				whiteTexture.SetPixel(0, 0, Color.white);
				whiteTexture.Apply();
			}
		}
		get {
			return whiteTexture;
		}
	}
}