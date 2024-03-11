using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeDialogue : MonoBehaviour
{
    public TextMeshProUGUI textOfDialogue;

    public void ChangeText( string newText )
    {
        textOfDialogue.text = newText;
    }
}
