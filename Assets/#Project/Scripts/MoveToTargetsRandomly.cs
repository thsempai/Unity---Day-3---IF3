using UnityEngine;

public class MoveToTargetsRandomly : MoveToTargets
{

    protected override void MoveToNextDestination()
    {
        index = Random.Range(0, targets.Length);
        agent.SetDestination(CurrentDestination);
    }

}
