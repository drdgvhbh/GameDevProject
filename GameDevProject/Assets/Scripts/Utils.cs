using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility Class
/// </summary>
public static class Utils {
	private static Bounds bounds = new Bounds();
	/// <summary>
	/// Computes a rectuglar bound in 2D space on the camera viewport using two points in 3D space. 
	/// </summary>
	/// <param name="camera">Viewport Camera</param>
	/// <param name="screenPosition1">First Corner</param>
	/// <param name="screenPosition2">Second Corner</param>
	/// <returns>Returns the viewport bounds. </returns>
	public static Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2) {
		Vector3 v1 = camera.ScreenToViewportPoint(screenPosition1);
		Vector3 v2 = camera.ScreenToViewportPoint(screenPosition2);
		Vector3 min = Vector3.Min(v1, v2);
		Vector3 max = Vector3.Max(v1, v2);
		min.z = camera.nearClipPlane;
		max.z = camera.farClipPlane;

		bounds.SetMinMax(min, max);

		return bounds;
	}

	/// <summary>
	/// Computes a rectuglar bound in 2D space on the camera viewport using two points in 3D space. 
	/// </summary>
	/// <param name="camera">Viewport Camera</param>
	/// <param name="screenPosition1">First Corner</param>
	/// <param name="screenPosition2">Second Corner</param>
	/// <returns>Returns the viewport bounds. </returns>
	public static Bounds GetWorldPointBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2) {
		Vector3 v1 = camera.ScreenToWorldPoint(screenPosition1);
		Vector3 v2 = camera.ScreenToWorldPoint(screenPosition2);
		Vector3 min = Vector3.Min(v1, v2);
		Vector3 max = Vector3.Max(v1, v2);
		min.z = camera.nearClipPlane;
		max.z = camera.farClipPlane;

		bounds.SetMinMax(min, max);

		return bounds;
	}

}