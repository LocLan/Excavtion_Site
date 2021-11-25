using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D BoxCollider;
    public Transform startPedestool;
    public GameObject Player;
    public GameObject Stage;
    public GameObject FadeIn;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("Open");
        BoxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FadeIn.GetComponent<FadeTrans>().Fade();
            Player.transform.position = startPedestool.transform.position;
        }
    }
}
