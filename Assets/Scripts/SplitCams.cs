using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitCams : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Player1;
    public GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera1.transform.position = new Vector3(0, 0, Player1.transform.position.y);
        Camera2.transform.position = new Vector3(0, 0, Player2.transform.position.y);
    }
}
