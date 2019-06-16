using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{	

	public float shootingCooldown = 0.5f;
	private float shootingTimer;

	public GameObject bulletPrefab;


    void Update()
    {
		// Shooting cooldown
		shootingTimer -= Time.deltaTime;

		// Aiming Logic
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (shootingTimer <=0 && hit.transform.tag == "Target") {
				GameObject bulletObject = Instantiate (bulletPrefab);
				bulletObject.transform.position = transform.position;

				Bullet bullet = bulletObject.GetComponent<Bullet>();
				bullet.direction = transform.forward;

				shootingTimer = shootingCooldown;
			}
		}
    }
}
