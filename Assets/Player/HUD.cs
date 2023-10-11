using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public GUISkin hudSkin, hudInfoSkin;
	public GUIStyle buttonSkin;
	
	//Building types
	public string[] buildingTypes;
	public string[] miningTypes;
		public GameObject[] miners;
		public GameObject[] gasMiners;
		public GameObject[] drilling;
		public GameObject[] refining;
		public GameObject[] mStorage;
		public GameObject[] mResearch;
	public string[] transportTypes;
		public GameObject[] depots;
		public GameObject[] offworldShipment;
		public GameObject[] pipeLines;
		public GameObject[] drones;
	public string[] factoryTypes;
		public GameObject[] factories;
		public string[] prodLines;
			public GameObject[] basicLines;
			public GameObject[] roboLines;
			public GameObject[] assemLines;
			public GameObject[] atomLines;
		public string[] recyclers;
			public GameObject[] incinerators;
			public GameObject[] deconstructors;
			public GameObject[] atomDis;
		public GameObject[] fResearch;
	public string[] coloniseTypes;
		public string[] cityTypes;
			public GameObject[] cityType1;
			public GameObject[] cityType2;
			public GameObject[] cityType3;
		public GameObject[] services;
		public GameObject[] industry;
	public string[] bioTypes;
		public GameObject[] greenHouses;
		public GameObject[] fStorage;
		public GameObject[] filtering;
		public string[] domeTypes;
			public GameObject[] research;
			public GameObject[] agriculture;
			public GameObject[] pasturing;
	public string[] defenseTypes;
		public GameObject[] mechana;
		public GameObject[] bioMechana;
		public GameObject[] turrets;
	public string[] generalTypes;
		public GameObject[] housing;
		public GameObject[] recreation;
	public string[] spyTypes;
		public GameObject[] hideOuts;
		public string[] hackTypes;
			public GameObject[] servers;
			public GameObject[] executenate;
			public GameObject[] rd;
			public GameObject[] satellites;
	public string[] powerTypes;
		public GameObject[] solar;
		public GameObject[] wind;
		public GameObject[] thermal;
		public string[] nuclearTypes;
			public GameObject[] fission;
			public GameObject[] plutonium;
			public GameObject[] fusion;
		public GameObject[] pResearch;
	
	[HideInInspector]		
	public int hudSelect = 0;			
	
	private Player player;
	private UserInput input;
	private const int hudSkin_height = 50, buttonSkin_height = 50, buttonSkin_width = 200, hudButton_width = 130, HUD_height = 40, hudButton_width2 = 125;
	
	void Start () {
		player = transform.root.GetComponent<Player>();
		input = transform.root.GetComponent<UserInput>();
	}

	void OnGUI(){
		if (player && player.human){
			DrawHudBar();
			DrawBuildings();
			DrawHUD();
		}
	}
	
	public bool MouseInBounds(){
		Vector3 mousePos = Input.mousePosition;
		bool insideWidth;
		bool insideHeight;
		if (player.hudBuilding){
			insideWidth = mousePos.x >= 0 && mousePos.x <= Screen.width - buttonSkin_width;
		}
		else{
			insideWidth = mousePos.x >= 0 && mousePos.x <= Screen.width;
		}
		insideHeight = mousePos.y >= 0 && mousePos.y <= Screen.height - hudSkin_height;
		return insideWidth && insideHeight;
	}
	
	private void DrawHudBar(){
		GUI.skin = hudSkin;
		GUI.BeginGroup(new Rect(0, 0, Screen.width, hudSkin_height));
		GUI.Box(new Rect(0, 0, Screen.width, hudSkin_height),"");
		GUI.EndGroup();
	}
	
	private void DrawHUD(){
		GUI.skin = hudInfoSkin;
		GUI.BeginGroup(new Rect(0, 0, Screen.width, hudSkin_height));
		string money = "$" + player.money;
		GUI.Box(new Rect(10, 5, hudButton_width, 40), money);
		GUI.EndGroup();
	}

	private void DrawBuildings(){
		GUI.skin.button = buttonSkin;
		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
		
		//Building and Cancel Buttons
		if (hudSelect == 0){
			if (GUI.Button(new Rect(Screen.width - Screen.width/10, 5, Screen.width/10 - 10, hudSkin_height - 10), "Buildings")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect > 0){
			if (GUI.Button(new Rect(Screen.width - Screen.width/10, 5, Screen.width/10 - 10, hudSkin_height - 10), "Cancel")){
				hudSelect = 0;
				
				if (input.constructing = true){
					input.CancelBuilding();
				}
			}
		}
		
		//Choosing Building Type
		if (hudSelect == 1){
			for (int i = 0; i < buildingTypes.Length; i ++){
					if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), buildingTypes[i])){
					hudSelect = i + 2;
				}
			}
		}
		
		//Choosing Mining Type
		if (hudSelect == 2){
			for (int i = 0; i < miningTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), miningTypes[i])){
					hudSelect = i + 11;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 11){
			for (int i = 0; i < miners.Length; i ++){
				Building building = miners[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(miners[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 2;
			}
		}
		
		if (hudSelect == 12){
			for (int i = 0; i < gasMiners.Length; i ++){
				Building building = gasMiners[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(gasMiners[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 2;
			}
		}
		
		if (hudSelect == 13){
			for (int i = 0; i < drilling.Length; i ++){
				Building building = drilling[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(drilling[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 2;
			}
		}
		
		if (hudSelect == 14){
			for (int i = 0; i < refining.Length; i ++){
				Building building = refining[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(refining[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 2;
			}
		}
		
		if (hudSelect == 15){
			for (int i = 0; i < mStorage.Length; i ++){
				Building building = mStorage[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(mStorage[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 2;
			}
		}
		
		if (hudSelect == 16){
			for (int i = 0; i < mResearch.Length; i ++){
				Building building = mResearch[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(mResearch[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 2;
			}
		}
		
		//Choosing Transport Type
		if (hudSelect == 3){
			for (int i = 0; i < transportTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), transportTypes[i])){
					hudSelect = i + 20;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 20){
			for (int i = 0; i < depots.Length; i ++){
				Building building = depots[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(depots[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
						
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 3;
			}
		}
		
		if (hudSelect == 21){
			for (int i = 0; i < offworldShipment.Length; i ++){
				Building building = offworldShipment[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(offworldShipment[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 3;
			}
		}
		
		if (hudSelect == 22){
			for (int i = 0; i < pipeLines.Length; i ++){
				Building building = pipeLines[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(pipeLines[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 3;
			}
		}
		
		if (hudSelect == 23){
			for (int i = 0; i < drones.Length; i ++){
				Building building = drones[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(drones[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 3;
			}
		}

		//Choosing Manufacturing Type
		if (hudSelect == 4){
			for (int i = 0; i < factoryTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), factoryTypes[i])){
					hudSelect = i + 30;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 30){
			for (int i = 0; i < factories.Length; i ++){
				Building building = factories[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(factories[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 4;
			}
		}
		
		if (hudSelect == 31){
			for (int i = 0; i < prodLines.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), prodLines[i])){
					hudSelect = i + 130;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 4;
			}
		}
		
		if (hudSelect == 130){
			for (int i = 0; i < basicLines.Length; i ++){
				Building building = basicLines[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(basicLines[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 31;
			}
		}
		
		if (hudSelect == 131){
			for (int i = 0; i < roboLines.Length; i ++){
				Building building = roboLines[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(roboLines[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 31;
			}
		}
		
		if (hudSelect == 132){
			for (int i = 0; i < assemLines.Length; i ++){
				Building building = assemLines[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(assemLines[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 31;
			}
		}
		
		if (hudSelect == 133){
			for (int i = 0; i < atomLines.Length; i ++){
				Building building = atomLines[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(atomLines[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 31;
			}
		}
		
		
		if (hudSelect == 32){
			for (int i = 0; i < recyclers.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), recyclers[i])){
					hudSelect = i + 134;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 4;
			}
		}
		
		if (hudSelect == 134){
			for (int i = 0; i < incinerators.Length; i ++){
				Building building = incinerators[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(incinerators[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 32;
			}
		}
		
		if (hudSelect == 135){
			for (int i = 0; i < deconstructors.Length; i ++){
				Building building = deconstructors[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(deconstructors[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 32;
			}
		}
		
		if (hudSelect == 136){
			for (int i = 0; i < atomDis.Length; i ++){
				Building building = atomDis[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(atomDis[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 32;
			}
		}
		
		if (hudSelect == 33){
			for (int i = 0; i < fResearch.Length; i ++){
				Building building = fResearch[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(fResearch[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 4;
			}
		}
		
		//Choosing Colonisation Type
		if (hudSelect == 5){
			for (int i = 0; i < coloniseTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), coloniseTypes[i])){
					hudSelect = i + 40;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 40){
			for (int i = 0; i < cityTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), cityTypes[i])){
					hudSelect = i + 140;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 5;
			}
		}
		
		if (hudSelect == 140){
			for (int i = 0; i < cityType1.Length; i ++){
				Building building = cityType1[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(cityType1[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 40;
			}
		}
		
		if (hudSelect == 141){
			for (int i = 0; i < cityType2.Length; i ++){
				Building building = cityType2[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(cityType2[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 40;
			}
		}
		
		if (hudSelect == 142){
			for (int i = 0; i < cityType3.Length; i ++){
				Building building = cityType3[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(cityType3[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 40;
			}
		}
		
		if (hudSelect == 41){
			for (int i = 0; i < services.Length; i ++){
				Building building = services[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(services[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 5;
			}
		}
		
		if (hudSelect == 42){
			for (int i = 0; i < industry.Length; i ++){
				Building building = industry[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(industry[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 5;
			}
		}
		
		//Choosing Farming Types
		if (hudSelect == 6){
			for (int i = 0; i < bioTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), bioTypes[i])){
					hudSelect = i + 50;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 50){
			for (int i = 0; i < domeTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), domeTypes[i])){
					hudSelect = i + 60;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 6;
			}
		}
		
		if (hudSelect == 60){
			for (int i = 0; i < research.Length; i ++){
				Building building = research[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(research[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 50;
			}
		}
		
		if (hudSelect == 61){
			for (int i = 0; i < agriculture.Length; i ++){
				Building building = agriculture[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(agriculture[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 50;
			}
		}
		
		if (hudSelect == 62){
			for (int i = 0; i < pasturing.Length; i ++){
				Building building = pasturing[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(pasturing[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 50;
			}
		}
		
		if (hudSelect == 51){
			for (int i = 0; i < greenHouses.Length; i ++){
				Building building = greenHouses[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(greenHouses[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 6;
			}
		}
		
		if (hudSelect == 52){
			for (int i = 0; i < filtering.Length; i ++){
				Building building = filtering[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(filtering[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 6;
			}
		}
		
		if (hudSelect == 53){
			for (int i = 0; i < fStorage.Length; i ++){
				Building building = fStorage[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(fStorage[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 6;
			}
		}
		
		//Choosing Defense Type
		if (hudSelect == 7){
			for (int i = 0; i < defenseTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), defenseTypes[i])){
					hudSelect = i + 70;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 70){
			for (int i = 0; i < turrets.Length; i ++){
				Building building = turrets[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(turrets[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 7;
			}
		}
		
		if (hudSelect == 71){
			for (int i = 0; i < mechana.Length; i ++){
				Building building = mechana[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(mechana[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 7;
			}
		}
		
		if (hudSelect == 72){
			for (int i = 0; i < bioMechana.Length; i ++){
				Building building = bioMechana[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(bioMechana[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 7;
			}
		}
		
		//Choosing Espionage Type
		if (hudSelect == 8){
			for (int i = 0; i < spyTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), spyTypes[i])){
					hudSelect = i + 80;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 80){
			for (int i = 0; i < hideOuts.Length; i ++){
				Building building = hideOuts[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(hideOuts[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 8;
			}
		}
		
		if (hudSelect == 81){
			for (int i = 0; i < hackTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), hackTypes[i])){
					hudSelect = i + 90;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 8;
			}
		}
		
		if (hudSelect == 90){
			for (int i = 0; i < servers.Length; i ++){
				Building building = servers[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(servers[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 81;
			}
		}
		
		if (hudSelect == 91){
			for (int i = 0; i < executenate.Length; i ++){
				Building building = executenate[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(executenate[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 81;
			}
		}
		
		if (hudSelect == 92){
			for (int i = 0; i < satellites.Length; i ++){
				Building building = satellites[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(satellites[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 81;
			}
		}
		
		if (hudSelect == 93){
			for (int i = 0; i < rd.Length; i ++){
				Building building = rd[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(rd[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 81;
			}
		}
		
		//Choosing Power Type
		if (hudSelect == 9){
			for (int i = 0; i < powerTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), powerTypes[i])){
					hudSelect = i + 100;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 100){
			for (int i = 0; i < solar.Length; i ++){
				Building building = solar[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(solar[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 9;
			}
		}
		
		if (hudSelect == 101){
			for (int i = 0; i < wind.Length; i ++){
				Building building = wind[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(wind[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 9;
			}
		}
		
		if (hudSelect == 102){
			for (int i = 0; i < thermal.Length; i ++){
				Building building = thermal[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(thermal[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 9;
			}
		}
		
		if (hudSelect == 103){
			for (int i = 0; i < nuclearTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), nuclearTypes[i])){
					hudSelect = i + 110;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 9;
			}
		}
		
		if (hudSelect == 110){
			for (int i = 0; i < fission.Length; i ++){
				Building building = fission[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(fission[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 103;
			}
		}
		
		if (hudSelect == 111){
			for (int i = 0; i < plutonium.Length; i ++){
				Building building = plutonium[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(plutonium[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 103;
			}
		}
		
		if (hudSelect == 112){
			for (int i = 0; i < fusion.Length; i ++){
				Building building = fusion[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(fusion[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 103;
			}
		}
		
		if (hudSelect == 104){
			for (int i = 0; i < pResearch.Length; i ++){
				Building building = pResearch[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(pResearch[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 9;
			}
		}
		
		//Choosing General Type
		if (hudSelect == 10){
			for (int i = 0; i < generalTypes.Length; i ++){
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), generalTypes[i])){
					hudSelect = i + 120;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 1;
			}
		}
		
		if (hudSelect == 120){
			for (int i = 0; i < housing.Length; i ++){
				Building building = housing[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(housing[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 10;
			}
		}
		
		if (hudSelect == 121){
			for (int i = 0; i < recreation.Length; i ++){
				Building building = recreation[i].GetComponent<Building>();
				if (GUI.Button(new Rect(Screen.width - buttonSkin_width, buttonSkin_height + 50 * i, Screen.width, buttonSkin_height), building.name)){
					if (player.money >= building.cost){
						input.SetBuilding(recreation[i], building.cost);
						input.constructing = true;
						input.hasBuilt = false;
						hudSelect = 500;
					}
				}
			}
			
			if (GUI.Button(new Rect(Screen.width - (Screen.width/10 * 2), 5, Screen.width/10 - 10, hudSkin_height - 10), "Back")){
				hudSelect = 10;
			}
		}
		
		
		
		GUI.EndGroup();
	}
}