using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StworzTalie : MonoBehaviour {

    public int ileKartNaStart;
    public int kartyWTali;
    public Cmentarz cmentarz;

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
            Zmienne.talia[i] = Zmienne.Typy.ruch;
        }
        Tasuj(Zmienne.talia);

        kartyWTali = 10;
        Stworz();
        Dobierz(ileKartNaStart);

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

    public void Dobierz(int ile)
    {

        if (kartyWTali <= 2)
        {
            cmentarz.Przekaz();
        }

        for (int i = 0; i < ile; i++)
        {
            Transform kar = talia.Peek();
            kar.gameObject.GetComponent<Karta>().CzyJestWTali(false);
            talia.Dequeue();
            reka.Dobierz(kar);
            kartyWTali--;
        }  
    }

    public void WezKarty(Transform[] _karty)
    {
        
        foreach (var item in _karty)
        {
            if (item != null)
            {
                item.gameObject.GetComponent<Karta>().CzyJestWTali(true);
                item.transform.SetParent(tranTalia);
                item.transform.position = tranTalia.position;
                talia.Enqueue(item);
                kartyWTali++;
            }
        }
    }
}
