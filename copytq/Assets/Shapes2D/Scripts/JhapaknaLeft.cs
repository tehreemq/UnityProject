using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhapaknaLeft : MonoBehaviour
{
    public GameObject blinkObject;
    public float timeBetweenBlinks = 2f;
    private float initialStoredTime;

    // Start is called before the first frame update
    void Start()
    {
        if (blinkObject == null)
            Debug.LogError("Please Assign the game object");
        if (blinkObject != null)
            blinkObject.SetActive(false);
        initialStoredTime = timeBetweenBlinks;

    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenBlinks -= Time.deltaTime;
        if (timeBetweenBlinks <= 0f)
        {
            if (blinkObject != null)
                blinkObject.SetActive(true);

            StartCoroutine("ResetBlink");
        }

    }
    IEnumerator ResetBlink()

    {
        yield return new WaitForSeconds(.5f);
        if (blinkObject != null)
            blinkObject.SetActive(false);


        timeBetweenBlinks = initialStoredTime - (Random.Range(-1f,1f));
    }
}


