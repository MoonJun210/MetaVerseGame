using System;
using UnityEngine;

public enum NPCType
{
    None = 0,
    Shop = 1,
    Inventory = 2,
}

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer[] characterRenderer;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    protected AnimationHandler animationHandler;
    protected StatController statController;

    private int characterNum = 0;
    public int CharNum { get { return characterNum; } }


    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statController = GetComponent<StatController>();

        characterNum = 0;

        for(int i = 0; i< characterRenderer.Length; i++)
        {
            characterRenderer[i].gameObject.SetActive(i == characterNum);
        }

        if(characterRenderer.Length == 1) // Npc는 스프라이트 변경할일없음
        {
            return;
        }
        EventManager.Instance.RegisterEvent<int>("ChangeSprite",ChangeSprite);
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection, characterNum);
    }

    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }

    private void Movment(Vector2 direction)
    {
        direction = direction * statController.Speed;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
        animationHandler.Move(direction, characterNum);

    }

    private void Rotate(Vector2 direction, int num)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer[num].flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }


    public void ChangeSprite(int newNum)
    {
        if (newNum < 0 || newNum >= characterRenderer.Length || newNum == characterNum)
        {
            return;
        }
        characterRenderer[characterNum].gameObject.SetActive(false);
        characterNum = newNum;
        characterRenderer[characterNum].gameObject.SetActive(true);

        Debug.Log("CharNum 변경! : " + CharNum);
    }

   
}
