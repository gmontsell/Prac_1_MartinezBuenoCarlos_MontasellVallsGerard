using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum ENEMY_STATE
    {
        PATROL, CHASING, IDLE
    }

    private ENEMY_STATE currentState = ENEMY_STATE.IDLE;


    void startPatrol()
    {
        currentState = ENEMY_STATE.PATROL;
        //TODO: init patrol state

    }

    void startChasing()
    {
        currentState = ENEMY_STATE.CHASING;
        //TODO: init chasing state
    }

    private void updatePatrol()
    {
        //TODO UPDATE STATE
        //TODO: check out conditiions
    }

    void updateChasing()
    {

    }

    void updateIdle()
    {

    }


    private void Update()
    {
        switch (currentState)
        {
            case ENEMY_STATE.IDLE:
                updateIdle();
                break;
            case ENEMY_STATE.PATROL:
                updatePatrol();
                break;

        }
    }

}

interface EnemyState
{
    void setState(Enemy enemy);
    void updateState(Enemy enemy);
}
