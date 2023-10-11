using UnityEngine;
using System.Collections;

public class SpherePoint {

	public bool walkable;
	public Vector3 worldPos;
	public LayerMask unwalkableMask;
	public float size;

	public SpherePoint(bool _walkable, Vector3 _worldPos, float _size, LayerMask _unwalkable){
		walkable = _walkable;
		worldPos = _worldPos;
		size = _size;
	}
	
	void Update(){
		walkable = !(Physics.CheckSphere(worldPos, size, unwalkableMask));
	}
}