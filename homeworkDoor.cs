using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    //for the switch of the door
    
    private MeshCollider mc;
    private MeshRenderer mr;
    private GameObject indicatorCanInteract;//a signal for the player to know with what can interact
    private Animator anim; //animation of the switch moving
    private bool canInteract;
    public bool isSwitch;
    public bool ActiveSwitch;
    public UnityEvent switchEvent;

    private void Awake() //calling the components
    {
        mc = GetComponent<MeshCollider>();
        mr = GetComponent<MeshRenderer>();
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
            anim.SetBool("switchOn", true);
            ActiveSwitch = true;
            switchEvent.Invoke();
            indicatorCanInteract.SetActive(false);
            mc.enabled = false;
            this.enabled = false;
        }
    }

    private void OnMouseDown() {
        if(canInteract)
        {
            Switch();
        }
    }
    /*private void Update()
    {
        if(canInteract && Input.GetMouseButtonDown(0))
            {
                Switch();
            }
    }*/
}
