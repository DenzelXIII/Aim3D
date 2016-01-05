using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float maxLifeTime;
    private float lifeTime = 0f;
    private float power;
    [SerializeField]private GameObject explosionPrefab;
    private Tags _tags;

    
    void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }

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
        if (coll.gameObject.tag == _tags.enemyTag)
        {
            coll.gameObject.SendMessage("TakeDamage", power);
        }
        Destroy(this.gameObject);

    }
}
