using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private NPC npc;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dialogueUI;

    [SerializeField] private float distance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float currentResponseTracker = 0;

    [SerializeField] private TMP_Text npcName;
    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private string playerResponse;

    [SerializeField] private GameObject inputIndication;
    
    private bool _isTalking = false;
    private bool _isTest;

    private void Start() => dialogueUI.SetActive(false);
    
    private void Update()
    {
        if(!_isTest) return;
        InteractionInput();
    }

    private void InteractionInput()
    {
        if(Input.GetKeyDown(KeyCode.E) && _isTalking == false) OnStartConversation();
        else if (Input.GetKeyDown(KeyCode.E) && _isTalking) OnEndConversation();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //This doesn't look clean 
        _isTest = true;
        if(other.gameObject != player) return;
        //_isTalking = _isTest ? inputIndication.SetActive(true) : inputIndication.SetActive(false);
        if(_isTalking == false) inputIndication.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inputIndication.SetActive(false);
        _isTest = false;
        OnEndConversation();
    }

    private void OnStartConversation()
    {
        _isTalking = true;
        if(_isTalking) inputIndication.SetActive(false);
        currentResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        dialogueBox.text = npc.Dialogue[0];
    }
    
    private void OnEndConversation()
    {
        _isTalking = false;
        dialogueUI.SetActive(false);
    }

    /*
    private void OnSelectOption()
    {
        
    }
    */
}
