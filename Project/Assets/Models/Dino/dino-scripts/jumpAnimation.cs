using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpAnimation : MonoBehaviour
{
    public Animator animator;

    private bool isJumping = false;
    private bool isDead = false;
    private bool isReset = false;
    private bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Starting key */
        if (Input.GetKeyDown("s") && !isStart)
        {
            animator.SetBool("isStart", true);
            animator.SetBool("isReset", false);
            isStart = true;
            isReset = false;
            isDead = false;
            Debug.Log("startinggggg");
        }

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
        if (Input.GetKeyDown("d") && !isDead)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            Debug.Log("dead");
            Debug.Log(isDead);
            Debug.Log(isReset);
        }

        /* Reset by pressing r*/
        if (Input.GetKeyDown("r") && !isReset)
        {
            animator.SetBool("isReset", true);
            animator.SetBool("isStart", false);
            animator.SetBool("isDead", false);
            animator.SetBool("isWalking", false);
            isReset = true;
            Debug.Log("reset key tapped");
            isStart = false;
            Debug.Log(isStart);
        }

        /* Debug key */
        if (Input.GetKeyDown("p"))
        {
            Debug.Log(isStart);
            Debug.Log(isJumping);
            Debug.Log(isDead);
            Debug.Log(isReset);

        }
    }

    private void OnTriggerEnter(Collier other)
    {
        if (other.tag == "obstacle")
        {
            endGame();
        }
    }

    private void endGame()
    {
        animator.SetBool("isDead", true);
        isDead = true;
        Debug.Log("dead");
        Debug.Log(isDead);
        Debug.Log(isReset);
    }

}
