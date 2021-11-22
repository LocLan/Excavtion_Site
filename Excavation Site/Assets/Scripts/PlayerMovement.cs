using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private float speed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        if (horizontalInput < 0f)
            transform.localScale = new Vector3(1, 1, 1);

        else if (horizontalInput > 0f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("runSideways", horizontalInput != 0);
        anim.SetBool("runUp", verticalInput > 0);
        anim.SetBool("runDown", verticalInput < 0);
    }
}
