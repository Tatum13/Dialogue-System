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
    private bool _firstNPCDialogue = true;
    private bool _firstPlayerDialogue = true;

    private PlayerResponse _currentPlayerResponse;

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
            isPressed = false;
            choiceButtons.SetActive(false);
            isPlayerResponse = true;
            _dialogueManager._isTalking = false;

            _dialogueManager.npcName.text = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue].
                NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse.NamePlayer;

            if (_firstPlayerDialogue)
            {
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

                _firstPlayerDialogue = false;
            }
            else
            {
                if (isPlayerResponse && _isPositiveResponse)
                {
                    _dialogueManager.dialogueBox.text = _currentPlayerResponse.PositiveResponse.ReactPositive;
                }
                else if (isPlayerResponse && _isNegativeResponse)
                {
                    _dialogueManager.dialogueBox.text = _currentPlayerResponse.NegativeResponse.ReactNegative;
                }
            }
        }
    }

    public void GoToNpcResponse()
    {
        isPlayerResponse = false;
        _dialogueManager._isTalking = false;
        _isPositiveResponse = false;
        _isNegativeResponse = false;
        isNPCResponse = true;

        _dialogueManager.npcName.text = npcFinder.GetNPCName._npc.name;

        if (_firstNPCDialogue)
        {
            _currentPlayerResponse = npcFinder.GetNPCName._npc.AllDialogue[npcFinder.firstNPCDialogue]
                .NPCDialogue[_dialogueManager._dialogueOrder].PlayerResponse;
            _firstNPCDialogue = false;
        }

        if (isNPCResponse && !_isPositiveResponse)
        {
            choiceButtons.SetActive(true);
            _dialogueManager.dialogueBox.text = _currentPlayerResponse.PositiveResponse.NpcResponse.NpcDialogue;
            _currentPlayerResponse = _currentPlayerResponse.PositiveResponse.NpcResponse.PlayerResponse;
        }
        else if (isNPCResponse && !_isNegativeResponse)
        {
            choiceButtons.SetActive(true);
            _dialogueManager.dialogueBox.text = _currentPlayerResponse.NegativeResponse.NpcResponse.NpcDialogue;
            _currentPlayerResponse = _currentPlayerResponse.NegativeResponse.NpcResponse.PlayerResponse;
        }
    }
}
