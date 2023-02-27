using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public NodeScript next;

    public virtual NodeScript GetNext()
    {
        return next;
    }

    private void OnDrawGizmos()
    {
        if(next == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, next.transform.position);
    }
}
