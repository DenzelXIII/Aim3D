using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject muzzle;
    public int joystickNum;
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
            Quaternion rotation = Quaternion.Euler(Vector3.up * muzzle.transform.rotation.eulerAngles.y);

            Instantiate(bulletPrefab, muzzle.transform.position, rotation);
        }
    }
}