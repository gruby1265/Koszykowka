using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    bool done;
    bool doUlt;

    public float timeBtw = 2f;
    float screenRange = 3f;

    // Start is called before the first frame update
    void Start()
    {
        done = true;
        doUlt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            done = false;
            StartCoroutine(SingleBall(timeBtw));
        }
        if (doUlt)
        {
            doUlt = false;
            int whichUlt = Random.Range(1, 6);
            switch (whichUlt)
            {
                case 1: //double
                    StartCoroutine(XStrike(timeBtw, 2, 0.3f));
                    break;
                case 2: //triple
                    StartCoroutine(XStrike(timeBtw, 3, 0.2f));
                    break;
                case 3: //quadro
                    StartCoroutine(XStrike(timeBtw, 4, 0.2f));
                    break;
                case 4: //double double
                    StartCoroutine(ManyXStrike(timeBtw, 2, 0.3f));
                    break;
                case 5: //double triple
                    StartCoroutine(ManyXStrike(timeBtw, 3, 0.2f));
                    break;
            }
            
        }
    }

    IEnumerator SingleBall(float time)
    {
        int numberOfSingles = Random.Range(1, 7);
        for (int i = 0; i < numberOfSingles; i++)
        {
            yield return new WaitForSeconds(time);
            Instantiate(ball, new Vector3(Random.Range(-screenRange, screenRange), 0f, 0f), Quaternion.identity);
        }
        doUlt = true;
    }

    IEnumerator XStrike(float time, int xStrike, float multi = 0.5f, float multiStartWait = 1f, bool isEnd = true)
    {
        yield return new WaitForSeconds(time * multiStartWait);
        float position = Random.Range(-screenRange, screenRange);
        for (int i = 0; i < xStrike - 1; i++)
        {
            Instantiate(ball, new Vector3(position, 0f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(time * multi);
        }
        Instantiate(ball, new Vector3(position, 0f, 0f), Quaternion.identity);

        if (isEnd) done = true;
    }

    IEnumerator ManyXStrike(float time, int xStrike, float multiBtwBall = 0.5f, float multiBtwDouble = 0.8f, int howMany = 2)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < howMany - 1; i++)
        {
            StartCoroutine(XStrike(time, xStrike, multiBtwBall, 0f, false));
            yield return new WaitForSeconds(time * multiBtwDouble);
        }
        StartCoroutine(XStrike(time, xStrike, multiBtwBall, 0f, false));

        done = true;
    }

    IEnumerator Trower()
    {
        while (true)
        {
            if (done)
            {
                done = false;
                
            }
        }
    }
}
