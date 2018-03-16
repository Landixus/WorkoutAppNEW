using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTriangles : MonoBehaviour
{
	public Vector3 v1;
	public Vector3 v2;
	public Vector3 v3;

	public Mesh mesh;

	void Start(){
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		mesh = GetComponent<MeshFilter>().mesh;

		mesh.Clear();

		// make changes to the Mesh by creating arrays which contain the new values

	}

	void Update(){
		mesh.vertices = new Vector3[] {v1,v2,v3};
		mesh.uv = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1)};
		mesh.triangles =  new int[] {0, 1, 2};
	}
}

