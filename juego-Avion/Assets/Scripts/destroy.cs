using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
    public GameObject explocion;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otrer){
		 if(otrer.name == "hit"){
            return;
          

		 }
	   
          
       if(otrer.gameObject.tag == "asteroide"){
        Instantiate (explocion, transform.position, transform.rotation);
	     
	   }
	   if(otrer.gameObject.tag != "Player"){
	      Destroy(gameObject);
          Destroy(otrer.gameObject);
        }

	}

	
}
