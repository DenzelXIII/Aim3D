using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject muzzle;
    public int joystickNum;
    [SerializeField]private float _rapidFireRate = 0.04f;
    [SerializeField]private float _burstFireRate = 0.05f;
    [SerializeField]private float _burstFireNumber = 10;


    private bool _canRapidFire = false;

    /*fireMode(s):
    1 == single shot 
    2 == burstfire 
    3 == rapidfire
     * 
     * Switch with TAB
    */

    private int _fireMode = 1;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string joystickString = joystickNum.ToString();
        if (Input.GetButtonDown("PS4R2_" + joystickString))
        {
            Ishoot();
        }
            

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _fireMode++;
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
        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity);

        Quaternion rotation = Quaternion.Euler(Vector3.up * muzzle.transform.rotation.eulerAngles.y);

        Instantiate(bulletPrefab, muzzle.transform.position, rotation);

        print("dsfsdfdsf");
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