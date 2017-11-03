using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmentarz : MonoBehaviour {

    public Transform[] karty;
    public StworzTalie talia;

	public void Przyjmij(Transform[] _karty)
    {
        foreach (var item in _karty)
        {
            if (item != null)
            {
                for (int i = 0; i < karty.Length - 1; i++)
                {
                    if (karty[i] == null)
                    {
                        karty[i] = item;
                        item.SetParent(transform);
                        item.position = Vector3.zero;
                        break;
                    }
                }
            }
        }
    }

    public void Tasuj()
    {
        int k;
        Transform temp;

        for (int i = 0; i < karty.Length/2; i++)
        {
            temp = karty[i];
            k = Random.Range(0, karty.Length);
            karty[i] = karty[k];
            karty[k] = temp;
        }
    }

    public void Przekaz()
    {
        Tasuj();
        talia.WezKarty(karty);

        for (int i = 0; i < karty.Length; i++)
        {
            karty[i] = null;
        }
       
    }
}
