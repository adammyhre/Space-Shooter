using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
	public int health = 3;
	public float rotatingSpeed = 15f;


    void Start()
    {
        
    }

    void Update()
    {
		transform.localEulerAngles = new Vector3(
			0,
			transform.localEulerAngles.y + rotatingSpeed * Time.deltaTime,
			0);
        
    }

	void OnTriggerEnter(Collider collider){
		if (collider.GetComponent<Bullet> () != null) {
			health--;
			Destroy (collider.gameObject);
			if (health == 0)
				Destroy (gameObject);
		}
		else if (collider.GetComponent<Player> () != null)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
	}
}
