using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevel : MonoBehaviour
{
    private Animator anim;
    public GameObject LevelDoor;
    private bool onButton;

    private void Awake()
    {
        //make the animations TO GET THE SELECTED ANIMATION MAKE AN ALL WHITE SPRITE AND SIZE IT UP
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("Selected", true);
            onButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("Selected", false);
            onButton = false;
        }
    }

    private void Update()
    {
        if (onButton == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                BeginLevel();
            }
        }
    }

    private void BeginLevel()
    {
        //Unfreeze enemies
        anim.SetTrigger("Pressed");

    }
}


