using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animation anim;
    enum ENEMY_STATE
    {
        IDLE, PATROL, ALERT, CHASING, ATTACK, HIT, DIE
    }

    private ENEMY_STATE currentState = ENEMY_STATE.IDLE;


    void startPatrol()
    {
        currentState = ENEMY_STATE.PATROL;
        //TODO: init patrol state

    }

    void startAlert()
    {
        currentState = ENEMY_STATE.ALERT;
    }

    
    void startChasing()
    {
        currentState = ENEMY_STATE.CHASING;
        //TODO: init chasing state
    }

    void startAttack()
    {
        currentState = ENEMY_STATE.ATTACK;
    }
    void startHit()
    {
        currentState = ENEMY_STATE.HIT;
    }

    void startDie()
    {
        currentState = ENEMY_STATE.DIE;
    }
    void updateIdle()
    {
        anim.CrossFade("Dron_die");
    }

    private void updatePatrol()
    {
       
    }
    void updateAlert()
    {
        anim.CrossFade("Dron_alert");
    }
    void updateChasing()
    {

    }
    void updateAttack()
    {

    }
    void updateHit()
    {

    }
    void updateDie()
    {
        anim.CrossFade("Dron_die");
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
            case ENEMY_STATE.ALERT:
                updateAlert();
                break;
            case ENEMY_STATE.CHASING:
                updateChasing();
                break;
            case ENEMY_STATE.ATTACK:
                updateAttack();
                break;
            case ENEMY_STATE.HIT:
                updateHit();
                break;
            case ENEMY_STATE.DIE:
                updateDie();
                break;

        }
    }

}

interface EnemyState
{
    void setState(Enemy enemy);
    void updateState(Enemy enemy);
}
