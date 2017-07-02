using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sciezka : MonoBehaviour {

    WyszkiwaczSciezek wyszukiwacz;
    Siatka siatka;

    void Awake()
    {
        siatka = GetComponent<Siatka>();
        wyszukiwacz = GetComponent<WyszkiwaczSciezek>();
    }

    void Init(Vector3 startPos, Vector3 endPos) {
        StartCoroutine(ZnajdzSciezke(startPos,endPos));

    }
    IEnumerator ZnajdzSciezke(Vector3 startPos, Vector3 endPos)
    {
        bool udalo = false;
        Wenzel start = siatka.WenelZeSwiata(startPos);
        Wenzel cel = siatka.WenelZeSwiata(endPos);
        Vector3[] posierdnie = new Vector3[0];

        if(start.hodliw && cel.hodliw)
        {
            List<Wenzel> otwarta = new List<Wenzel>();
            HashSet<Wenzel> zamknieta = new HashSet<Wenzel>();
            otwarta.Add(start);

            while(otwarta.Count > 0)
            {
                Wenzel aktualny = otwarta[0];
                for (int i = 1; i < otwarta.Count; i++)
                {
                    if(otwarta[i].fkoszt <= aktualny.fkoszt)
                    {
                        if (otwarta[i].hkoszt < aktualny.hkoszt)
                            aktualny = otwarta[i];
                    }
                }
                otwarta.Remove(aktualny);
                zamknieta.Add(aktualny);

                if(aktualny == cel)
                {
                    udalo = true;
                    break;
                }

                foreach (Wenzel samsiad in siatka.Sasiad(aktualny))
                {
                    if (!samsiad.hodliw || zamknieta.Contains(samsiad))
                        continue;
                    int koszt = aktualny.gkoszt + Dystans(aktualny, samsiad);
                    if(koszt < samsiad.gkoszt || !otwarta.Contains(samsiad))
                    {
                        samsiad.gkoszt = koszt;
                        samsiad.hkoszt = Dystans(aktualny, cel);
                        samsiad.rodzic = aktualny;
                        if (!otwarta.Contains(samsiad))
                            otwarta.Add(samsiad);
                    }
                }

            }
        }
        yield return null;
        if (udalo)
        {
            posierdnie = OdtworzSciezke(start, cel);
            // wyszkiwacz skończ
        }
    }

    Vector3[] OdtworzSciezke(Wenzel start,Wenzel cel)
    {
        List<Wenzel> sciezka = new List<Wenzel>();
        Wenzel aktualny = cel;

        while (aktualny != start)
        {
            sciezka.Add(aktualny);
            aktualny = aktualny.rodzic;

        }
        Vector3[] _sciezka = new Vector3[sciezka.Count];
        int i = 0;
        foreach (Wenzel w in sciezka)
        {
            _sciezka[i] = w.posW;
            i++;
        }
        Array.Reverse(_sciezka);
        return _sciezka;
    }

    int Dystans(Wenzel a, Wenzel b)
    {
        return 0;
    }

}
