using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    protected Shoot shootScript;

    public Image ammoBar;
    public Image healthBar;
    public Image soulBar;
    
    public float speed;
    public float jumpForce;
    protected Rigidbody _rb;

    protected bool _canJump;

    public float puzzlePiecesHeld = 0;
    public float puzzlePiecesOffset = 4;

    public int joystickNum;

    public float health;
    public float healthBarOffSet = 10;

    public float ammo;
    public float ammoOffSet = 30;

    protected Tags _tags;
    protected Animator _anim;
    private bool isReceivingDamage;



    void Awake()
    {
        _anim = GetComponent<Animator>();
        _tags = FindObjectOfType<Tags>();
        _rb = GetComponent<Rigidbody>();
    }

    protected void Movement()
    {

        string joyStickString = joystickNum.ToString();

        float h = Input.GetAxis("Vertical") * speed;
        Vector3 movementVector = new Vector3(0, 0, h) * Time.deltaTime;
        transform.Translate(movementVector);
    }

    protected void Jump()
    {
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);
        _rb.velocity = jumpVector;
    }

    protected void PuzzlePieceCollected(float _collected)
    {
        puzzlePiecesHeld += _collected;
    }

    void Damage(float damageReceived)
    {
        isReceivingDamage = true;
        StartCoroutine(HealthDecrease());
        print(health);
        if (health <= 0)
        {
            Application.LoadLevel(2);
        }
    }

    protected void PlayerUI()
    {
        
        healthBar.fillAmount = health / healthBarOffSet;
        ammoBar.fillAmount = ammo / ammoOffSet;
        soulBar.fillAmount = puzzlePiecesHeld / puzzlePiecesOffset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Puzzle")
        {
            other.SendMessage("DepositPuzzlePieces", puzzlePiecesHeld);
            puzzlePiecesHeld = 0;
        }
    }

    IEnumerator HealthDecrease()
    {
        while (isReceivingDamage)
        {
            health--;
            yield return new WaitForSeconds(0.25f);
        }

    }
}





