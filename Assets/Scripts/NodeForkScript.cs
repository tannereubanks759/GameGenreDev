using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeForkScript : NodeScript
{
    public NodeScript[] targets;

    public override NodeScript GetNext()
    {
        if (targets == null || targets.Length == 0)
        {
            return null;
        }
        int rng = Random.Range(0, targets.Length);
        return targets[rng];
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        foreach (var node in targets)
        {
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}
