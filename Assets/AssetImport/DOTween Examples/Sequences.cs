using UnityEngine;

using Game.Skills;
using System.Collections.Generic;
using UnityEngine.VFX;
using System;
using DG.Tweening;

public class Sequences : MonoBehaviour
{

    public Transform spawnPoint;

    public PlayerSkillsListSO list;
    public Skill currentSkill = new Skill();

    private List<Skill> currentSkillList = new List<Skill>();
    private Dictionary<ScriptableObject, object> createdInstance = new Dictionary<ScriptableObject, object>();

    private Transform thisTransform;
    Vector3 vec;
    Vector3 vec1;
    private void Awake()
    {
        thisTransform = gameObject.GetComponent<Transform>();
    }
    // void OnEnable()
    // {
    //    Initialization();
    // }


    private void Initialization()
    {
        foreach (BasicSkillSO skillSO in list.skillList)
        {
            InitSkill(skillSO);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            vec = transform.forward;
            vec1 = transform.eulerAngles;
            Debug.Log("CurrentVEC" + vec);
             Debug.Log("Current euluer" + vec1);
            Sequence s = DOTween.Sequence();
            Tween t1 = transform.DORotate(vec + new Vector3(0, 0, 45), 2f, RotateMode.LocalAxisAdd).SetRelative();
            Tween t2 = transform.DORotate(vec + new Vector3(180, 0, 0), 2f, RotateMode.LocalAxisAdd).SetRelative();
            Tween t3 = transform.DORotate(vec1, 2f, RotateMode.Fast);
            s.Append(t1);
            s.Append(t2);
            s.Append(t3);
        }
       
    }

    private void Test()
    {

        //Tween t1 = transform.DORotate();
    }
    private void InitSkill(BasicSkillSO skillSO)
    {
        Skill skill = skillSO.CreateOrGetSkill(createdInstance);
        GameObject[] neededPrefabs = skillSO.getNeededPrefabs();
        if (neededPrefabs.IsNullOrEmpty())
        {
            return;
        }


        foreach (GameObject prefab in neededPrefabs)
        {
            for (int i = 0; i < skillSO.poolSize; i++)
            {
                GameObject go = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
                BaseSkillObjectPrefab skillObjectPrefab = go.GetComponent<BaseSkillObjectPrefab>();
                skillObjectPrefab.PrefabPool = skill.PrefabPool;
                go.SetActive(false);
                skill.PrefabPool.Enqueue(go);
            }

        }

        currentSkillList.Add(skill);

    }




}
