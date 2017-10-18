using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public Transform target;
    private Vector3 targetPosOld = Vector3.one;
    float speed = 20.0f;
    Vector3[] path;
    int index;

    //void Awake()
    //{
    //    target.position = transform.position;     
    //}

    void Update()
    {
        Vector3 targetPosNew = target.position;
        if(targetPosNew != targetPosOld)
            PathManager.RequestPath(transform.position, target.position, OnPathFound);
        targetPosOld = targetPosNew;
    }
    public void OnPathFound(Vector3[] _path, bool succes)
    {
        if (succes)
        {
            path = _path;
            index = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
    IEnumerator FollowPath()
    {
        Vector3 current = path[0];
        while (true)
        {
            if (transform.position == current)
            {
                index++;
                if (index >= path.Length)
                {
                    yield break;
                }
                current = path[index];
            }
            transform.position = Vector3.MoveTowards(transform.position, current, speed * Time.deltaTime);
            yield return null; // żeby przejść do następnej klatki
        }
    }

    public void OnDrawGizmos()
    {
        if(path != null)
        {
            for (int i = index ; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);
                if (i == index)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i-1], path[i]);
                }    
            }
        }
    }
}
