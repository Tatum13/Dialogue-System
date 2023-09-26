using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    [SerializeField] private string name;
    [TextArea(3, 15)] [SerializeField] private string[] dialogue;
    [TextArea(3, 15)] [SerializeField] private string[] playerDialogue;

    public string[] Dialogue => dialogue;
}
