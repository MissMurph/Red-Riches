using UnityEngine;
using System.Collections;

public class TorchMoneyGen : MonoBehaviour {
	
	private Player player;
	private int time = 60;
	private int produce = 10;

	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	void FixedUpdate () {
		time -= 1;
		
		if (time < 1){
			player.money += produce;
			time = 60;
		}
	}
}
