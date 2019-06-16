using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject asteroidPrefab;
	public int asteroidAmount = 10;
	public float spawnDistance = 20f;
	public Player player;
	public TextMesh infoText;

	private float gameTimer;
	private float gameOverTimer = 3f;

    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < asteroidAmount; i++) {
			GameObject asteroidObject = Instantiate (asteroidPrefab);
			asteroidObject.transform.SetParent (transform);
			float randomAngle = Random.Range (0, 2 * Mathf.PI);
			float randomHeightAngle = Random.Range (0, 2 * Mathf.PI);

			asteroidObject.transform.position = new Vector3 (
				Mathf.Cos(randomAngle) * spawnDistance,
				Mathf.Cos(randomHeightAngle) * spawnDistance,
				Mathf.Sin(randomAngle) * spawnDistance);

		}
    }

    // Update is called once per frame
    void Update()
    {
		int remainingAsteroids = transform.GetComponentsInChildren<Target> ().Length;
		bool isGameOver = (remainingAsteroids == 0);
		if (!isGameOver) {
			gameTimer += Time.deltaTime;
			infoText.text = "Timer: " + Mathf.Floor (gameTimer);

		} else {
			infoText.text = "You won!\nYour time: " + Mathf.Floor (gameTimer);
			gameOverTimer -= Time.deltaTime;
			if (gameOverTimer <= 0f) 
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
    }
}
