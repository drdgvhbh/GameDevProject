using System.Collections;
using System.Collections.Generic;


public class TDMap {
	private int width;
	private int height;

	private int[,] mapData;

	public TDMap(int width, int height) {
		mapData = new int[this.width, this.height];
	}

	public int GetTileAt(int x, int y) {
		return mapData[x, y];
	}
}
