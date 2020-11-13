using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviourOW : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    private RectTransform rt;
    [SerializeField] private Animator anim;
    private Vector3 storedPosition;
    private CircleCollider2D collider;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        collider = GetComponent<CircleCollider2D>();
       rt = UIPanel.GetComponent<RectTransform>();
       storedPosition = GetComponentInChildren<Transform>().position;
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
        rt.position = storedPosition + new Vector3(0,1,0);
        Debug.Log(storedPosition);
        //Debug.Log(rt.position);
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
        //controls.Overworld.Talk
    }
}
