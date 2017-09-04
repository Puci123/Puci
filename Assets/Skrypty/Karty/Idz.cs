using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idz : Karta {

    public int rozmiarX;
    public int rozmiarY;
    public float przerwa;
    public GameObject komorka;
    private Vector3 startPos;
    private Transform rodzic;

    void Generuj()
    {
        Vector3 spawnPos;
        startPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        rodzic = GameObject.Find("RodzicSiatki").GetComponent<Transform>();

        float przsuniecieX = przerwa * rozmiarX;
        float przuniecieY = przerwa * rozmiarY;

        spawnPos.y = 0;
        spawnPos.x = startPos.x;
        spawnPos.z = startPos.z;

        spawnPos.x = spawnPos.x - (rozmiarX + przsuniecieX) / 2;
        spawnPos.z = spawnPos.z - (rozmiarY + przuniecieY) / 2;

        for (int i = 0; i < rozmiarY; i++)
        {
            for (int j = 0; j < rozmiarX; j++)
            {
                Instantiate(komorka,new Vector3(spawnPos.x,spawnPos.y,spawnPos.z), Quaternion.identity,rodzic);
                spawnPos.x += 1 + przerwa;
            }
            spawnPos.x = spawnPos.x - rozmiarX - przsuniecieX;
            spawnPos.z += 1 + przerwa;
        }
    }


    override
        public void CzaryMary()
    {
        Generuj();
    }
}
