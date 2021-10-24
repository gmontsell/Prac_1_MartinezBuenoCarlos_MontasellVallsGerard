using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animation anim;
    [SerializeField] private MeshAgentTarget agent;
    [SerializeField] private coneVision _coneVision;
    [SerializeField] private Droop_Items droop;
    [SerializeField] private GameObject attack_range;
    private void Start()
    {
        attack_range.SetActive(false);
    }
    enum ENEMY_STATE
    {
        IDLE, PATROL, ALERT, CHASING, ATTACK, HIT, DIE
    }

    private ENEMY_STATE currentState = ENEMY_STATE.IDLE;
    private ENEMY_STATE lastState = ENEMY_STATE.IDLE;

    public ENEMY_STATE 
    public void startPatrol()
    {
        currentState = ENEMY_STATE.PATROL;
        anim.enabled = false;
    }

    public void startAlert()
    {
        currentState = ENEMY_STATE.ALERT;
        attack_range.SetActive(false);
        anim.enabled = true;
    }

    
    public void startChasing()
    {
        currentState = ENEMY_STATE.CHASING;
        anim.enabled = false;
        attack_range.SetActive(true);
    }

    public void startAttack()
    {
        Debug.Log("Start Atac");
        currentState = ENEMY_STATE.ATTACK;
        Debug.Log("Tate atac? " + currentState);
    }
    public void startHit()
    {
        anim.enabled = true;
        lastState = currentState;
        currentState = ENEMY_STATE.HIT;
    }

    public void startDie()
    {
        currentState = ENEMY_STATE.DIE;
        

    }
    void updateIdle()
    {
        anim.CrossFade("Dron_idle_2");
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
        anim.CrossFade("Dron_alert_2");
        if (_coneVision.isTargetLocated())
        {
            startChasing();
            agent.targetDetected();
        }

    }
    void updateChasing()
    {
        Debug.Log("chasing");
        if (!_coneVision.isTargetLocated())
        {
            agent.enemyLost();
            startAlert();
        }
    }
    void updateAttack()
    {
        
        Debug.Log("Atac");
        //agent.targetDetected();
        //anim.enabled = true;
        //anim.CrossFade("Dron_atack_2");
    }
    void updateHit()
    {
        anim.CrossFade("Dron_hit_2");
        currentState = lastState;
    }
    void updateDie()
    {
        anim.CrossFade("Dron_die");
    }
    public void destroy()
    {
        droop.dropItem();
        anim.enabled = false;
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
