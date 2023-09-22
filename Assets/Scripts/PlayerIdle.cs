using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State
{
    public PlayerIdle(Player player, string animBoolName) : base(player, animBoolName)
    {
    }

    public override void Enter()                            // masuk ke state ini dengan suatu kondisi
    {
        base.Enter();
        player.rb.velocity = Vector3.zero;                  // mengatur velocity ke 0
    }

    public override void Update()                           // update state
    {
        base.Update();

        if (horizontalInput != 0 || verticalInput != 0)     // jika pemain meng-input tombol a atau d, maka ubah state ke run
        {
            player.fsm.ChangeState(player.playerRun);
        }
    }

    public override void Exit()                             // memanggil base state dan keluar dari state
    {
        base.Exit();
    }
}