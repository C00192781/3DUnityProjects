using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> path;

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        Transform[] childs = transform.GetComponentsInChildren<Transform>();
        path = new List<Transform>();
        foreach (Transform c in childs)
        {
            if (c != transform)
            {
                path.Add(c);
            }
        }
        for (int index = 0; index < path.Count; index++)
        {
            Vector3 pos = path[index].position;
            if (index > 0)
            {
                Vector3 previous = path[index - 1].position;
                Gizmos.DrawLine(previous, pos);
                Gizmos.DrawWireSphere(pos, 0.3f);
            }
        }
    }
}
