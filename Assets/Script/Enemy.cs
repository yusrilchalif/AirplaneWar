using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float kecepatan;
    public Transform[] pelurunya;
    public peluruMusuh pel_musuh;

    void Start()
    {
        this.transform.Rotate(0, 0, 180);
        InvokeRepeating("LaunchProjectile", 2, 1.5F);
    }

    void Update()
    {
        this.transform.Translate(new Vector2(0, 3) * Time.deltaTime);
        if(this.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
    void LaunchProjectile()
    {
        foreach(Transform tembakan in pelurunya)
        {
            Instantiate(pel_musuh, tembakan.position, tembakan.rotation);
        }
        if(this.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
}
