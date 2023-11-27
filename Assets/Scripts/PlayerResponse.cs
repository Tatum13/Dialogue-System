using System;
using UnityEngine;

[Serializable]
public struct PlayerResponse
{
    [SerializeField] private string name;
    [Space]
    [SerializeField] private PositiveResponse positiveResponse;
    [Space]
    [SerializeField] private NegativeResponse negativeResponse;

    public string Name => name;

    public PositiveResponse PositiveResponse => positiveResponse;
    public NegativeResponse NegativeResponse => negativeResponse;
}

[Serializable]
public struct PositiveResponse
{
    [TextArea(0,15), SerializeField] private string reactPositive;
    [SerializeField] private NPCResponse npcResponse;

    public string ReactPositive => reactPositive;
    public NPCResponse NpcResponse => npcResponse;
}

[Serializable]
public struct NegativeResponse
{
    [TextArea(0,15), SerializeField] private string reactNegative;
    [SerializeField] private NPCResponse npcResponse;

    public string ReactNegative => reactNegative;
    public NPCResponse NpcResponse => npcResponse;
}