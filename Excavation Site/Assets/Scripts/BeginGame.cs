using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    private Animator anim;
    public GameObject MainMenuUI;
    public GameObject GameUI;
    public GameObject Player;
    public GameObject StartCamera;
    public GameObject GameCamera;
    public GameObject FadeIn;
    public Transform nextLevelPedestool;
    private bool onHole;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("Selected", true);
            onHole = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            anim.SetBool("Selected", false);
            onHole = false;
        }
    }

    private void Update()
    {
        if(onHole == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        GameUI.SetActive(true);
        FadeIn.GetComponent<FadeTrans>().Fade();
        //yield return new WaitForSeconds(1);
        MainMenuUI.SetActive(false);
        Player.transform.position = nextLevelPedestool.transform.position;
        StartCamera.SetActive(false);
        GameCamera.SetActive(true);
    }
}
