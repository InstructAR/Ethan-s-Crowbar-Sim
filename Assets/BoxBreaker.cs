using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreaker : MonoBehaviour
{
    public GameObject bug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Breaker")
        {
            Instantiate(bug, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
