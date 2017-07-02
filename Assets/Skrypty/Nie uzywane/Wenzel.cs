
using UnityEngine;

public class Wenzel : MonoBehaviour {

    public Wenzel rodzic;
    public int gkoszt, hkoszt;
    public float wielkosc;
    public bool hodliw;
    public Vector3 posW;
    public int x, y;

	public Wenzel(bool _hodliwy,Vector3 pos,int _x,int _y) {

        hodliw = _hodliwy;
        posW = pos;
        x = _x;
        y = _y;


    }

    public int fkoszt {

        get
        {
            return gkoszt + hkoszt;
        }
    }

}
