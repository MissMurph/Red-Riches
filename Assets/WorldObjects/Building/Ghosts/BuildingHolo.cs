using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingHolo : MonoBehaviour {
	
	[HideInInspector]
	public int count;
	public Mesh filter;
	public Mesh modMesh, mainMesh;
	public Texture modTex, mainTex;
	public Building building;
	
	private UserInput input;
	
	void Start () {
		input = transform.root.GetComponent<UserInput>();
		filter = GetComponentInChildren<MeshFilter>().mesh;
		modMesh = building.modMesh;
		mainMesh = building.mainMesh;
		modTex = building.modTex;
		mainTex = building.mainTex;
	}
	

	void Update () {
		
	}
	
	public void OnTriggerEnter(Collider c){
		if (c.tag == "worldObject") count += 1;
	}
	
	public void OnTriggerExit(Collider c){
		if (c.tag == "worldObject") count -= 1;
	}
	
	public void ChangeMesh(bool mini){
		if (mini == true){
			GetComponentInChildren<MeshFilter>().mesh = modMesh;
			GetComponentInChildren<Renderer>().material.mainTexture = modTex;
		}
		else {
			GetComponentInChildren<MeshFilter>().mesh = mainMesh;
			GetComponentInChildren<Renderer>().material.mainTexture = mainTex;
		}
	}
	
	public void Die(){
		Destroy(gameObject);
	}
}