using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Assertions.Must;
using UnityEngine.PlayerLoop;

public class FieldOfViewComp : MonoBehaviour
{
    public enum EnityType
    {
        Player,
        Enemy
    }

    [SerializeField] private float detectedRadius;
    [Range(0, 360)]
    [SerializeField] private float detectedAngle;
    [SerializeField] private LayerMask obstaclesMask;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private float delayDetect = 0.1f;
    [SerializeField] private EnityType hostType;


    private List<Transform> detectedTargets = new List<Transform>();
    private List<Vector3> dummyList = new List<Vector3>();


    public bool canSee => canSee;


    private Transform hostTransform;
    void Awake()
    {
        hostTransform = GetComponent<Transform>();
        StartCoroutine(FOVRouting());
    }

    private IEnumerator FOVRouting()
    {
        WaitForSeconds wait = new WaitForSeconds(delayDetect);
        while (true)
        {
            yield return wait;
            FieldCheck();
        }
    }

    private void FieldCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(hostTransform.position, detectedRadius, targetMask);
        if (colliders == null || colliders.Length == 0)
        {
            detectedTargets.Clear();
            return;
        }
        foreach (Collider c in colliders)
        {

            Vector3 direction = (c.transform.position - hostTransform.position).normalized;
            if (Vector3.Angle(hostTransform.forward, direction) < detectedAngle / 2)
            {

                float distanceToTarget = Vector3.Distance(hostTransform.position, c.transform.position);
                if (!Physics.Raycast(hostTransform.position, direction, distanceToTarget, obstaclesMask))
                {
                    if (!detectedTargets.Contains(c.transform))
                    {
                        detectedTargets.Add(c.transform);
                    }
                }
                else
                {
                    detectedTargets.Remove(c.transform);

                }


            }
            else
            {
                detectedTargets.Remove(c.transform);
            }
        }

    }

    public List<Transform> getDetectedTransforms()
    {

        return detectedTargets.OrderBy(x => Vector3.Distance(hostTransform.position, x.position)).ToList();

    }


    public float getRadius()
    {
        return detectedRadius;
    }

    public float getDetectedAngle()
    {
        return detectedAngle;
    }
}
