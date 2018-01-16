using System.Collections;
using UnityEngine;


public class PickUpRedController : MonoBehaviour {
    private float movX;
    private float movY;
    private Vector2 lastPosition;


	// Use this for initialization
	void Start () {
        //Random
        movX = getRandomDirection();
        movY = getRandomDirection();

        //Derecha
        //movX = -2;
        //movY = -2;

        
        Debug.Log("X: " + movX + " Y:"+ movY);
    }

    // Update is called once per frame
    //FixedUpdate o Update
    void Update() {
        //GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(movX, movY) * 3);
        GetComponent<Rigidbody2D>().velocity = new Vector2(movX, movY);
        Vector3 vector = this.transform.position;
        lastPosition = vector;
        this.transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);

    }





    void OnTriggerEnter2D(Collider2D other){

        if (other.gameObject.tag == "WallX"){
 
            Debug.Log("toca pared X");
            movY = movY * -1;

        }
        else if (other.gameObject.tag == "WallY"){
            Debug.Log("toca pared Y");
            movX = -movX * 1;
 
        }
        //Debug.Log("El nuevo modX es: " + movX);
        //Debug.Log("El nuevo modY es: " + movY);
        GetComponent<Rigidbody2D>().velocity = new Vector2(movX*400, movY*400);
        //movX = movX == 1 ? -1 : 1;
        //Debug.Log("toca pared");
        //other.isTrigger = false;
        // movY = -movY * 2;
    }

    private float getRandomDirection(){
        float random = 0;
        while (random == 0) {
            random = Random.Range(-1, 2);
        }
        
        return random *2;
    }

    
}
