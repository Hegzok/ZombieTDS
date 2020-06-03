using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : StateMachine<Enemy>, IKillable
{
    [SerializeField] protected MonsterStats monsterStats;

    [SerializeField] protected MonsterInfo monsterInfo;
    public MonsterInfo MonsterInfo => monsterInfo;

    [SerializeField] protected Player player;
    public Player Player => player;

    [SerializeField] protected NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;

    protected virtual void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = DataStorage.Player;
        InitializeMonster();
        ChangeState(new EnemyChaseState());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UpdateState();
    }

    protected void InitializeMonster()
    {
        monsterInfo.monsterName = monsterStats.MonsterName;
        monsterInfo.maxHealth = monsterStats.MaxHealth;
        monsterInfo.movementSpeed = monsterStats.MovementSpeed;
        monsterInfo.damage = monsterStats.Damage;
        monsterInfo.attackSpeed = monsterStats.AttackSpeed;

        navMeshAgent.speed = monsterInfo.movementSpeed;
        monsterInfo.currentHealth = monsterInfo.maxHealth;
}

    public void TakeDamage(int damage)
    {
        monsterInfo.currentHealth -= damage;

        if (monsterInfo.currentHealth <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }

    #region ------- StateMachine methods implementation -------------
    public override void ChangeState(State<Enemy> newState)
    {
        currentState?.DeinitState(this);
        currentState = newState;
        currentState?.InitState(this);

    }

    public override void UpdateState()
    {
        currentState?.UpdateState(this);
    }
    #endregion
}

#region ---------- Structs --------------
[System.Serializable]
public struct MonsterInfo
{
    public string monsterName;
    public int maxHealth, currentHealth;
    public float movementSpeed;
    public int damage;
    public float attackSpeed;
}
#endregion
