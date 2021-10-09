using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

    [SerializeField] private bool rotateleft;
    [SerializeField] private PlanetValues values;
    //[Header("Move Values")]
    //[SerializeField] private bool willMove;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {


        transform.Rotate(0, 0, ((rotateleft)? values.rotationSpeed : -values.rotationSpeed) * Time.deltaTime);
       
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<RocketScript>().GotoInGravity(this.transform);
            //GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            Invoke("DisablePlanet", 3f);
    }

    private void DisablePlanet()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
