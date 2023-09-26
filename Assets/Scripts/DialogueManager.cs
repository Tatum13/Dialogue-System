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

    private void Start() => dialogueUI.SetActive(false);

    private void InteractionInput()
    {
        if(Input.GetKeyDown(KeyCode.E) && _isTalking == false) OnStartConversation();
        else if(Input.GetKeyDown(KeyCode.E) && _isTalking == true) OnEndConversation();
    }

    private void OnTriggerEnter(Collider other)
    {
        //This doesn't look clean 
        if(other.gameObject != player) return;
        InteractionInput();
        if(_isTalking == false) inputIndication.SetActive(true);
        if(_isTalking == true) inputIndication.SetActive(false);
    }

    private void OnTriggerExit(Collider other) => inputIndication.SetActive(false);

    //This doesn't work for some reason, maybe because this is for first person.
    /* 
    private void OnInteraction()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= maxDistance) InteractionInput();
        //show text indication of that you can press the input button to start the converstation.
    }
    */

    private void OnStartConversation()
    {
        _isTalking = true;
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
