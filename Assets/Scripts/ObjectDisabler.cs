using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour {

    public float disableWait;

    private void OnEnable()
    {
        Invoke("DisableObject", disableWait);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
