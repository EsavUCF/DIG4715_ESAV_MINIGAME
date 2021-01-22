using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {
	 private bool gameEnded = false;
	private bool isGameStarted = false;
	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	public Text countText;
	public Text winText;
	public Text loseText;
	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;
	private int count; 
	public int minScore = 0;
    public int maxScore = 2; 
	bool gameOver;
	public AudioClip winSound;
    public AudioClip LoseSound;
	public float timeLeft =10.0f;
	
	public Text timerText;

public AudioSource musicSource;
	AudioSource audioSource;
 
	//bool dashAxis = false;
	
	// Update is called once per frame
	
	 void Start()
	 {
		count = 0;
	 	countText.text = "Count: " + count.ToString();
	 
	 
	 {audioSource= GetComponent<AudioSource>();
	 
	 
	 }
	 
	 






	 
	 }
	
	
	
	
	void Update () {


if (Input.GetKey("escape"))
{
Application.Quit();
}


		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			dash = true;
		}






if (timeLeft <0) 
{
	Destroy(gameObject, 5);
	loseText.text = "You Lose! Game made by Eric Savage";   
			 gameEnded = true;
	audioSource.PlayOneShot(LoseSound);
}






		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/


	timeLeft -=Time.deltaTime;
timerText.text = (timeLeft).ToString("0");
if (timeLeft <0)
 	
{

}
	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}

	
 private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
        
			count = count + 1;
			countText.text = "GO!";
		}

if (count >=2)
{

	Destroy(gameObject, 1);
	winText.text = "You win! Game made by Eric Savage";  
 		   audioSource.PlayOneShot(winSound);      

}

}







}