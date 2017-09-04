using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StworzTalie : MonoBehaviour {

    public Transform tranAtak;
    public Transform tranObrona;
    public Transform tranRuch;
    public Transform tranTalia;
    public Transform rewers;
    public Reka reka;
    private Queue<Transform> talia = new Queue<Transform>();

    void Start () {
        Zmienne.talia = new Zmienne.Typy[10];
        for (int i = 0; i < 10; i++)
        {
            Zmienne.talia[i] = Zmienne.Typy.atak;
        }
        Tasuj(Zmienne.talia);
        Stworz();
        Dobierz(3);
	}
	
	void Update () {
		
	}
    void Tasuj(Zmienne.Typy[] _talia)
    {
        Zmienne.Typy temp;
        int k = 0;
        for (int i = 0; i < _talia.Length / 2; i++)
        {
            temp = _talia[i];
            k = Random.Range(i, _talia.Length);
            _talia[i] = _talia[k];
            _talia[k] = temp;
        }
    }

    void Stworz()
    {
        Transform temp;

        foreach (var item in Zmienne.talia)
        {
           if(item == Zmienne.Typy.atak)
            {
                temp = tranAtak;
            }
            else if(item == Zmienne.Typy.obrona)
            {
                temp = tranObrona;
            }
            else
            {
                temp = tranRuch;
            }
            temp = Instantiate(temp, tranTalia);
            temp.gameObject.GetComponent<Przeciagnij>().CzyJestWTali(true);
            talia.Enqueue(temp);  
        }
        Instantiate(rewers, tranTalia);
    }

    void Dobierz(int ile)
    {
        for (int i = 0; i < ile; i++)
        {
            Transform kar = talia.Peek();
            kar.gameObject.GetComponent<Karta>().CzyJestWTali(false);
            talia.Dequeue();
            reka.Dobierz(kar);
        }
    }
}
