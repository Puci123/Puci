using System.Collections.Generic;
using UnityEngine;

public class Talia : MonoBehaviour {

    private Queue<Karta> talia = new Queue<Karta>();
    public Karta[] tabCalkiemPomocniczy; // do testowania talii

    private void Start()
    {
        Tasuj(tabCalkiemPomocniczy);
        Dobierz(3);
    }

    void Tasuj(Karta[] pTalia)
    {
        Karta temp;
        int k; // indeks do tasowania
 
        for (int i = 0; i < pTalia.Length / 2; i++)
        {
            temp = pTalia[i];
            k = Random.Range(i, pTalia.Length);
            pTalia[i] = pTalia[k];
            pTalia[k] = temp;
        }
        foreach (var item in pTalia)
        {
            talia.Enqueue(item);
        }
    }

    void Dobierz(int ile)
    {
        print(talia.Count);
        for (int i = 0; i < ile; i++)
        {
            Karta kar = talia.Peek() as Karta;
            talia.Dequeue();
            GetComponent<Reka>().Dobierz(kar);
        }
    }
  }


