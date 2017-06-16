﻿using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/TurnWhenTooClose")]
public class TurnWhenTooCloseAction : Action
{
    [Range(0,1800f)]
    public float rotatePerSecond = 120f;            //旋转速度

    //如果当前距离在停止距离内，旋转到目标
    public override void Act(StateController controller)
    {
        if (controller.chaseTarget == null)
            return;
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
        {
            Vector3 direction = controller.chaseTarget.position - controller.transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            controller.rigidbodySelf.rotation = Quaternion.RotateTowards(controller.transform.rotation, targetRotation, rotatePerSecond * Time.deltaTime);
        }
    }

}
