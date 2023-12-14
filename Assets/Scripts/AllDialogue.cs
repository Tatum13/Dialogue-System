using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AllDialogue
{
    [SerializeField] private List<NPCDialogue> npcDialogue;

    public List<NPCDialogue> NpcDialogue => npcDialogue;
}

[Serializable]
public class NPCDialogue
{
    [TextArea(0,15), SerializeField] private string npcDialogue;
    [Space]
    [SerializeField] private PlayerResponse playerResponse;

    public string NpcDialogue => npcDialogue;
    public PlayerResponse PlayerResponse => playerResponse;
}