/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    #region State

    // Here you name the states
    public enum State
    {
        Idle,
        Pursuit,
        Firing,
        Avoiding,
    }
    public State state;

    IEnumerator FirstState()
    {
        while (state == State.Idle)
        {
            yield return 0;
        }
    }

    IEnumerator SecondState()
    {
        while (state == State.Pursuit)
        {
            yield return 0;
        }
    }

    IEnumerator ThirdState()
    {
        while (state == State.Firing)
        {
            yield return 0;
        }
    }

    IEnumerator FourthState()
    {
        while (state == State.Avoiding)
        {
            yield return 0;
        }
    }
    #endregion
    /* 
     * States:
     *  Idle
     *  Pursuit
     *  Firing
     *  Avoiding
    */

    /*private void ConditionToChange(State StateToChange)
    {
        // When you want to change states, you can just assign state as the wanted state
        state = StateToChange;
    }

    private void Update()
    {
        if (state == State.Idle)
        {
            
        }
        else if (state == State.Second)
        {
            state = State.Third;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        state = State.Second;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        state = State.First;
    }

}*/