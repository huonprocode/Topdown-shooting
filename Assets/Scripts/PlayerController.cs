using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer characterSR;

    Vector3 moveInput;
    Animator animator;
    Rigidbody2D rb;

    
    public float rollBoots;
    public float rollTime;
    private float currentRollTime;
    private bool onRoll = false;

    void Start()
    {
        animator = characterSR.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.Translate(moveInput * moveSpeed * Time.deltaTime);

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
            {
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && currentRollTime <= 0 && onRoll == false)
        {
            moveSpeed += rollBoots;
            animator.SetBool("Roll", true);
            currentRollTime = rollTime;
            onRoll = true;
        }
        if (currentRollTime <= 0 && onRoll == true)
        {
            moveSpeed -= rollBoots;
            animator.SetBool("Roll", false);
            onRoll = false;
        }
        else
        {
            currentRollTime -= Time.deltaTime;
        }

    }
}


