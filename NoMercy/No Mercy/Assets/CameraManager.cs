using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	//public GameObject player;
	public Transform player;
	public Transform player2;
	Vector3 cameraPos;
	float x1,x2,y1,y2,distance;
	// Use this for initialization
	void Start () {
		cameraPos = new Vector3 (0f, 0f);
		//cameraPos = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
		/*if((transform.localPosition.x + 5f) <= player.localPosition.x)
		{
			cameraPos.x = player.localPosition.x-5;

		}
		if((transform.localPosition.x - 5f) >= player.localPosition.x)
		{
			cameraPos.x = player.localPosition.x+5;
		}

		if((transform.localPosition.y + 5f) <= player.localPosition.y)
		{
			cameraPos.y = player.localPosition.y-5;
			
		}
		if((transform.localPosition.y - 5f) >= player.localPosition.y)
		{
			cameraPos.y = player.localPosition.y+5;
		}*/
		x1 = player.localPosition.x;
		x2 = player2.localPosition.x;
		y1 = player.localPosition.y;
		y2 = player2.localPosition.y;
		distance = (float)Mathf.Sqrt (((y2 - y1) * (y2 - y1)) + ((x2 - x1) * (x2 - x1)));
		cameraPos = (player.localPosition + player2.localPosition)/2.0f;
		cameraPos.z = -15f;
		transform.localPosition = cameraPos;
		if(distance > 5 && distance < 8)
			transform.camera.orthographicSize = distance;



 	}
}
