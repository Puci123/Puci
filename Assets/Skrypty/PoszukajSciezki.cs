using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoszukajSciezki : MonoBehaviour {

    public Grid siatka;

    void ZnajdzSciezke(Node start,Node koniec)
    {
        List<Node> zamknieta = new List<Node>();
        List<Node> otwarta = new List<Node>();
        Node aktualny = start;
        otwarta.Add(start);
        

        while (otwarta.Count > 0)
        {
            aktualny = otwarta[0];
            //Poszkiwanie najmiejszego f cost
            foreach (Node o in otwarta)
            {
                if (o.fCost < aktualny.fCost)
                    aktualny = o;
            }
            otwarta.Remove(aktualny);
            if (aktualny == koniec)
                break;
            List<Node> nastepcy = ZnajdzNastepcow(aktualny);

            foreach (var n in nastepcy)
            {
                int koszt = aktualny.gCost + ZnajdzOdleglosc(aktualny, n);
                if (otwarta.Contains(n))
                {
                    if (n.gCost <= koszt)
                        continue;
                }
                else if (zamknieta.Contains(n))
                {
                    if (n.gCost <= koszt)
                        continue;
                    zamknieta.Remove(n);
                    otwarta.Add(n);
                }
                else
                {
                    otwarta.Add(n);
                    n.hCost = ZnajdzOdleglosc(n, koniec);
                }
                n.gCost = koszt;
                n.parent = aktualny;
            }

            zamknieta.Add(aktualny);
        }
        if (aktualny == koniec)
            return;
        OdtworzScieszke(start);
    }

    List<Node> ZnajdzNastepcow(Node n)
    {
        if(n.x == 0 || n.x == siatka.nodesX - 1)
        {
            return null;
        }
        else if(n.y == 0 || n.y == siatka.nodesY - 1)
        {
            return null;
        }

        List<Node> nastepcy = new List<Node>();

        for (int i = n.x - 1; i < n.x + 2; i++)
        {
            for (int j = n.y - 1; j < n.y + 2; j++)
            {
                if (i != n.x && j != n.y)
                    nastepcy.Add(siatka.grid[i,j]);
            }
        }

        return nastepcy;
    }

    int ZnajdzOdleglosc(Node s,Node k)
    {
        return 0;
        
    }

    Vector3[] OdtworzScieszke(Node koniec)
    {
        List<Node> sciezka = new List<Node>();
        Node temp = koniec;
  
        while(temp.parent != null)
        {
            sciezka.Add(temp);
            temp = temp.parent;
        }
        Vector3[] gotowaSciezka = NaVector(sciezka);
        return gotowaSciezka;
    }

    Vector3[] NaVector(List<Node> lista)
    {
        Vector3[] gotowaSciezka = new Vector3[lista.Count];
        for (int i = 0; i < lista.Count; i++)
        {
            gotowaSciezka[i] = lista[i].pos;
        }
        System.Array.Reverse(gotowaSciezka);
        return gotowaSciezka;
    }
}
