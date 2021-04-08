using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{
    public static cursorController instance;

    public Texture2D normCursor;
    public Texture2D talkCursor;
    public Texture2D examCursor;
    public Texture2D moveCursor;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        Cursor.SetCursor(normCursor, Vector2.zero, CursorMode.Auto);
    }

    public void normalCursor()
    {
        Cursor.SetCursor(normCursor, Vector2.zero, CursorMode.Auto);
    }

    public void talkingCursor()
    {
        Cursor.SetCursor(talkCursor, Vector2.zero, CursorMode.Auto);
    }

    public void examineCursor()
    {
        Cursor.SetCursor(examCursor, Vector2.zero, CursorMode.Auto);
    }

    public void movingCursor()
    {
        Cursor.SetCursor(moveCursor, Vector2.zero, CursorMode.Auto);
    }
}
