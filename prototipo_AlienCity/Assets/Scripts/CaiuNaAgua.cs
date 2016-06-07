using UnityEngine;
using System.Collections;

public class CaiuNaAgua : MonoBehaviour {

	// Use this for initialization
	private gameController GC;
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GC = gameControllerObject.GetComponent <gameController>();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.CompareTag("Player"))
		{
//			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

			GC.GameOver();
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}






}
