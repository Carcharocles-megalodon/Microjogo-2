using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCBehaviourOW : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    private RectTransform rt;
    [SerializeField] private Animator anim;
    private Vector3 storedPosition;
    private CircleCollider2D collider;
    private PlayerControls controls;
    private bool conversationStarted;
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private TextMeshProUGUI tmp;

    private void Awake()
    {
        conversationStarted = false;
        controls = new PlayerControls();
        collider = GetComponent<CircleCollider2D>();
       rt = UIPanel.GetComponent<RectTransform>();
       storedPosition = GetComponentInChildren<Transform>().position;
       controls.Overworld.Talk.performed += ctx => Talk();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //if the player enters the trigger
            //transport UI panel to above NPC, then
            //show "press 'x' button" panel
            rt.position = storedPosition + new Vector3(0,1,0);
            anim.SetBool("inside", true);
            anim.SetBool("inRange", true);
            anim.SetBool("outRange", false);
        }
    }

    

    private void OnTriggerStay2D(Collider2D other)
    {
        //change position of the panel
        rt.position = storedPosition + new Vector3(0,1,0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            //if he leaves,
            //disable it again
            anim.SetBool("outRange", true);
            anim.SetBool("inRange", false);
            anim.SetBool("inside",false);
        }
    }

    private void Talk()
    {
        //when you press 'x'
        //start dialogue and go through the entire thing
        //when you press 'x' one last time
        //change scene to volleyball game
        if (conversationStarted == false)
        {
            anim.SetBool("talkStart", true);
            anim.SetBool("talkCont" , true);
            conversationStarted = true;
        }
        
        if (conversationStarted)
        {
            for (int i = 0; i < dialogue.lines.Length-1; i++)
            {
                tmp.text = dialogue.lines[i];
            }
        }
    }

    
}
