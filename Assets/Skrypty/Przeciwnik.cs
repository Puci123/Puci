using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przeciwnik : MonoBehaviour {

    public int hp = 2;

    public void PryjmijObrażenia(int ile)
    {
        hp -= ile;
        if (hp <= 0)
            Destroy(this.gameObject);
        print("Mam " + hp + " PŻ");
    }
}
