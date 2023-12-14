using TMPro;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private NPCFinder npcFinder;
    public GameObject choiceButtons;

    [Header("Player Settings")]
    public bool isPlayerResponse;
    public bool isNpcResponse;
    public bool isPressed;
    
    private bool _isNegativeResponse;
    private bool _isPositiveResponse;
    private bool _firstNpcDialogue = true;
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
        if (!isPressed) return;
        isPressed = false;
        choiceButtons.SetActive(false);
        isPlayerResponse = true;
        _dialogueManager.isTalking = true;

        _dialogueManager.npcName.text = npcFinder.GetNpcName.npc.AllDialogue[npcFinder.firstNPCDialogue].
            NpcDialogue[_dialogueManager.dialogueOrder].PlayerResponse.NamePlayer;

        if (_firstPlayerDialogue)
        {
            _dialogueManager.dialogueBox.text = isPlayerResponse switch
            {
                true when _isPositiveResponse => npcFinder.GetNpcName.npc.AllDialogue[npcFinder.firstNPCDialogue]
                    .NpcDialogue[_dialogueManager.dialogueOrder]
                    .PlayerResponse.PositiveResponse.ReactPositive,
                true when _isNegativeResponse => npcFinder.GetNpcName.npc.AllDialogue[npcFinder.firstNPCDialogue]
                    .NpcDialogue[_dialogueManager.dialogueOrder]
                    .PlayerResponse.NegativeResponse.ReactNegative,
                _ => _dialogueManager.dialogueBox.text
            };

            _firstPlayerDialogue = false;
        }
        else
        {
            if (!_currentPlayerResponse.HasMorePlayerDialogue())
            {
                ResetDialogue();
                return;
            }

            _dialogueManager.dialogueBox.text = isPlayerResponse switch
            {
                true when _isPositiveResponse => _currentPlayerResponse.PositiveResponse.ReactPositive,
                true when _isNegativeResponse => _currentPlayerResponse.NegativeResponse.ReactNegative,
                _ => _dialogueManager.dialogueBox.text
            };
        }
    }

    public void GoToNpcResponse()
    {
        isPlayerResponse = false;
        _dialogueManager.isTalking = true;
        isNpcResponse = true;

        _dialogueManager.npcName.text = npcFinder.GetNpcName.npc.name;

        if (_firstNpcDialogue)
        {
            _currentPlayerResponse = npcFinder.GetNpcName.npc.AllDialogue[npcFinder.firstNPCDialogue]
                .NpcDialogue[_dialogueManager.dialogueOrder].PlayerResponse;
            _firstNpcDialogue = false;
        }

        if (!_currentPlayerResponse.HasMoreNpcDialogue())
        {
            ResetDialogue();
            return;
        }
        
        switch (isNpcResponse)
        {
            case true when _isPositiveResponse:
                choiceButtons.SetActive(true);
                _dialogueManager.dialogueBox.text = _currentPlayerResponse.PositiveResponse.NpcResponse.NpcDialogue;
                _currentPlayerResponse = _currentPlayerResponse.PositiveResponse.NpcResponse.PlayerResponse;
                break;
            case true when _isNegativeResponse:
                choiceButtons.SetActive(true);
                _dialogueManager.dialogueBox.text = _currentPlayerResponse.NegativeResponse.NpcResponse.NpcDialogue;
                _currentPlayerResponse = _currentPlayerResponse.NegativeResponse.NpcResponse.PlayerResponse;
                break;
        }
        
        _isPositiveResponse = false;
        _isNegativeResponse = false;
    }

    private void ResetDialogue()
    {
        _currentPlayerResponse = new PlayerResponse();
        _firstNpcDialogue = true;
        _firstPlayerDialogue = true;
        isPlayerResponse = false;
        isNpcResponse = false;
        _isPositiveResponse = false;
        _isNegativeResponse = false;
        _dialogueManager.isTalking = false;
        _dialogueManager.OnEndConversation();
    }
}
