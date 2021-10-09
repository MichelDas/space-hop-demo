using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    [SerializeField] public GameObject backFire;
    
    public float speed;
    public Transform planet;
    public float turnSpeed;

    public enum RocketState
    {
        Idle,
        Moving,
        InGravity
    }

    public RocketState rocketState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        switch(rocketState)
        {
            case RocketState.Idle:
                break;

            case RocketState.Moving:
                Move();
                break;
            case RocketState.InGravity:
                GoToPlanet();
                break;
        }
        
	}

    public void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private Vector3 dir;
    private float dr;
    public void GoToPlanet()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (planet != null)
        {
            dir = planet.transform.position - transform.position;
            dr = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(dr, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        }

        if(Vector3.Distance(this.transform.position, planet.position) < .1f)
        {
            GameManager.Instance.showReachEffect(planet.position);
            GoToIdle();
        }
    }

    public void GotoInGravity(Transform planet)
    {
        rocketState = RocketState.InGravity;
        this.planet = planet;
    }

    public void GoToIdle()
    {
        SpawnPlanet();
        Debug.Log("is this coming here");
        rocketState = RocketState.Idle;
        transform.SetParent(planet);
        backFire.SetActive(false);
        GameManager.Instance.getInput = true;
       
    }

    public void GoToMove()
    {
        transform.SetParent(null);
        rocketState = RocketState.Moving;
        
        backFire.SetActive(true);
    }


    private void SpawnPlanet()
    {
        GameObject planet = GameManager.Instance.GetPlanet();
        planet.SetActive(true);
        
        planet.transform.position = new Vector3(planet.transform.position.x, transform.position.y+ Random.Range(5.5f, 7), planet.transform.position.z);
    }

}
