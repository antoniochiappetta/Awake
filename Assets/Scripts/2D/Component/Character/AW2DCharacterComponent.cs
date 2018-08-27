using System.Collections.Generic;
using UnityEngine;

public class AW2DCharacterComponent: MonoBehaviour
{
    // MARK: - Properties

    public float maxSpeed = 10.0f;
    private bool isFacingRight;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidBody;

    // MARK: - Lifecycle

    private void Start()
    {
        isFacingRight = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
	{
		float move = Input.GetAxis("Horizontal");
		if ((move < 0 && isFacingRight) || (move > 0 && !isFacingRight))
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
			isFacingRight = !isFacingRight;
		}
		if (System.Math.Abs(move) > 0)
		{
            animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
		rigidBody.velocity = new Vector2(move * maxSpeed, 0);
    }
}
