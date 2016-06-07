using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[HideInInspector] public bool viradoDireita = true; 
	public GameObject player;
	
	private Animator animator; 

	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	private Rigidbody2D rb2d;
	[HideInInspector] public bool grounded = false;
	private gameController GC;



	public float speed;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();


	}
	
	void Update() {
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		if ((Input.GetKeyDown("space"))&& grounded) {
			jump = true;
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate()
	{
		float translationY = 0;
		float translationX = Input.GetAxis("Horizontal") * speed;
		player.transform.Translate(translationX,translationY,0);
		if (translationX!=0 && grounded){
			animator.SetTrigger ("Corre");
		}
		else
		{
			animator.SetTrigger ("Parado");
		}

		if (jump)
		{
			animator.SetTrigger("Pula");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
		if(translationX>0 && !viradoDireita) //pressionou tecla p direita e nao esta movendo a direita
		{
			Flip(); //troca a direção
		}
		else if (translationX < 0 && viradoDireita)
			Flip ();
	}
	
	void Flip()
	{
		viradoDireita = !viradoDireita; // inverte a variavel
		Vector3 theScale = transform.localScale; //theScale recebe as informacoes de escala do personagem
		theScale.x *= -1; // inverte o lado
		transform.localScale = theScale; //atribui ao personagem
	}			 
	
}
