using UnityEngine;
using System.Collections;

public class CursorControl : MonoBehaviour {

	public Texture2D speachCursor;
	public Vector2 cursorHotspot;

	private CursorMode cursorMode = CursorMode.Auto;

	void OnMouseEnter() {
		Cursor.SetCursor (speachCursor, cursorHotspot, cursorMode);
	}

	void OnMouseExit() {
		// Reset cursor
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);		
	}
}
