using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State
{
    public PlayerJump(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void Enter()                                                                    // masuk ke state ini dengan suatu kondisi
    {
        base.Enter();
        player.rb.velocity = new Vector3(player.rb.velocity.x, player.jumpForce, player.rb.velocity.z);                   // memberikan lompatan pada karakter
    }

    public override void Update()                                                                   // update state
    {
        base.Update();
        player.rb.velocity = new Vector3(horizontalInput * player.moveSpeed, player.rb.velocity.y, verticalInput * player.moveSpeed); // menggerakkan karakter ketika di udara

        if (player.rb.velocity.y == 0)
        {
            player.fsm.ChangeState(player.playerIdle);                                              // jika pemain jatuh, maka ubah state ke idle
        }
    }

    public override void Exit()                                                                     // memanggil base state dan keluar dari state
    {
        base.Exit();
    }
}