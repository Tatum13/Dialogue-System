using System;
using UnityEngine;

[Serializable]
public struct AllDialogue
{
    [SerializeField, TextArea] private string[] npcDialogue;
    [SerializeField, TextArea] private string[] playerResponse;
    public string[] NPCDialogue => npcDialogue;
    public string[] PlayerResponse => playerResponse;
}
