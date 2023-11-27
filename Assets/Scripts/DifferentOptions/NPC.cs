using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    [SerializeField] List<AllDialogue> allDialogue = new List<AllDialogue>();

    public List<AllDialogue> AllDialogue => allDialogue;
}
