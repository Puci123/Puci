using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talia : MonoBehaviour {

    private Queue<Karta> talia = new Queue<Karta>();
    private Karta[] pTalia;
    public Karta[] tabCalkiemPomocniczy;



    private void Start()
    {
        Tasuj(tabCalkiemPomocniczy);
        Przekarz(3);
 

    }

    void Tasuj(Karta[] _talia)
    {

        pTalia = _talia;
        Karta temp;
        int k;
 
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

    void Przekarz(int ile)
    {
        print(talia.Count);
        for (int i = 0; i < ile; i++)
        {
            Karta kar = talia.Peek() as Karta;
            talia.Dequeue();

            GetComponent<Ręka>().DobierzStart(kar);

        }
    }

    
         
    
  }


