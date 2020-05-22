using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;
    public float startForceUp = 10f;
    public float startForceFoward = 10f;
    public float autodestructionTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, startForceUp, -startForceFoward, ForceMode.Impulse);
        StartCoroutine(Suicide(autodestructionTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Suicide(float OmaeWaMouShindeiru)
    {
        yield return new WaitForSeconds(OmaeWaMouShindeiru);
        Destroy(gameObject);
    }
}
