using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float destructionLeftTime;

    public ParticleSystem particles;

    private GameObject thisGameObject;

    void Start()
    {
        thisGameObject = this.gameObject;
        Destroy(gameObject, destructionLeftTime);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if(destructionLeftTime > 0.05f)
        {
            destructionLeftTime -= Time.deltaTime;
        }
        else 
        {
            Instantiate(particles, thisGameObject.transform.position, Quaternion.identity);
        }
    }
}
