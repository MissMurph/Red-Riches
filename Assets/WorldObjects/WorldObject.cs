using GRM;
using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {
	
	public GameObject buildGhost;
	public BuildingHolo ghost;
	public Mesh modMesh, mainMesh;
	public Texture modTex, mainTex;
	public string name;
	public Texture2D buildImage;
	public bool pipe = false, canMod = false, canBeModded = false, module = false;
	public int cost, sellValue, totalOutput, currentStorage, maxStorage, maxModules, currentModules;
	
	public Vector3 modPos1, modPos2, modPos3, modPos4, modPos5, modPos6, modPos7, modPos8;
	
	[HideInInspector]
	public GameObject[] attachedModules;
	public MeshFilter filter;
	
	protected Player player;
	
	protected virtual void Awake(){
		
	}
	
	protected virtual void Start(){
		player = transform.root.GetComponent<Player>();
		ghost = GetComponentInChildren<BuildingHolo>();
		if (mainMesh != null && modMesh != null){
			if (!module){
				GetComponentInChildren<MeshFilter>().mesh = mainMesh;
				GetComponentInChildren<Renderer>().material.mainTexture = mainTex;
			}
			else{
				GetComponentInChildren<MeshFilter>().mesh = modMesh;
				GetComponentInChildren<Renderer>().material.mainTexture = modTex;
			}
		}
	}
	
	protected virtual void Update () {
		
	}
	
	protected virtual void OnGUI(){
		
	}
}