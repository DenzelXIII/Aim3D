using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject muzzle;
    [SerializeField]private float _rapidFireRate = 0.04f;
    [SerializeField]private float _burstFireRate = 0.05f;
    [SerializeField]private float _burstFireNumber = 10;

    private bool _canRapidFire = false;

    //fireMode 1 == single shot 2 == burstfire 3 == rapidfire
    private int _fireMode = 1;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _fireMode++;
            Debug.Log(_fireMode);
            if (_fireMode > 3)
            {
                _fireMode = 1;
            }
        }

        if (_fireMode == 1 && Input.GetButtonDown("Fire1"))
        {
            Ishoot();
        }

        if (_fireMode == 2 && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(BurstFire());
        }

        if (_fireMode == 3)
        {
            if(Input.GetMouseButtonDown(0))
            {
                _canRapidFire = true;
                StartCoroutine(RapidFire());
            }

            if (Input.GetMouseButtonUp(0))
            {
                _canRapidFire = false;
            }
        }
        
    }

    private void Ishoot()
    {
        Quaternion rotation = Quaternion.Euler(Vector3.up * muzzle.transform.rotation.eulerAngles.y);

        Instantiate(bulletPrefab, muzzle.transform.position, rotation);
    }

    IEnumerator BurstFire()
    {
        for (int i = 0; i < _burstFireNumber; i++)
        {
            Ishoot();
            yield return new WaitForSeconds(_burstFireRate);
        }
    }

    IEnumerator RapidFire()
    {
        while (_canRapidFire == true)
        {
            Ishoot();
            yield return new WaitForSeconds(_rapidFireRate);
        }
    }

}