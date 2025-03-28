using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TestCube : MonoBehaviour
{


    public Transform target;
    public float time;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           testAttack();
        }
    }

  

    private IEnumerator AttackCountTime(int times, float delay)
    {
        while (times > 0)
        {

            times--;
            yield return new WaitForSeconds(delay);


        }
        yield return null;
    }

    private void testAttack(){
        transform.DOMove(target.position, time).SetEase(Ease.Linear);
        DOTween.Play(transform);
    }

}
