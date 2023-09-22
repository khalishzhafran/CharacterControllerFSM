using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : State
{
    public PlayerRun(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void Enter()                                        // masuk ke state saat ini
    {
        base.Enter();
    }

    public override void Update()                                       // update state
    {
        base.Update();

        if (horizontalInput == 0 && verticalInput == 0)                 // jika pemain tidak meg-input tombol a atau d, maka ubah state ke idle
        {
            player.fsm.ChangeState(player.playerIdle);
            return;
        }

        player.rb.velocity = new Vector3(horizontalInput * player.moveSpeed, player.rb.velocity.y, verticalInput * player.moveSpeed);     // menggerakkan player
    }

    public override void Exit()                                         // memanggil base state dan keluar dari state
    {
        base.Exit();
    }
}