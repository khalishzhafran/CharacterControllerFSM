using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FSM fsm { get; private set; }

    public PlayerIdle playerIdle { get; private set; }

    public PlayerRun playerRun { get; private set; }

    public PlayerJump playerJump { get; private set; }

    public Animator animator { get; private set; }

    public Rigidbody rb { get; private set; }

    public float moveSpeed = 5;
    public float rotateSpeed = 10;

    public float jumpForce = 5;

    public bool isGrounded { get; private set; }

    private void Awake()                                    // ambil referensi komponen player
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()                                    // membuat state & FSM untuk player
    {
        fsm = new FSM();
        playerIdle = new PlayerIdle(this, "Idle");
        playerRun = new PlayerRun(this, "Run");
        playerJump = new PlayerJump(this, "Jump");

        fsm.Initialized(playerIdle);                        // inisialisasi state saat ini
    }

    private void Update()
    {
        fsm.CurrentState.Update();                          // update state saat ini
    }

    private void OnCollisionEnter(Collision other)      // cek apakah karakter player bertabrakan dengan ground
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)       // cek apakah karakter player tidak bertabrakan dengan ground
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}