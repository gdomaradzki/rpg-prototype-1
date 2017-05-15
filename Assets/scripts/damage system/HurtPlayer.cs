using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player") {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
        }
    }
}
