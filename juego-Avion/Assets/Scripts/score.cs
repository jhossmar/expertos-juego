using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
	public GameObject player;
	public GameObject asteroide;

   public int numAsteroidesxMatarxNivel; 
   public Text txtScore;
   private int asteroidesDestruidos;
   private int record;
   private int nivel;
 
	void Start () {
	    int asteroidesDestruidos=0;
		this.record=0;
		nivel = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(asteroidesDestruidos==numAsteroidesxMatarxNivel)
		{
			nivel=nivel+1;
			asteroidesDestruidos=0;
			
			player.SendMessage("cambiarNivel",nivel);
			asteroide.SendMessage("aumentarVelosidad",nivel);

		}
	

	}

	public void incrementarScore(){
      this.record++;
	  asteroidesDestruidos++;

      txtScore.text= "SCORE: "+this.record;

	}


}
