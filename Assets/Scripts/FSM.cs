using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public State CurrentState { get; private set; }

    public void Initialized(State state)    // inisialisasi state awal
    {
        CurrentState = state;               // state awal
        CurrentState.Enter();               // menjalankan state
    }

    public void ChangeState(State newState) // mengganti state
    {
        CurrentState.Exit();                // mengakhiri state sebelum diganti
        CurrentState = newState;            // mengganti state
        CurrentState.Enter();               // menjalankan state baru
    }
}