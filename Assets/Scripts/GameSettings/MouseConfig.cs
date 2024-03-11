using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseConfig : MonoBehaviour
{
    public Texture2D spriteCursor;

    void Start()
    {
        Cursor.SetCursor(spriteCursor, Vector2.zero, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
