using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] List<AllDialogue> allDialogue = new List<AllDialogue>();
    [TextArea(3, 15)] [SerializeField] private string[] dialogue;
    public List<AllDialogue> AllDialogue => allDialogue;

    public PlayerResponse playerResponse;
    
    public string[] Dialogue => dialogue;
}
