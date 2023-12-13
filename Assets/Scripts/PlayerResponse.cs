using System;
using UnityEngine;

[Serializable]
public struct PlayerResponse
{
    [SerializeField] private string namePlayer;
    [Space]
    [SerializeField] private PositiveResponse positiveResponse;
    [Space]
    [SerializeField] private NegativeResponse negativeResponse;
    
    public string NamePlayer => namePlayer;

    public PositiveResponse PositiveResponse => positiveResponse;
    public NegativeResponse NegativeResponse => negativeResponse;

    public bool HasMoreDialogue()
    {
        return (positiveResponse.NpcResponse != null 
                || negativeResponse.NpcResponse != null) 
               && (positiveResponse.NpcResponse.NpcDialogue != string.Empty 
                   || negativeResponse.NpcResponse.NpcDialogue != string.Empty);
    }

    public PlayerResponse(string targetName = "You")
    {
        namePlayer = targetName;

        positiveResponse = new PositiveResponse();
        negativeResponse = new NegativeResponse();
    }
}

[Serializable]
public struct PositiveResponse
{
    [TextArea(0,15), SerializeField] private string reactPositive;
    [SerializeField] private NPCDialogue npcResponse;

    public string ReactPositive => reactPositive;
    public NPCDialogue NpcResponse => npcResponse;
}

[Serializable]
public struct NegativeResponse
{
    [TextArea(0,15), SerializeField] private string reactNegative;
    [SerializeField] private NPCDialogue npcResponse;

    public string ReactNegative => reactNegative;
    public NPCDialogue NpcResponse => npcResponse;
}