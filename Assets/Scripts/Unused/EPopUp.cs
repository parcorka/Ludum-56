//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EPopUp : MonoBehaviour
//{
//    [SerializeField]
//    private Camera mainCamera;
//    public Transform eSprite;
//    private Collider collider;

//    // Start is called before the first frame update
//    private void Awake()
//    {
//        collider = GetComponent<Collider>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        transform.GetChild(0).gameObject.SetActive(true);
//    }
//    private void OnTriggerExit(Collider other)
//    {
//        transform.GetChild(0).gameObject.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//    private void LateUpdate()
//    {
//        Vector3 cameraPosition = mainCamera.transform.position;
//        //cameraPosition.y = transform.position.y;
//        transform.LookAt(cameraPosition);
//        transform.Rotate(0f, 180f, 0f); // sprites render like that in 3d
//    }
//}
