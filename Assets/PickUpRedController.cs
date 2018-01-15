using UnityEngine;
using System.Collections;


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
        //movX = 1;
        //movY = 1;

        
        Debug.Log("X: " + movX + " Y:"+ movY);
    }

    // Update is called once per frame
    //FixedUpdate o Update
    void FixedUpdate() {
        //GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(movX, movY) * 3);
        GetComponent<Rigidbody2D>().velocity = new Vector2(movX, movY);
        Vector3 vector = this.transform.position;
        lastPosition = vector;
        this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

    }





    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "WallX")
        {
 
            Debug.Log("toca pared X");
            Debug.Log(this.GetComponent<Rigidbody2D>().GetRelativeVector(lastPosition));
            movY = movY * -1;

        }
        else if (other.gameObject.tag == "WallY")
        {
            Debug.Log("toca pared Y");
            Debug.Log(this.GetComponent<Rigidbody2D>().GetRelativeVector(lastPosition));
            movX = -movX * 1;
 
        }
        Debug.Log("El nuevo modX es: " + movX);
        Debug.Log("El nuevo modY es: " + movY);
        //movX = movX == 1 ? -1 : 1;
        //Debug.Log("toca pared");
        //other.isTrigger = false;
        // movY = -movY * 2;
    }

    private float getRandomDirection(){

        return Random.Range(-1, 1);
    }

    
}
