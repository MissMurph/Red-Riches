using UnityEngine;
using System.Collections;

namespace GRM {
	public static class ResourceManager {
		
		//Public variables
		public static float ScrollSpeed{get{return 150;}}
		public static float zoomSpeed{get{return 4000;}}
		public static int MinCameraHeight{get{return 110;}}
		public static int MaxCameraHeight{get{return 200;}}
		private static Vector3 invalidPosition = new Vector3(-99999, -99999, -99999);
		public static Vector3 InvalidPosition{get{return invalidPosition;}}
		
		//Private variables
		
	}
}