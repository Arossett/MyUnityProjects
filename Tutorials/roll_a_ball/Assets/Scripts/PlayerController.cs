using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed ;
	private int count;
	public GUIText countText;
	public GUIText winText;

	// Use this for initialization
	void Start () {
		count = 0;
		setCountText();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//called just before performing any physics calculation
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive(false);
			count += 1;
			setCountText();
		}
	}

	void setCountText(){
		countText.text = "Count : " + count.ToString();
		if(count == 12){
			winText.text = "You win!";
		}
	}



}
