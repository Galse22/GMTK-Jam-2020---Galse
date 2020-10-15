using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private bool alreadyDied = false;

    public GameObject player;

    public float timeDeath;

    public ParticleSystem particles;

    public GameObject explosionGO;

    private SpriteRenderer sr;

    private BoxCollider2D bc;

    private Movement1 walkScript;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        bc = GetComponent<BoxCollider2D>();

        walkScript = GetComponent<Movement1>();
    }

    void OnCollisionEnter2D (Collision2D collide)
    {
        if (collide.gameObject.CompareTag("Dead"))
        {
            Instantiate(particles, player.transform.position, Quaternion.identity);

            Instantiate(explosionGO, player.transform.position, Quaternion.identity);

            CinemachineShake.Instance.ShakeCamera(30f, .1f);

            alreadyDied = true;
        }
    }

    void Update()
    {
        if(alreadyDied == true)
        {
            timeDeath -= Time.deltaTime;
            sr.enabled = false;
            bc.enabled = false;
            walkScript.enabled = false;
        }

        if(timeDeath <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
