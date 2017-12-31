using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolerPrzeciwnikow : MonoBehaviour {

    GameControler gc;
    int i = 0;


    void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameControler>();
    }

    public void RozpoczęcieTury()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy")) 
        {
            item.GetComponent<Przeciwnik>().RozpocnijTure();
        }
        gc.PasPrzeciwnika();
    }

    public void Nastempny() {
        i++;
    }
        
}
