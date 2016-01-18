using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
    public int joystickNum;
    [SerializeField]private GameObject _bulletPrefab;
    [SerializeField]private GameObject _muzzle;

    private float _rapidFireRate = 0.08f;
    private float _burstFireRate = 0.08f;
    private float _burstFireNumber = 3;
    [SerializeField]private float _rechargeDelay = 0.25f;
    [SerializeField]private float _ammo = 30;

    private AudioSource _shotSound;

    private bool _canRapidFire = false;
    private bool _isRecharging = false;

    private int _fireMode = 1;
    
    

    

    
    
    // Use this for initialization
    void Start()
    {
        _shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*string joystickString = joystickNum.ToString();
        if (Input.GetButtonDown("PS4R2_" + joystickString))
        {
            Ishoot();
        }
        */
        ShootingMode();

        CheckForRecharge();
    }

    /*changes shootingmode:
    shootingmodes:
    * 1 == single shot 
    * 2 == burstfire 
    * 3 == rapidfire
    * 
    * Switch with TAB
    */
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

    //check if can recharge weapon/weapon is recharging
    private void CheckForRecharge()
    {
        if (_ammo <= 0)
        {
            StartCoroutine(BulletRecharge());
            _isRecharging = true;
        }

        if (_ammo == 30)
        {
            _isRecharging = false;
        }
    }
    //shoot function
    private void Ishoot()
    {
        if (_ammo > 0 && _isRecharging == false)
        {
            Quaternion rotation = Quaternion.Euler(Vector3.up * _muzzle.transform.rotation.eulerAngles.y);
            Instantiate(_bulletPrefab, _muzzle.transform.position, rotation);
            _shotSound.Stop();
            _shotSound.Play();
            ChangeAmmo(-1);
        }
    }

    public void ChangeAmmo(float AmmoChange)
    {
        _ammo += AmmoChange;
    }

    public float GetAmmo()
    {
        return _ammo;
    }

    //burst fire delay
    IEnumerator BulletRecharge()
    {
        while (_isRecharging == true && _ammo < 30)
        {
            ChangeAmmo(1);
            yield return new WaitForSeconds(_rechargeDelay);
        }
    }

    IEnumerator BurstFire()
    {
        for (int i = 0; i < _burstFireNumber; i++)
        {
            Ishoot();
            yield return new WaitForSeconds(_burstFireRate);
        }
    }

    //rapid fire rate
    IEnumerator RapidFire()
    {
        while (_canRapidFire == true)
        {
            Ishoot();
            yield return new WaitForSeconds(_rapidFireRate);
        }
    }

}