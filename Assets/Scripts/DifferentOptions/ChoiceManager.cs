using System;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPCFinder npcFinder;
    public GameObject choiceButtons;
    [SerializeField] private string name;

    [Header("Player Settings")]
    public bool isPlayerResponse;

    [HideInInspector] public int playerResponseOrder = -1;

    private AllDialogue _allDialogue;

    //private void UpdateText() => _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PlayerDialogue[playerResponseOrder];

    public void FirstPlayerResponse()
    {
        isPlayerResponse = true;
        _dialogueManager.npcName.text = name;
        if (isPlayerResponse)
        {
            _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PlayerDialogue[0];
        }
        //NextPlayerDialogue();
    }

    public void SecondPlayerResponse()
    {
        isPlayerResponse = true;
        _dialogueManager.npcName.text = name;
        if (isPlayerResponse)
        {
            _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PlayerDialogue[1];
        }
        //NextPlayerDialogue();
    }

    public void ResetDialogue()
    {
        _dialogueManager._dialogueOrder = -1;
        
        //_dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].NpcDialogue;
    }
    
    /*
    public void NextPlayerDialogue()
    {
        playerResponseOrder++;

        if(playerResponseOrder >= npcFinder.GetNPCName._npc.playerResponse.PlayerDialogue.Length)
        {
            isPlayerResponse = false;
            return;
        }
        UpdateText();
    }
    */
    
    //public void 
}
