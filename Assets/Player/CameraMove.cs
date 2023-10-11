using GRM;
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	float movement = 200;
	
	void Update(){
		float speed = ResourceManager.zoomSpeed;
		int max = ResourceManager.MaxCameraHeight;
		int min = ResourceManager.MinCameraHeight;
		
		movement -= Input.GetAxis("Mouse ScrollWheel") * speed * Time.deltaTime;
		movement = Mathf.Clamp(movement, min, max);
		
		transform.localPosition = new Vector3(0, 0, movement);
	}
}