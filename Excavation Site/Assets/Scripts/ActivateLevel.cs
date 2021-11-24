using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLevel : MonoBehaviour
{
    private Animator anim;
    public GameObject LevelDoor;
    public GameObject Stage;
    private bool onButton;
    public GameObject[] LevelEnemies;

    private void Awake()
    {
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
                anim.SetTrigger("Pressed");
                BeginLevel();
            }
        }
    }

    private void BeginLevel()
    {
        //Unfreeze enemies
        LevelDoor.GetComponent<NextLevel>().OpenDoor();
    }
}


