using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tyler wrote this
public class DestroyAfterTime : MonoBehaviour
{
    public int lifetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("destroyObj", lifetime);
    }

    void destroyObj()
    {
        Destroy(this.gameObject);
    }
}
