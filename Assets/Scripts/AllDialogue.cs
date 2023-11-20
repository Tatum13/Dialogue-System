using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AllDialogue
{
    [SerializeField] private List<NPCDialogue> npcDialogue;

    public List<NPCDialogue> NPCDialogue => npcDialogue;
}

[Serializable]
public struct NPCDialogue
{
    [TextArea(0,15), SerializeField] private string npcDialogue;
    [SerializeField] private PlayerResponse playerResponse;

    public string NpcDialogue => npcDialogue;
    public PlayerResponse PlayerResponse => playerResponse;
}

[Serializable]
public struct PlayerResponse
{
    [SerializeField] private bool testBool;
    [TextArea(0,15), SerializeField] private string[] playerDialogue;

    public string[] PlayerDialogue => playerDialogue;
}