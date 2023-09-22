using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public Player player { get; private set; }

    public string animBoolName { get; private set; }

    protected float horizontalInput;
    protected float verticalInput;

    protected bool jumpInput;

    public State(Player player, string animBoolName)
    {
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()                             // menyalakan animasi dari state yang sedang berjalan
    {
        player.animator.SetBool(animBoolName, true);
    }

    public virtual void Update()                            // membaca input & meng-handle tiap state
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        jumpInput = Input.GetKeyDown(KeyCode.Space);

        HandleRotation();

        if (jumpInput && player.isGrounded)
        {
            player.fsm.ChangeState(player.playerJump);
        }
    }

    public virtual void Exit()                              // mematikan animasi dari state saat ini
    {
        player.animator.SetBool(animBoolName, false);
    }

    protected void HandleRotation()
    {
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);       // mengatur rotasi player sesuai arah gerak

        if (direction == Vector3.zero)
        {
            direction = player.transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        Quaternion playerRotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * player.rotateSpeed);
        player.transform.rotation = playerRotation;
    }
}