using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class playerController : MonoBehaviour {

    public float velocidad;

    public Text scoreText;
    public Text wintext;
    public Button boton;
    public GameObject Pickup;


    //private int puntuacionMaxima;
    private int puntuacion;
    private bool controlable = true;
    




    // Use this for initialization
    void Start () {
        puntuacion = 0;
        //puntuacionMaxima = GameObject.FindGameObjectsWithTag("PickUp").Length;
        updateScore();
        this.boton.gameObject.SetActive(false);

    }
	
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y= Input.GetAxis("Vertical");
        if (controlable)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * velocidad);
        }
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            puntuacion++;
            updateScore();
        }
        else if (other.gameObject.tag == "RedPickUp")
        {
            other.gameObject.SetActive(false);
            controlable = false;
            gameOver();
        }
    }

    private void updateScore()
    {
        if (controlable)
        {
            this.scoreText.text = string.Format("Score :{0}", puntuacion * 10);
            Debug.Log("cuantos pickup: " + GameObject.FindGameObjectsWithTag("PickUp").Length);
            if (GameObject.FindGameObjectsWithTag("PickUp").Length == 0)
            {
                createPickUp();
            }
            //if (puntuacion >= puntuacionMaxima)
            //{
            //    wintext.text = "YOU WIN";
            //    this.boton.gameObject.SetActive(true);
            //}
        }
        

        
    }

    private void gameOver()
    {
        wintext.text = "GAME OVER";
        wintext.color = Color.red;
        this.boton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void createPickUp()
    {

        Vector2 vec = new Vector2(getPositionFarUfo("x"), getPositionFarUfo("y")); 
        GameObject newPickUp= (GameObject)Instantiate(Pickup, vec, transform.rotation);
    }
    /**
     * param name="axis" Es el eje que necesito buscar coordenada
     * 
     **/ 
    private float getPositionFarUfo(string axis)
    {
        float coordenate=0;
        float tempCoordenate=0;
        bool encontrado = false;
        float ufoPositionRadiusMax;
        float ufoPositionRadiusMin;
        int contador=0;
        if (axis.Equals("x") || axis.Equals("X")) {
            ufoPositionRadiusMax = this.transform.position.x + 2;
            ufoPositionRadiusMin = this.transform.position.x - 2;
        } else {
            ufoPositionRadiusMax = this.transform.position.y + 2;
            ufoPositionRadiusMin = this.transform.position.y - 2;
        }
        while (!encontrado || contador < 5) {
            tempCoordenate = Random.Range(-5, 6);
            if (tempCoordenate > ufoPositionRadiusMax || tempCoordenate < ufoPositionRadiusMin) {
                encontrado = true;
                coordenate = tempCoordenate;
                
            }

            contador++;
        }
        return tempCoordenate;
    }


}
