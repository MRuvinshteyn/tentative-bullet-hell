using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D mouseCursor;

    Vector2 hotSpot;
    readonly CursorMode cursorMode = CursorMode.ForceSoftware;

    private void Start()
    {
        hotSpot = new Vector2(mouseCursor.width / 2, mouseCursor.height / 2);

        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }
}
