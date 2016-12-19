using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HexCreate : MonoBehaviour {

    const float angle =60;
	public GameObject hex;
	public GameObject house;
	public GameObject road;
	GameObject r;
	public int mapHeight;
	public int mapWight;
	public List<Vector3> HexPosition = new List<Vector3>();
	public List<Vector3> HousesPosition = new List<Vector3> ();
	public float hex_D;
	public float x,y,z;





	
	// Use this for initialization
	void Start () {

		CreateMap ();
		CresteMapForHouses ();
		MakeRoad (HousesPosition [0], HousesPosition [3]);

		Debug.Log ( HousesPosition[3]);
		Debug.Log ( HousesPosition[0]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateMap(){

		getHexsPosition ();
		for (int i=0; i< HexPosition.Count; i++) {
			Instantiate (hex, HexPosition [i], this.transform.rotation);
		}
	}

	void CresteMapForHouses(){  

		foreach (Vector3 h in HexPosition) {
			if ( HousesPosition.Find (delegate(Vector3 v) {// |'
				return  v == new Vector3 (h.x, h.y + hex_D / Mathf.Sqrt (3), h.z) ;
				}) == new Vector3 () ) {
				HousesPosition.Add (new Vector3 (h.x, h.y + hex_D / Mathf.Sqrt (3), h.z));
			}

			if (HousesPosition.FindLast (delegate(Vector3 v) {// |.
				return v==new Vector3 (h.x, -(h.y + hex_D / Mathf.Sqrt (3)), h.z) ;
			}) == new Vector3 (0, 0, 0)) {
				HousesPosition.Add (new Vector3 (h.x, -(h.y + hex_D / Mathf.Sqrt (3)), h.z));
			}

			if (HousesPosition.FindLast (delegate(Vector3 v) {// '\
				return v==new Vector3 (h.x - hex_D / 2, h.y + (hex_D / Mathf.Sqrt (3)) / 2, h.z) ;
			}) == new Vector3 (0, 0, 0)) {
				HousesPosition.Add (new Vector3 (h.x - hex_D / 2, h.y + (hex_D / Mathf.Sqrt (3)) / 2, h.z));

			}

			if (HousesPosition.FindLast (delegate(Vector3 v) { // /'
				return v==new Vector3 (h.x + hex_D / 2, h.y + (hex_D / Mathf.Sqrt (3)) / 2, h.z);
			}) == new Vector3 (0, 0, 0)) {
				HousesPosition.Add (new Vector3 (h.x + hex_D / 2, h.y + (hex_D / Mathf.Sqrt (3)) / 2, h.z));

			}

			if (HousesPosition.Find(delegate(Vector3 v) { // /.
				return v== new Vector3 (h.x - hex_D / 2, h.y - (hex_D / Mathf.Sqrt (3)) / 2, h.z) ;
			}) == new Vector3 ()) {
				HousesPosition.Add (new Vector3 (h.x - hex_D / 2, h.y - (hex_D / Mathf.Sqrt (3)) / 2, h.z));
				Debug.Log(HousesPosition.Find(delegate(Vector3 v) { // /.
					return v== new Vector3 (h.x - hex_D / 2, h.y - (hex_D / Mathf.Sqrt (3)) / 2, h.z) ;
				}) == new Vector3 ());
			}

			if (HousesPosition.FindLast (delegate(Vector3 v) {
				return v == new Vector3 (h.x + hex_D / 2, h.y - (hex_D / Mathf.Sqrt (3)) / 2, h.z);
			}) == new Vector3 (0, 0, 0)) {
				HousesPosition.Add (new Vector3 (h.x + hex_D / 2, h.y - (hex_D / Mathf.Sqrt (3)) / 2, h.z));

			}
		}

		for (int i=0; i< HousesPosition.Count; i++) {
				Instantiate (house, HousesPosition [i], this.transform.rotation);
			}
	}

	void MakeRoad(Vector3 from,Vector3 to){
		r = (GameObject)Instantiate (road);
		r.transform.position = (  HousesPosition[3] +(HousesPosition[0]-HousesPosition[3])/2  );//to + (from-to)/2
		r.transform.rotation = Quaternion.FromToRotation(r.transform.position,HousesPosition[3]);
	}




	void getHexsPosition(){
		for (int i=0; i<=mapHeight/2; i++) {
			x = hex_D*i/2;
			y = Mathf.Sqrt(3)*hex_D*i/2;
			HexPosition.Add(new Vector3(x,y,z));
			if (i>0) {
				HexPosition.Add(new Vector3(x,0-y,z));
			}
			for(int j=1; j<=mapWight-i-1;j++){
				HexPosition.Add(new Vector3(x+hex_D*j,y,z));
			//Instantiate (hex,new Vector3(x*j,y,z), this.transform.rotation);
				if (i>0) {
				HexPosition.Add(new Vector3(x+hex_D*j,0-y,z));
				//Instantiate (hex,new Vector3(x*j,y,z), this.transform.rotation);
			}
			}
		}
	}

}
