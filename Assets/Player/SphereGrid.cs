using UnityEngine;
using System.Collections;

public class SphereGrid : MonoBehaviour {
	
	public LayerMask unwalkableMask;
	public int pointCountX, pointCountY, pointCountX2, pointCountY2;
	public float pointSize;
	SpherePoint[,] grid;
	SpherePoint[,] grid2;
	int mergePoint = 38;
	float radius = 100;
	float pointJumpX, pointJumpY;

	void Start(){
		CreateGrid();
	}
	
	void CreateGrid(){
		grid = new SpherePoint[pointCountX, pointCountY];
		//grid2 = new SpherePoint[pointCountX, pointCountY];
		
		float startLat = 1;
		
		for (int x = 0; x < pointCountX; x++){
			for (int y = 0; y < pointCountY; y++){
				float lat = startLat + ((pointSize + pointJumpX) * x);
				float lon = (pointSize + pointJumpY) * y;
				//lat = Mathf.Clamp(lat, 0, 180);
				
				bool walkable = !(Physics.CheckSphere(worldPos(lat, lon), pointSize - 1, unwalkableMask));
				
				grid[x,y] = new SpherePoint(walkable, worldPos(lat, lon), pointSize, unwalkableMask);
			}
		}
		
		/*for (int x = 0; x < pointCountX; x++){
			for (int y = 0; y < pointCountY; y++){
				float lat = -startLat - ((pointSize + pointJumpX) * x);
				float lon = (pointSize + pointJumpY) * y;
				lat = Mathf.Clamp(lat, -180, 180);
				
				bool walkable = !(Physics.CheckSphere(worldPos(lat, lon), pointSize - 1, unwalkableMask));
				
				grid2[x,y] = new SpherePoint(walkable, worldPos(lat, lon), pointSize, unwalkableMask);
			}
		}*/
	}
	
	void Update(){
		if (grid != null){
			foreach(SpherePoint n in grid){
				n.walkable = !(Physics.CheckSphere(n.worldPos, pointSize - 1, unwalkableMask));
			}
		}
	}
	
	Vector3 worldPos(float lat, float lon){
		
		float latitude = Mathf.PI * lat / 180;
		float longitude = Mathf.PI * lon / 180;
		
		float xPos = radius * Mathf.Sin(latitude) * Mathf.Cos(longitude);
		float zPos = radius * Mathf.Sin(latitude) * Mathf.Sin(longitude);
		float yPos = radius * Mathf.Cos(latitude);
		
		Vector3 worldPos = new Vector3(xPos, yPos, zPos);
		return worldPos;
	}
	
	void OnDrawGizmos(){
		if (grid != null){
			foreach (SpherePoint n in grid){
				Gizmos.color = (n.walkable)?Color.cyan:Color.red;
				Gizmos.DrawCube(n.worldPos, Vector3.one * pointSize);
			}
		}
		if (grid2 != null){
			foreach (SpherePoint n in grid2){
				Gizmos.color = (n.walkable)?Color.cyan:Color.red;
				Gizmos.DrawCube(n.worldPos, Vector3.one * pointSize);
			}
		}
	}
}