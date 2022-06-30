using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeauTest : MonoBehaviour
{
    public int length;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < length; i++)
        {
            if((i / 3) == Mathf.RoundToInt(i / 3))
            {
                Debug.Log("JeMamaGay");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
