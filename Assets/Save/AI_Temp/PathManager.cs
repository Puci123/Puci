using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasa która zarządza obliczaniem ścieżek
public class PathManager : MonoBehaviour {

    Queue<PathRequest> requests = new Queue<PathRequest>();
    PathRequest current;
    Pathfinding pathfinding;
    bool isProcessing;

    static PathManager instance;

    void Awake()
    {
        instance = this;
        pathfinding = GetComponent<Pathfinding>();
    }
    public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
    {
        PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
        instance.requests.Enqueue(newRequest);
        instance.TryProcess();

    }
    public void TryProcess()
    {
        if(!isProcessing && requests.Count > 0)
        {
            current = requests.Dequeue();
            isProcessing = true;
            pathfinding.Begin(current.pathStart, current.pathEnd);
        }
    }
    /*
     * Metoda wywoływana przez obiekt Pathfinding gdy ten skończy kalkulować jedną trasę
     */
    public void Finished(Vector3[] path, bool success)
    {
        current.callback(path, success);
        isProcessing = false;
        TryProcess();
    }

    struct PathRequest
    {
        public Vector3 pathStart;
        public Vector3 pathEnd;
        public Action<Vector3[], bool> callback;
        public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
        {
            pathStart = _start;
            pathEnd = _end;
            callback = _callback;
        }
    }
}
