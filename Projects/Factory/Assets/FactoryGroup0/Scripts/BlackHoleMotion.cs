using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleMotion : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rd;
    private Transform tf;
    [SerializeField]
    private float FloatStrenght =1;
    [SerializeField]
    private float LifeTime = 2.0f;
    private float timeCounter;
    void Start()
    {
        timeCounter = 0.0f;
        rd = this.gameObject.GetComponent<Rigidbody>();
        tf = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCounter <= LifeTime)
        {
            //does nothing
        }
        else
        {
            if (timeCounter >= 1.5f *LifeTime )
            {
                Destroy(this.gameObject);
            }
            else
            {
                var x = 2 / LifeTime * Time.deltaTime;
                tf.localScale -= new Vector3(x, x, x);
                //FloatStrenght -= x;
            }
        }
        rd.AddForce(-1 * Physics.gravity * FloatStrenght * Time.deltaTime,ForceMode.Impulse);
        timeCounter += Time.deltaTime;
    }
}
