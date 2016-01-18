using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float maxLifeTime;
    [SerializeField]private float _dmg = 1f;
    [SerializeField]private float lifeTime = 0f;

    public GameObject _explosionPrefab;
    protected Tags _tags;

    
    protected void Awake()
    {
        _tags = FindObjectOfType<Tags>();
    }
    

    void Start()
    {
       
    }

    // Update is called once per frame
    protected void Update()
    {
        float delta = Time.deltaTime;
        transform.Translate(Vector3.forward * speed * delta);
        lifeTime += delta;
        if (lifeTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _tags.enemyTag)
        {
            other.SendMessage("ApplyDamage", _dmg);
            Instantiate(_explosionPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
