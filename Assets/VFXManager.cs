using UnityEngine;

public class VFXManager : MonoBehaviour
 {

    public GameObject f;

    private void Start() {
        f.SetActive(false);
    }
    private void Update() {
        f.transform.position = transform.position;
    }
//     [SerializeField] private GameObject vfxObject;
//     [SerializeField] private GameObject targetObject;
//     [SerializeField] private Vector3 offset;

//     private GameObject gameObject1;
//     private GameObject gameObject2;

//     private Transform spawnPoint;
//     private Sequences s;
//     public float angle;

//     void OnEnable()
//     {
//         Sequences.OnEmittedVFX += OnEmittedVFX;
//         gameObject1 = Instantiate(vfxObject);
//         gameObject2 = Instantiate(vfxObject);
//         s = targetObject.GetComponent<Sequences>();


//     }

//     private void OnEmittedVFX(int id)
//     {
//         if (id == 0)
//         {
//             UpdatePosition();

//             VisualEffect vfx = gameObject1.GetComponent<VisualEffect>();
//             vfx.SendEvent("OnPlay");


//         }
//         if (id == 1)
//         {
//             UpdatePosition();

//             VisualEffect vfx = gameObject2.GetComponent<VisualEffect>();
//             vfx.SendEvent("OnPlay");

//         }
//     }

//     void UpdatePosition()
//     {
//         gameObject1.transform.position = s.getVFXSpawnPoint().position;
//         gameObject1.transform.rotation = s.getVFXSpawnPoint().rotation;
//         gameObject2.transform.position = s.getVFXSpawnPoint().position;
//         gameObject2.transform.rotation = s.getVFXSpawnPoint().rotation;
//     }



}
