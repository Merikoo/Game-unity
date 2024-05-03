using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Text hitCount;
    public int numHits = 0;
    public bool hasLost = false;
    private bool velocityWasStored = false;
    private Vector3 storedVelocity;
    private int bestScore = 0;
    private int lastBest = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tray")
        {
            Debug.Log("yes! hit tray!");

            if (!velocityWasStored)
            {
                storedVelocity = GetComponent<Rigidbody>().velocity;
                velocityWasStored = true;
            }

            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, storedVelocity.y, GetComponent<Rigidbody>().velocity.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        string str = "";

        if (!hasLost)
        {
            str = numHits.ToString();
        }
        else
        {
            str = "Hits: " + numHits.ToString() + "\nYour best: " + bestScore.ToString();

            if (bestScore > lastBest)
            {
                str += "\nNEW RECORD!";
            }
        }

        hitCount.text = str;
    }
}
