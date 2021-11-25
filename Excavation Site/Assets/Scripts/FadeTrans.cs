using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTrans : MonoBehaviour
{
    private Animator anim;
    public GameObject Player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Fade()
    {
        anim.SetBool("Fade", true);
    }

    public void EndFade()
    {
        anim.SetBool("Fade", false);
    }
}

