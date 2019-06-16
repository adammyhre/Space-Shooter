using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 2.5f;
	public Camera camera;


	void Update()
    {
		// Movement Logic
		transform.position += camera.transform.forward * speed * Time.deltaTime;;

    }
}
