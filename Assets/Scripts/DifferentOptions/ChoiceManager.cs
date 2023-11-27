using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPCFinder npcFinder;
    public GameObject choiceButtons;

    [Header("Player Settings")]
    public bool isPlayerResponse;

    [HideInInspector] public int playerResponseOrder = -1;

    private AllDialogue _allDialogue;

    public void PositivePlayerResponse()
    {
        isPlayerResponse = true;
        choiceButtons.SetActive(false);
        _dialogueManager.npcName.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.Name;
        if (isPlayerResponse)
        {
            _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PositiveResponse.ReactPositive;
        }
    }

    public void NegativePlayerResponse()
    {
        isPlayerResponse = true;
        choiceButtons.SetActive(false);
        _dialogueManager.npcName.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.Name;
        if (isPlayerResponse)
        {
            _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.NegativeResponse.ReactNegative;
        }
    }

    public void GoToNPCResponse()
    {
        _dialogueManager.dialogueBox.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.PositiveResponse.NpcResponse.ResponseNpc;
    }
}
