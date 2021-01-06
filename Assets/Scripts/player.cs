using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int vida;
    public float speed;

    public Vector3 limitArea;
    public float maxPos;

    public GameObject laser;
    public float laserPos;
    public float laserSpeed;

    float time;
    public float timeOut;

    public AudioClip[] audios;
    AudioSource repro;

    public GameObject Explsion;
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        repro = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        limitArea.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        limitArea.x = Mathf.Clamp(limitArea.x, -maxPos, maxPos);
        transform.position = limitArea;

        time -= 1 * Time.deltaTime;
        if(Input.GetKey(KeyCode.Space))
        {
            if (time <= 0)
            {
                GameObject laser = Instantiate(this.laser, new Vector3(transform.position.x, laserPos, 0), transform.rotation);
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
                Destroy(laser, 2);
                time = timeOut;
                repro.clip = audios[0];
                repro.volume = 0.5f;
                repro.Play();
            }
        }

        if(vida <= 0)
        {
            text.SetActive(true);
            repro.clip = audios[2];
            repro.volume = 1;
            Instantiate(Explsion, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Asteroid")
        {
            repro.clip = audios[1];
            vida--;
            repro.Play();
        }
    }
}
