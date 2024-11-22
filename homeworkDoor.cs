using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    //for the switch of the door
    
    private BoxCollider bc;
    private SpriteRenderer sp;
    private GameObject indicatorCanInteract;//a signal for the player to know with what can interact
    private Animator anim; //animation of the switch moving and the door opening
    private bool canInteract;
    public bool isSwitch;
    public bool ActiveSwitch;
    public UnityEvent switchEvent;

    private void Awake() //calling the components
    {
        bc = GetComponent<BoxCollider>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if(transform.GetChild(0) != null)
        {
            indicatorCanInteract = transform.GetChild(0).gameObject;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        //when the collider gets tag player, it'll able the interaction with the switch
        if(collision.CompareTag("Player"))
        {
            canInteract = true;
            indicatorCanInteract.SetActive(true);
        }
    }
    private void Switch()
    {
        if(isSwitch && !ActiveSwitch)
        {
            anim.SetBool("active", true);
            ActiveSwitch = true;
            switchEvent.Invoke();
            indicatorCanInteract.SetActive(false);
            bc.enabled = false;
            this.enabled = false;
        }
        
    }

    private void Update()
    {
        if(canInteract && Input.GetKeyDown(KeyCode.C))
        {
            Switch();
        }
    }
}
