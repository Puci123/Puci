using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


	public void UaktualnijPozycję(GeratorMapy.Mapa stara,GeratorMapy.Mapa nowa){
		nowa.pos.y = 0.61f;
		stara._pole = GeratorMapy.pole.puste;
		nowa._pole = GeratorMapy.pole.gracz;
	}


}
