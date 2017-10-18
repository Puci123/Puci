using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Node[,] grid;                // siatka węzłów, na niej działa algorytm
    public LayerMask unwalkable; // layer po którym nie można się poruszać
    public float radius;         // promień węzła
    public Vector2 size;         // wielkość siatki

    private float diameter; // średnica 
    public int nodesX, nodesY; // liczba węzłów na osiach
    public bool displayGizmos = true; // bool slóżący do wyswietlania siatki

    /*
     * Funkcja słóży do narysowania naszej kostki, w której będzie siatka węzłów
     */
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, 1, size.y));
        if (grid != null && displayGizmos)
        {
            foreach (Node n in grid)
            {

                if (n.walkable)
                    Gizmos.color = Color.white;
                else
                    Gizmos.color = Color.red;

                // zmniejszamy parametr diameter: (diameter - 0.1f) żeby było trochę miejsca między węzłami
                Gizmos.DrawCube(n.pos, Vector3.one * (diameter - 0.1f));
            }
        }
    }

    /*
     * Obliczamy ilość węzłów i tworzymy siatkę
     */
    void Awake()
    {
        diameter = radius * 2;
        nodesX = Mathf.RoundToInt(size.x / diameter);
        nodesY = Mathf.RoundToInt(size.y / diameter);
        CreateGrid();
    }
    
    public void CreateGrid()
    {
        grid = new Node[nodesX, nodesY];
        //print("Liczba pikseli: " + (nodesX*nodesY));
        // pozycja startowa, dolny lewy róg mapy. 
        // Vector3.right = new Vector3 (1,0,0) - wersor
        Vector3 start = transform.position - Vector3.right * size.x / 2 - Vector3.forward * size.y / 2;
        // 
        for (int i = 0; i < nodesX; i++)
        {
            for (int j = 0; j < nodesY; j++)
            {
                Vector3 pos = start + Vector3.right * (i * diameter + radius) + Vector3.forward * (j * diameter + radius);
                bool walkable = !(Physics.CheckSphere(pos, radius, unwalkable)); // jeżeli występuje kolizja to teren nie jest 'walkable'
                grid[i, j] = new Node(walkable, pos, i, j);
            }
        }
    }
    
    public List<Node> Neighbours(Node node)
    {
        List<Node> neigbours = new List<Node>();
        //pętle przeskakujące dookoła otrzymanego węzła
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                int x = node.x + i;
                int y = node.y + j;
                // musimy sprawdzić czy nasz x,y mieszczą się w siatce węzłów
                if (x >= 0 && x < nodesX && y >= 0 && y < nodesY)
                {
                    neigbours.Add(grid[x, y]);
                }
            }
        }
        return neigbours;
    }

    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + size.x / 2) / size.x;
        float percentY = (worldPosition.z + size.y / 2) / size.y;

        if (percentX > 1) percentX = 1;
        if (percentX < 0) percentX = 0;
        if (percentY > 1) percentY = 1;
        if (percentY < 0) percentY = 0;

        int x, y;
        x = Mathf.RoundToInt((size.x - 1) * percentX);
        y = Mathf.RoundToInt((size.y - 1) * percentY);

        return grid[x, y];
    }
}
