using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int vida;
    public float fallVel;

    public GameObject explosion;
    public AudioClip[] audio;
    AudioSource repro;
    // Start is called before the first frame update
    void Start()
    {
        repro = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, fallVel * Time.deltaTime, 0);
        if (vida <= 0)
        {
            GameObject x = Instantiate(explosion, transform.position, transform.rotation);
            x.GetComponent<AudioSource>().clip = audio[1];
            x.GetComponent<AudioSource>().Play();
            Destroy(x, 0.2f);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Laser")
        {
            Destroy(coll.gameObject);
            repro.clip = audio[0];
            if(transform.position.y < 5.05f)
            {
                vida--;
                repro.Play();
            }
        }

        if(coll.gameObject.tag == "Player")
        {
            vida = 0;
        }
    }
}
