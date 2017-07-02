using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siatka : MonoBehaviour {

    Wenzel[,] siatka;
    public  LayerMask mask;
    public float promien;
    private float srednica;
    public  Vector2 wielkosc;
    int iWenzlyY;
    int iWenzlyX;

    void Awake () {

        srednica = promien * 2;
        iWenzlyY = Mathf.RoundToInt(wielkosc.y / srednica);
        iWenzlyX = Mathf.RoundToInt(wielkosc.x / srednica);
        Stwoz();
    }
	
    void Stwoz()
    {
        siatka = new Wenzel[iWenzlyX, iWenzlyY];
        Vector3 startPos = transform.position - Vector3.right * wielkosc.x / 2 - Vector3.forward * wielkosc.y / 2;
        for (int i = 0; i < iWenzlyX; i++)
        {
            for (int j = 0; j < iWenzlyY; j++)
            {
                Vector3 pos = startPos + Vector3.right * (i * srednica + promien) + Vector3.forward * (j * srednica + promien);
                bool hodliwy = !(Physics.CheckSphere(pos, srednica, mask));
                siatka[i, j] = new Wenzel(hodliwy, pos,i, j);
            }
        }
    }

    public Wenzel WenelZeSwiata(Vector3 _pos)
    {
        float procentX = (_pos.x + wielkosc.x / 2) / wielkosc.x;
        float procentY = (_pos.y + wielkosc.x / 2) / wielkosc.y;

        if (procentX > 1) procentX = 1;
        if (procentX < 0) procentX = 0;
        if (procentY > 1) procentY = 1;
        if (procentY < 0) procentY = 0;

        int x, y;
        x = Mathf.RoundToInt((wielkosc.x - 1) * procentX);
        y = Mathf.RoundToInt((wielkosc.y - 1) * procentY);

        return siatka[x, y];

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(wielkosc.x, 1, wielkosc.y));

        //Gizmos.DrawCube(siatka[0, 0].posW, Vector3.one * 10);
        if (siatka != null)
        {
            foreach (var wenzel in siatka)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawCube(wenzel.posW, Vector3.one * (srednica - 0.1f));
            }
        }
    }

    public List<Wenzel> Sasiad(Wenzel w)
    {
        List<Wenzel> samsiady = new List<Wenzel>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1;j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                int x = w.x + i;
                int y = w.y + j;

                if (x >= 0 && x < iWenzlyX && y >= 0 && y < iWenzlyY)
                    samsiady.Add(siatka[x, y]);
            }
        }
        return samsiady;
    }
}
