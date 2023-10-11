using UnityEngine;
using System.Collections;

public class NaturalObject : MonoBehaviour {

	private GameObject player;
	
	void Awake(){
		player = GameObject.Find("Player");
		Transform playerT = player.transform;
		transform.LookAt(playerT);
	}
}