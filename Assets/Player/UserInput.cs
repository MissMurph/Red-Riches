using GRM;
using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {
	
	//Refences
	private Player player;
	private HUD hud;
	public LayerMask ground;
	public LayerMask unwalkable;
	
	//Movement variables
	private int scrollSpeed;
	private float xRot;
	private float yRot;
	
	//Building creation variables
	public bool hasBuilt;
	public bool constructing = false;
	private bool shift = false;
	private bool buildModule = false;
	private int cost;
	private Transform buildingSelect;
	private Transform buildParent;
	private GameObject buildingCreate;
	private Vector3 localPos;
	private BuildingHolo ghost = null;
	private Building currentBuilding;
	
	void Start () {
		player = transform.root.GetComponent<Player>();
		hud = GetComponentInChildren<HUD>();
	}
	
	void Update () {
		if (player && player.human){
			MouseActivity();
			if (buildingSelect != null) PlaceBuilding();
			if (Input.GetKeyDown(KeyCode.LeftShift)) shift = true;
			else if (Input.GetKeyUp(KeyCode.LeftShift)){ 
				shift = false;
				if (constructing == true && hasBuilt == false){
					CancelBuilding();
				}
			}
		}
	}
	
	public void SetBuilding(GameObject building, int c){
		currentBuilding = building.GetComponent<Building>();
		GameObject g = currentBuilding.buildGhost;
		buildingCreate = building;
		buildingSelect = ((GameObject) Instantiate(g)).transform;
		ghost = buildingSelect.GetComponent<BuildingHolo>();
		cost = c;
		ghost.building = currentBuilding;
	}
	
	public void CancelBuilding(){
	if (buildingSelect != null && buildingCreate != null && constructing == true && hasBuilt == false){
			buildingSelect = null;
			buildingCreate = null;
			ghost.Die();
			cost = 0;
			constructing = false;
			hasBuilt = true;
			hud.hudSelect = 0;
			buildModule = false;
		}
	}
	
	private void PlaceBuilding(){
		if (hud.MouseInBounds()){
			if (!hasBuilt){
				GameObject hitObject = FindHitObject();
				Vector3 hitPoint = FindHitPoint();
				if (hitObject != null && currentBuilding.canMod == true && hitObject.GetComponent<Building>() != null && hitObject.GetComponent<Building>().canBeModded == true){
					bool mod = currentBuilding.canMod;
					Building b = hitObject.GetComponent<Building>();
					if (mod == true && b.canBeModded == true){
						if (b.currentModules < b.maxModules && b.canBeModded == true && b != null){
							switch(b.currentModules){
								case 0:
									localPos = b.modPos1;
									break;
								case 1:
									localPos = b.modPos2;
									break;
								case 2:
									localPos = b.modPos3;
									break;
								case 3:
									localPos = b.modPos4;
									break;
								case 4:
									localPos = b.modPos5;
									break;
								case 5:
									localPos = b.modPos6;
									break;
								case 6:
									localPos = b.modPos7;
									break;
								case 7:
									localPos = b.modPos8;
									break;
							}
							buildingSelect.parent = hitObject.transform;
							buildParent = hitObject.transform;
							buildingSelect.localPosition = localPos;
							ghost.ChangeMesh(true);
							buildModule = true;
						}
					}
				}
				else {
					if (hitPoint != ResourceManager.InvalidPosition){
						buildingSelect.parent = null;
						buildParent = null;
						buildingSelect.position = hitPoint;
						buildingSelect.LookAt(transform.position);
						ghost.ChangeMesh(false);
						buildModule = false;
					}
				}
			}
		}
	}
	
	private bool IsLegalPosition(){
		if (constructing == true){
			if (ghost){
				if (ghost.count > 0) return false;
				return true;
			}
		}
		return false;
	}
	
	private void MouseActivity(){
		if (Input.GetMouseButtonDown(0)) LeftClick();
		else if (Input.GetMouseButton(1)) MoveCamera();
		if (Input.GetMouseButtonUp(1)) Screen.lockCursor = false;
	}
	
	private void MoveCamera(){
		Screen.lockCursor = true;
		
		float speed = ResourceManager.ScrollSpeed;
		
		xRot += Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
		yRot += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
		xRot = Mathf.Clamp(xRot, -90, 90);
		
		transform.rotation = Quaternion.Euler(xRot, yRot, 0);
	}
	
	private void LeftClick(){
		if (hud.MouseInBounds()){
			if (constructing = true){
				if (!hasBuilt){
					if (IsLegalPosition() || buildModule){
						if (player.money >= buildingCreate.GetComponent<Building>().cost){
							Vector3 t = buildingSelect.transform.position;
							Quaternion r = buildingSelect.rotation;
							GameObject b = ((GameObject) Instantiate(buildingCreate));
							b.transform.position = t;
							b.transform.rotation = r;
							if (buildParent != null){
								b.transform.parent = buildParent;
							}
							Building b2 = b.GetComponent<Building>();
							b2.module = buildModule;
							player.money -= cost;
							if (!shift){
								CancelBuilding();
							}
						}
					}
				}
			}
		}
	}
	
	private GameObject FindHitObject(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, unwalkable)) return hit.collider.gameObject;
		return null;
	}
	
	private Vector3 FindHitPoint(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground)) return hit.point;
		return ResourceManager.InvalidPosition;
	}
}