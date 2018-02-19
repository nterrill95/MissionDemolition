using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {
    static public GameObject POI;

    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camz;

    private void Awake()
    {
        camz = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        if (POI == null) { return; }

        Vector3 destiantion = POI.transform.position;

        if(POI)

        destiantion.x = Mathf.Max(minXY.x, destiantion.x);
        destiantion.y = Mathf.Max(minXY.y, destiantion.y);

        destiantion = Vector3.Lerp(transform.position, destiantion, easing);
        destiantion.z = camz;
        transform.position = destiantion;

        Camera.main.orthographicSize = destiantion.y + 10;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
