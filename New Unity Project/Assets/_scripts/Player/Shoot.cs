using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
<<<<<<< HEAD:New Unity Project/Assets/_scripts/Player/Shoot.cs
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject muzzle;
    public int joystickNum;
=======
    [SerializeField]private GameObject _bulletPrefab;
    [SerializeField]private GameObject _muzzle;
>>>>>>> 77fee1a96227e703ee215ad388224eb79218d06c:New Unity Project/Assets/_scripts/Shoot.cs
    [SerializeField]private float _rapidFireRate = 0.04f;
    [SerializeField]private float _burstFireRate = 0.05f;
    [SerializeField]private float _burstFireNumber = 4;

    private Material _mat;
    private bool _canRapidFire = false;
    private int _fireMode = 1;

    /*
     * fireMode(s):
    1 == single shot 
    2 == burstfire 
    3 == rapidfire
     * 
     * Switch with TAB
    */

    
    
    // Use this for initialization
    void Start()
    {
        _mat = _bulletPrefab.GetComponent<MeshRenderer>().sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD:New Unity Project/Assets/_scripts/Player/Shoot.cs
        string joystickString = joystickNum.ToString();
        if (Input.GetButtonDown("PS4R2_" + joystickString))
        {
            Ishoot();
        }
            
=======
        BulletType();

        ShootingMode();
    }

    private void BulletType()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _bulletPrefab.tag = "FireBullet";
            Debug.Log(_bulletPrefab.tag);
            _mat.SetColor("_Color", Color.red);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _bulletPrefab.tag = "WaterBullet";
            Debug.Log(_bulletPrefab.tag);
            _mat.SetColor("_Color", Color.blue);
        }
    }
>>>>>>> 77fee1a96227e703ee215ad388224eb79218d06c:New Unity Project/Assets/_scripts/Shoot.cs

    private void ShootingMode()
    {
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
            if (Input.GetMouseButtonDown(0))
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

        Quaternion rotation = Quaternion.Euler(Vector3.up * _muzzle.transform.rotation.eulerAngles.y);

<<<<<<< HEAD:New Unity Project/Assets/_scripts/Player/Shoot.cs
        Instantiate(bulletPrefab, muzzle.transform.position, rotation);

        print("dsfsdfdsf");
=======
        Instantiate(_bulletPrefab, _muzzle.transform.position, rotation);
>>>>>>> 77fee1a96227e703ee215ad388224eb79218d06c:New Unity Project/Assets/_scripts/Shoot.cs
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