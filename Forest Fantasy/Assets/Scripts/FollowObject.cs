using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public Transform followee;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = followee.position + offset;
	}
}
