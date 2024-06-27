using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    [Header("Horizontal Moviment")]
    public float playerSpeed;
    public bool intoRight;
    public bool canMove = true;
    public Vector3 initialPosition;

    [Header("Jump")]
    public bool onFloor;
    public float jumpHeight;
    public float sizeRayVerificator;
    public Transform floorVerificator;
    public LayerMask layerFloor;

    [Header("WallJump")]
    public bool onWall;
    public bool isWallJump;
    public float wallJumpForceX;
    public float wallJumpForceY;
    public Transform wallVerificator;

    [Header("Verifications")]
    public bool isLife;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isLife = true;
        initialPosition = transform.position;  // Inicialize a posição inicial
    }

    void Update()
    {
        if(isLife && canMove) {
            PlayerMove();
            Jump();
            WallJump();
        }
        else
        {
            // Travar o player na posição inicial
            rigidBody2D.velocity = Vector2.zero;  // Parar o movimento
            transform.position = initialPosition;
            animator.Play("player-idle");  // Manter a animação em idle
        }
    }

    private void PlayerMove()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        rigidBody2D.velocity = new Vector2(horizontalMove * playerSpeed, rigidBody2D.velocity.y);

        if(horizontalMove > 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
            intoRight = true;
        }
        else if(horizontalMove < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            intoRight = false;
        }
        if(horizontalMove == 0 && onFloor) {
            animator.Play("player-idle");
        }
        else if(horizontalMove != 0 && onFloor && !onWall){
            animator.Play("player-run");
        }

        initialPosition = transform.position;  // Atualizar a posição inicial para a posição atual
    }

    private void Jump() 
    {
        onFloor = Physics2D.OverlapCircle(floorVerificator.position, sizeRayVerificator, layerFloor);
        if(Input.GetButtonDown("Jump") && onFloor) {
            SFXManager.instance.jumpEffect.Play();
            rigidBody2D.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
        if(!onFloor && !onWall) {
            animator.Play("player-jump");
        }
    }

    private void WallJump()
    {
        onWall = Physics2D.OverlapCircle(wallVerificator.position, sizeRayVerificator, layerFloor);
        if(onWall && !onFloor) {
            animator.Play("player-sliding");
        }
        if(Input.GetButtonDown("Jump") && onWall && !onFloor) {
            isWallJump = true;
        }
        if(isWallJump) {
            if(intoRight) {
                rigidBody2D.velocity = new Vector2(-wallJumpForceX, wallJumpForceY);
            }
            else {
                rigidBody2D.velocity = new Vector2(wallJumpForceX, wallJumpForceY);
            }
            Invoke(nameof(setWallJump), 0.1f);
        }
    }

    private void setWallJump()
    {
        isWallJump = false;
    }

    public void ImpulsePlayer(float impulseForce)
    {
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0f);
        rigidBody2D.AddForce(new Vector2(0f, impulseForce), ForceMode2D.Impulse);
    }
}