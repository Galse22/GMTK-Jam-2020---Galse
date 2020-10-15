using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject soundPortalGO;

    public GameObject player;

    public bool hasCollided = false;

    public float timeNextArea = 1f;

    void Start()
    {
        player = this.gameObject;
    }

    void OnCollisionEnter2D (Collision2D collide)
    {
        if (collide.gameObject.CompareTag("Portal") && hasCollided == false)
        {
            Instantiate(soundPortalGO, player.transform.position, Quaternion.identity);
            hasCollided = true;
        }
    }
    void Update()
    {
        if(hasCollided == true)
      {
        if(timeNextArea > 0)
        {
            timeNextArea -= Time.deltaTime;
        }
        
        if(timeNextArea <= 0)
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        }
      }
    }
}
