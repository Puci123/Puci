using System.Collections.Generic;
using UnityEngine;

public class Wyszukaj : MonoBehaviour {

    Grid grid;

    void Awake()
    {
        grid = GetComponent<Grid>(); // oba skrypty są na obiekcie A*
    }

    Vector3[] FindPath(Vector3 startPos, Vector3 endPos)
    {
        Node start = grid.NodeFromWorldPoint(startPos); // Węzeł startowy
        Node target = grid.NodeFromWorldPoint(endPos);  // Węzeł końcowy, szukamy ścieżki pomiędzy tymi dwoma punktami

        Vector3[] waypoints = new Vector3[0]; // kontener w którym przetrzymujemy węzły
        bool succeded = false;                // czy operacja wyszukiwania scieżki się powiodła

        if (start.walkable && target.walkable) // oba pola musza byc 'przemieszczalne'
        {
            List<Node> openSet = new List<Node>();          // Lista węzłów gotowych do odwiedzenia, z odpowiednio policzonymi wartosciami
            List<Node> closedSet = new List<Node>();  // Lista węzłów odwiedzonych, żeby nie chodzić w 'kółko'
            openSet.Add(start);
            while (openSet.Count > 0)
            {
                Node current = openSet[0];
                // wyszukujemy węzła z najmniejszym kosztem w Liscie węzłów 'otwartych' 
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].fCost <= current.fCost)
                    {
                        if (openSet[i].hCost < current.hCost)
                            current = openSet[i];
                    }
                }
                // odwiedzamy ten węzeł
                openSet.Remove(current);
                closedSet.Add(current);

                // jeżeli jest on docelowy to zakoncz dzialanie
                if (current == target)
                {
                    succeded = true;
                    break;
                }

                // jezeli nie to przeszukaj sąsiadów w poszukiwaniu następnego kroku
                // tutaj wyceniamy sąsiadów 
                foreach (Node neighbour in grid.Neighbours(current))
                {
                    // jeżeli nie można chodzić po sąsiednim polu albo to pole zostalo juz odwiedzone to nie bierzmy go pod uwagę
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                        continue;
                    // koszt przejscia z current node do neighbour node'a:
                    int movementCost = current.gCost + GetDistance(current, neighbour);
                    // jeżeli oddalamy się do punktu startowego 
                    if (movementCost < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        // wyliczenie kosztów przejścia
                        neighbour.gCost = movementCost;
                        neighbour.hCost = GetDistance(neighbour, target);
                        // bardzo ważne, by było wiadomo skąd przyszliśmy, dlatego śledzimy ścieżkę przez rodziców
                        // rodzic jest węzłem z którego przechodzimy na sąsiedni.
                        neighbour.parent = current;
                        if (!openSet.Contains(neighbour))
                            openSet.Add(neighbour);
                    }
                }
            }
        }
        if (succeded)
            return RetracePath(start, target);
        else
            return null;
    }
    /*
     * Metoda słóży do prześledzenia ścieżki. Wywołujemy ją w momencie gdy węzeł aktualny jest równy końcowemu
     * Wywoływana w metodzie - FindPath(V3,V3);
     * Tworzy liste węzłów, które są najkrótszą ścieżką do podanego celu.
     * Tą listę przekazuje do Obiektu Grid - gdzie ją ładnie wyrysowuje
     */
    Vector3[] RetracePath(Node start, Node target)
    {
        List<Node> path = new List<Node>();
        Node current = target; // będziemy śledzić ścieżkę od końca
        while (current != start)
        {
            path.Add(current);
            current = current.parent;
        }

        Vector3[] simplifiedPath = SimplifyPath(path);
        System.Array.Reverse(simplifiedPath);  // żeby uzyskać poprawną kolejność scieżki

        return simplifiedPath;
    }

    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i - 1].x - path[i].x, path[i - 1].y - path[i].y);
            if (directionNew != directionOld) // to nastąpiła zmiana kierunku
            {
                waypoints.Add(path[i].pos);
            }
            directionOld = directionNew;
        }

        return waypoints.ToArray();
    }

    /*
     * Metoda zwraca odległość między węzłami odpowiednio wyceniając scieżkę 
     */
    int GetDistance(Node a, Node b)
    {
        int distanceX = Mathf.Abs(a.x - b.x);
        int distanceY = Mathf.Abs(a.y - b.y);

        // równanie wyceniajace przejscie - 14 - waga przejscia na diagonali, 10 - waga przejscia na wprost.
        //  Wzięło się to od kwadratu jednostkowego gdzie a = 1, to przekątna d = 1,44, przemnazamy przez 10 zeby int;
        if (distanceX > distanceY)
            return 14 * distanceY + 10 * (distanceX - distanceY);
        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
}
