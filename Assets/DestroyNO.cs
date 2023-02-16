using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNO : MonoBehaviour
{
    public GameObject MusicSliders;

    // Start is called before the first frame update
    void Start()
    {
       GameObject.DontDestroyOnLoad(MusicSliders);
                // void Obj.DDOL(Obj Tar)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
