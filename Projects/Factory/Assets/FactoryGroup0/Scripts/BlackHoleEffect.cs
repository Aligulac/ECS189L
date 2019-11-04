using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleEffect : MonoBehaviour
{
    public float pullForce = 1000;
    private GameObject[] MeteorCollection;
    private GameObject[] FireBallCollection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MeteorCollection = GameObject.FindGameObjectsWithTag("Meteor");
        GravityFunction(gameObject, MeteorCollection);
    }
    //GravityFunction: pull things toward captain
    private void GravityFunction(GameObject gameObject, GameObject[] list)
    {
        foreach (GameObject i in list)
        {
            var rigidBody = i.GetComponent<Rigidbody>();
            var disVector = gameObject.transform.position - i.transform.position;
            float dis = Mathf.Sqrt(Mathf.Pow(disVector.x, 2) + (Mathf.Pow(disVector.y, 2))+ (Mathf.Pow(disVector.z, 2)));
            if (dis <= 1) //if too close, destory meteor
            {
                Destroy(i);
                continue;
            }
            //Simplified gravity formula
            Vector3 attractForce = new Vector3(disVector.normalized.x * pullForce / (Mathf.Pow(dis, 2)), 
                disVector.normalized.y * pullForce / (Mathf.Pow(dis, 2)),
                disVector.normalized.z * pullForce / (Mathf.Pow(dis, 2)));
            Vector3 attractForce2 = new Vector3(disVector.normalized.x * pullForce / dis,
                disVector.normalized.y * pullForce /dis,
                disVector.normalized.z * pullForce /dis);
           // Debug.Log("Force: " + attractForce);
            rigidBody.AddForce(attractForce, ForceMode.Impulse);
        }
    }
}
