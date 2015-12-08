using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject muzzle;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Quaternion rotation = Quaternion.Euler(Vector3.up * muzzle.transform.rotation.eulerAngles.y);

            Instantiate(bulletPrefab, muzzle.transform.position, rotation);
        }
    }
}