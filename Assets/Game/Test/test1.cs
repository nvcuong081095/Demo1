using UnityEngine;
using UnityEngine.VFX;

public class test1 : BaseSkillObjectPrefab


{

    [SerializeField] private GameObject gameObject;
    void Awake()
    {
        visualEffect = gameObject.GetComponent<VisualEffect>();
        thisTransform = GetComponent<Transform>();
    }
    void OnEnable()
    {
        skillSO.OnVFXStarted += OnVFXStarted;
        skillSO.OnSkillEnded += OnSkillEnded;
        skillSO.OnSkillstarted += OnSkillStarted;
    }


    private void OnVFXStarted(object[] args)
    {
        thisTransform.rotation = Quaternion.Euler(new Vector3(0, 0, (float)args[0]));
        visualEffect.SendEvent("OnPlay");

    }

    void OnDisable()
    {
        skillSO.OnVFXStarted -= OnVFXStarted;
        skillSO.OnSkillEnded -= OnSkillEnded;
    }

    private void OnSkillEnded(object[] args)
    {
        OnObjectInActive();
    }

    protected override void OnObjectInActive()
    {
        this.PrefabPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
    private void OnSkillStarted(object[] args)
    {
        thisTransform.position = (Vector3)args[0];
        thisTransform.forward = (Vector3)args[1];
    }    
}
