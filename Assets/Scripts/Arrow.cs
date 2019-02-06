using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    public float delay;
	void Start ()
    {
        //自动销毁
        Destroy(gameObject, delay);
	}
	
	void Update ()
    {
        //沿箭头移动
        transform.Translate(-transform.right * Time.deltaTime * 5f,Space.World);
	}
}
