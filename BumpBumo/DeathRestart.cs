using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathRestart : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;

    public int rounds = 3;
	
	private Rigidbody rb1;
	private Rigidbody rb2;
	
	public Text scoreTextComponentP1;
	public Text scoreTextComponentP2;
	public Text roundNumberText;
	private int point1;
	private int point2;
	private int round = 1;
	
	[SerializeField] private float freezeDelay = 2f;
	
	
	void Start()
    {	
		scoreTextComponentP1.color = Color.red;
		scoreTextComponentP2.color = Color.blue;
		scoreTextComponentP1.text = point1.ToString();
		scoreTextComponentP2.text = point2.ToString();
		rb1 = player1.GetComponent<Rigidbody>();
		rb2 = player2.GetComponent<Rigidbody>();
    }
	
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
			round++;
			point2++;
			roundNumberText.color = Color.blue;
			updateScore();
			rb1.drag = 1;
			rb2.drag = 1;
            player1.GetComponent<MovementA>().start = false;
            player2.GetComponent<MovementZ>().start = false;
            player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player1.transform.rotation = spawnPoint1.transform.rotation;
            player2.transform.rotation = spawnPoint2.transform.rotation;
            player1.transform.position = spawnPoint1.transform.position;
            player2.transform.position = spawnPoint2.transform.position;
			StartCoroutine(Freeze());
			
        }
		
		if (other.tag == "Player2")
        {
			round++;
			point1++;
			roundNumberText.color = Color.red;
			updateScore();
			rb1.drag = 1;
			rb2.drag = 1;
            player1.GetComponent<MovementA>().start = false;
            player2.GetComponent<MovementZ>().start = false;
            player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player1.transform.rotation = spawnPoint1.transform.rotation;
            player2.transform.rotation = spawnPoint2.transform.rotation;
            player1.transform.position = spawnPoint1.transform.position;
            player2.transform.position = spawnPoint2.transform.position;
			StartCoroutine(Freeze());
			
        }
    }
	
	
	private void updateScore()
	{
		scoreTextComponentP1.text = point1.ToString();
		scoreTextComponentP2.text = point2.ToString();
		roundNumberText.text = "Round " + round.ToString();
		roundNumberText.enabled = true;
	}
	
	void Update()
	{
		if(point1 >= rounds)
		{
    		SceneManager.LoadScene("P1Win");
			round = 1;
		}
		if(point2 >= rounds)
		{
			SceneManager.LoadScene("P2Win");
			round = 1;
		}
	}
	
	IEnumerator Freeze()
	{
		rb1.constraints = RigidbodyConstraints.FreezePosition;
		rb2.constraints = RigidbodyConstraints.FreezePosition;
		yield return new WaitForSeconds(freezeDelay);
		roundNumberText.enabled = false;
		rb1.constraints = ~RigidbodyConstraints.FreezePosition;
		rb2.constraints = ~RigidbodyConstraints.FreezePosition;
	}
	
}
