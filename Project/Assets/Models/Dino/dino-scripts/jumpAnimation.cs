using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAnimation : MonoBehaviour
{
    public Animator animator;

    private bool isJumping = false;
    private bool isDead = false;
    private bool isReset = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Jump Animation */
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            animator.SetBool("isWalking", false);
            Debug.Log("jump");
        }
        else if (isJumping)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isWalking", true);
        }

        /* Death Animation (also by pressing d) */
        if(Input.GetKeyDown("d") && !isDead)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            Debug.Log("dead");
            Debug.Log(isDead);
        }

        /* Reset by pressing r*/
        if (Input.GetKeyDown("r") && !isReset)
        {
            animator.SetBool("isReset", isReset);
            isReset = true;

        }
        else if (isReset)
        {
            animator.SetBool("isReset", false);
            isReset = false;
        }
    }
}
