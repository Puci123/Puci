using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeratorMapy : MonoBehaviour {
	public bool mapaWygerowana = false;
	public int rozmiarX, rozmiarY;
    public Vector3 startPos;
    public Vector3 playerSartPos;
	public enum pole{puste,wrog,gracz};
	public Mapa[,] map;

	public class Mapa{

		public pole _pole;
		public Vector3 pos;

		public Mapa(pole p,Vector3 _pos){
			_pole = p;
			pos = _pos;
		}
	}

    void Start()
    {
        Wez();
    }

    void Wez()
    {
        map = new Mapa[rozmiarX, rozmiarY];
        Vector3 pos = startPos;

        for (int i = 0; i < rozmiarY; i++)
        {
            for (int j = 0; j < rozmiarX; j++)
            {
                map[j, i] = new Mapa(pole.puste, pos);
                pos.x += 1;
            }
            pos.x = startPos.x;
            pos.z += 1;
        }
        Znajdz(playerSartPos)._pole = pole.gracz;

        foreach (var item in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Znajdz(new Vector3(item.transform.position.x, 0f, item.transform.position.z));
        }

    }

    public Mapa Znajdz(Vector3 pos)
    {
        foreach (var item in map)
        {
            if (Vector3.Distance(pos, item.pos) < 1f)
                return item;
        }
        return null;
    }

    public Mapa Znajdz(pole p)
    {
        foreach (var item in map)
        {
            if (p == item._pole)
                return item;
        }

        return null;
    }
}


