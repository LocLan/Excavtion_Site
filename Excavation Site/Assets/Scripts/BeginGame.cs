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
            if (Input.GetKey(KeyCode.Space))
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        GameUI.SetActive(true);
        anim.SetBool("FadeTransition", true);
        WaitFor();
        MainMenuUI.SetActive(false);
        Player.transform.position = new Vector3(50, -3, 0);
        StartCamera.SetActive(false);
        GameCamera.SetActive(true);
        WaitFor();
        anim.SetBool("FadeTransition", false);
    }

    private IEnumerator WaitFor()
    {
        yield return new WaitForSecond(1);
    }
}
