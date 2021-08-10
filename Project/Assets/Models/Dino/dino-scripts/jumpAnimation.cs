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
    public bool end_flag = false;

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
            end_flag = true;
        }

        /* Jump Animation */
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            animator.SetBool("isWalking", false);
        }
        else if (isJumping)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
            animator.SetBool("isWalking", true);
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

    private void OnTriggerEnter(Collider other)
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
        end_flag = false;
    }

    public bool end()
    {
        return end_flag;
    }
}
