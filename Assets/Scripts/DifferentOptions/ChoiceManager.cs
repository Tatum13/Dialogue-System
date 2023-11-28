using System;
using TMPro;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPCFinder npcFinder;
    [SerializeField] TMP_Text npcName;
    public GameObject choiceButtons;

    [Header("Player Settings")]
    public bool isPlayerResponse;

    public bool isNPCResponse;

    [HideInInspector] public int playerResponseOrder = -1;

    public bool isPressed;
    
    private AllDialogue _allDialogue;
    private bool _isNegativeResponse;
    private bool _isPositiveResponse;

    private void Update() => EveryPlayerResponse();

    public void PositivePlayerResponse()
    {
        isPressed = true;
        _isPositiveResponse = true;
    }

    public void NegativePlayerResponse()
    {
        isPressed = true;
        _isNegativeResponse = true;
    }

    private void EveryPlayerResponse()
    {
        if (isPressed)
        {
            choiceButtons.SetActive(false);
            isPlayerResponse = true;
            _dialogueManager._isTalking = false;

            _dialogueManager.npcName.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].
                NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.NamePlayer;
        
            if (isPlayerResponse && _isPositiveResponse)
            {
                _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].
                    NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PositiveResponse.ReactPositive;
            }
            else if (isPlayerResponse && _isNegativeResponse)
            {
                _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].
                    NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.NegativeResponse.ReactNegative;
            }
        }
        else
        {
            return;
        }
    }

    public void GoToNpcResponse()
    {
        isPlayerResponse = false;
        _dialogueManager._isTalking = false;
        isNPCResponse = true;
        _dialogueManager.npcName.text = npcFinder.GetNPCName._npc.name; 
        if (isNPCResponse)
        {
            _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].
                NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PositiveResponse.NpcResponse.ResponseNpc;
        }
    }
}
