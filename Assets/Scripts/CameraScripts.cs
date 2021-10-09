using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour {

    public Transform target;

    public float followSpeed;
    public float offset;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (target)
        {
            if (GameManager.Instance.gameState == GameManager.GameState.running)
            {       float yPos = transform.position.y;
                yPos = Mathf.Lerp(yPos, target.position.y, followSpeed);

                transform.position = new Vector3(transform.position.x, yPos + offset, transform.position.z);
            }
        }
	}
}
