using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : State<Enemy>
{
    #region ------------- State method implementation -------------
    public override void InitState(Enemy controller)
    {

    }
    public override void UpdateState(Enemy controller)
    {
        controller.NavMeshAgent.SetDestination(controller.Player.transform.position);
    }
    public override void DeinitState(Enemy controller)
    {

    }
    #endregion
}
