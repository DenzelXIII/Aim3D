using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float maxLifeTime;
    private float lifeTime = 0f;
    [SerializeField]private GameObject explosionPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime;
        transform.Translate(Vector3.forward * speed * delta);
        lifeTime += delta;
        if (lifeTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        //Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);

    }
}
