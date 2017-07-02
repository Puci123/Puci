using UnityEngine;

public class Node {
    public bool walkable;
    public Vector3 pos;
    public int x, y; // pozycja w siatce węzłów
    
    // koszty przejścia 
    public int gCost; // od pozycji startowej
    public int hCost; // do pozycji końcowej

    public Node parent; // węzeł rodzicielski

    public Node(bool _walkable, Vector3 _pos, int gridX, int gridY)
    {
        walkable = _walkable;
        pos = _pos;
        x = gridX;
        y = gridY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
}
