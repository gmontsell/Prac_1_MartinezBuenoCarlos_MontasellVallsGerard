using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animation anim;
    [SerializeField] private MeshAgentTarget agent; 
    [SerializeField] private Droop_Items droop;
    enum ENEMY_STATE
    {
        IDLE, PATROL, ALERT, CHASING, ATTACK, HIT, DIE
    }

    private ENEMY_STATE currentState = ENEMY_STATE.IDLE;
    private ENEMY_STATE lastState = ENEMY_STATE.IDLE;


    public void startPatrol()
    {
        currentState = ENEMY_STATE.PATROL;
        //TODO: init patrol state

    }

    public void startAlert()
    {
        currentState = ENEMY_STATE.ALERT;
    }

    
    public void startChasing()
    {
        currentState = ENEMY_STATE.CHASING;
        //TODO: init chasing state
    }

    public void startAttack()
    {
        currentState = ENEMY_STATE.ATTACK;
    }
    public void startHit()
    {
        Debug.Log("HIT: " + currentState);
        lastState = currentState;
        currentState = ENEMY_STATE.HIT;
        Debug.Log("HIT: " + lastState);
    }

    public void startDie()
    {
        currentState = ENEMY_STATE.DIE;
        

    }
    void updateIdle()
    {
        anim.CrossFade("Dron_idle");
    }

    private void updatePatrol()
    {

        if (agent.isOnPoint())
        {
            agent.nextPoint();
        }
    }
    void updateAlert()
    {
        Debug.Log("alert");
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
        Debug.Log("Hit");
        anim.CrossFade("Dron_hit_2");
    }
    void updateDie()
    {
        Debug.Log("die");
        anim.CrossFade("Dron_die");
        droop.dropItem();
        Destroy(gameObject);
    }

    public void startLastState()
    {
        currentState = lastState;
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
