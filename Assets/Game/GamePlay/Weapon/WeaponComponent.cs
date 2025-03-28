using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game.Skills;
using Unity.Mathematics;
using UnityEngine.Video;
public class WeaponComponent : MonoBehaviour
{

    private enum WeaponState
    {
        Attack,
        Idle,
        Targeting,
        Recurrence
    }

    [Header("Weapon Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float radiusMax;
    [SerializeField] private float radiusMin;
    [SerializeField] private float floatingSpeed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float targetingSpeed;
    [SerializeField] private float distanceToAttack = 0.1f;
    [SerializeField] private float returnSpeed = 5.0f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector3 directionReturn;

    private FieldOfViewComp playerView;

    public Transform thisTranform { get; private set; }
    private float Timer;
    private List<Transform> tarGetingTransform = new List<Transform>();
    private WeaponState currentState;

    private Transform defaultTransform;
    private Quaternion defaultQuaternion;
    private Skill currentSkill;
    private Vector3 faceDirection;
    private Quaternion rotation;
    private float rad = 0.0f;

    private float attackTimer = 0.0f;

    void Awake()
    {
        thisTranform = GetComponent<Transform>();
        defaultTransform = transform;
        defaultQuaternion = quaternion.identity;
        playerView = player.GetComponent<FieldOfViewComp>();
        currentState = WeaponState.Idle;
        directionReturn = new Vector3(radiusMax, 0, 0);

    }
    private void Update()
    {
        RoutingState();
        switch (currentState)
        {
            case WeaponState.Idle:
                OnStateIdle(directionReturn);
                break;
            case WeaponState.Targeting:
                OnStateTargeting();
                break;
            case WeaponState.Attack:
                OnStateAttack();
                break;
            case WeaponState.Recurrence:
                Recurrencing();
                break;
        }

        Debug.Log(currentState);
        // Debug.Log(directionReturn);
        // Debug.Log(rotation);

    }
    private void OnStateIdle(Vector3 direction)
    {
        Timer += Time.deltaTime * 5;
        rad = Timer % 360;
        // thisTranform.Rotate(Vector3.up * Time.deltaTime);
        rotation = Quaternion.Euler(0, rad * angularSpeed, 0);

        //thisTranform.position = Vector3.SmoothDamp(thisTranform.position, playerTransform.position +  rotation * directionReturn, ref velocity, 0.03f, floatingSpeed);
        thisTranform.position = playerTransform.position + rotation * directionReturn;
    }

    private void RoutingState()
    {
        tarGetingTransform = playerView.getDetectedTransforms();

        if (tarGetingTransform.Count() > 0)
        {

            //tarGetingTransform = tarGetingTransform.OrderBy(x => Vector3.Distance(thisTranform.position, x.position)).ToList();

            Vector3 target = tarGetingTransform.First().position;
            faceDirection = (target - transform.position).normalized;
            float distance = Vector3.Distance(thisTranform.position, target);
            if (distance > (distanceToAttack - 0.01f))
            {

                currentState = WeaponState.Targeting;
                LearpToTarget(target);
            }
            if (distance <= distanceToAttack + 0.01f)
            {
                currentState = WeaponState.Attack;
            }

        }


        if (tarGetingTransform.Count() == 0)
        {
            float distance = Vector3.Distance(thisTranform.position, playerTransform.position);
            if (distance > radiusMin - 0.3f && distance < radiusMax + 0.3f)
            {
                currentState = WeaponState.Idle;
            }

            else
            {
                currentState = WeaponState.Recurrence;
            }
        }

    }

    private void LearpToTarget(Vector3 target)
    {
        transform.position = Vector3.Lerp(thisTranform.position, target, targetingSpeed * Time.deltaTime);

    }

    private void Recurrencing()
    {
        //reset angle
        Timer = 0.0f;
        Vector3 dir = (transform.position - playerTransform.position).normalized;
        directionReturn = new Vector3(dir.x * radiusMax, 0.0f, dir.z * radiusMax);
        thisTranform.position = Vector3.SmoothDamp(thisTranform.position, playerTransform.position + directionReturn, ref velocity, 0.03f, returnSpeed);
        //thisTranform.position = Vector3.Lerp(thisTranform.position, playerTransform.position + directionReturn , Time.deltaTime * returnSpeed);
    }

    private void OnStateAttack()
    {
        transform.forward = faceDirection;
        if (currentSkill == null) return;
        if (Time.time > attackTimer)
        {
            currentSkill.PrefabPool.Dequeue().SetActive(true);
            currentSkill.OriginSkillSO.PerformAction(this, 1);
            attackTimer = Time.time + 0.1f;

        }



    }

    private void OnStateTargeting()
    {
        transform.forward = faceDirection;


    }

    public void setCurrentSkill(Skill skill)
    {
        this.currentSkill = skill;
    }

}


