using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEffectScript : MonoBehaviour
{
    public GameObject HitEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHit()
    {
        GameObject.Instantiate(HitEffect, this.transform.position, Quaternion.identity);
        GameObject.Destroy(this.gameObject);
    }
}
