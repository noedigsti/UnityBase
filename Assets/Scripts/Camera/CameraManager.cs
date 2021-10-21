using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [Header("Component References")]
    public Camera GameCam;
    public Camera UICam;
    [Header("Component References")]
    CinemachineComponentBase componentBase;
    public GameObject VCamOrbit;
    public GameObject LookAtObject;

    public UIScript uiScript;
    Vector3 GetCenter(GameObject o) {
        Vector3 sumVector = new Vector3(0f,0f,0f);
        var children = GetComponentsInChildren<Transform>();
        //Bounds bounds = children[0].bounds;
        foreach(Transform child in o.transform) {
            //Debug.Log(child.position);
            sumVector += child.position;
            //bounds.Encapsulate(child.bounds);
        }

        Vector3 groupCenter = sumVector/o.transform.childCount;
        return groupCenter;
    }
    private void Start() {
        Debug.Log(LookAtObject.transform.childCount);
        //var c = LookAtObject.GetComponentsInChildren<Transform>();
        //foreach(var child in c) {
        //    Debug.Log(child.position);
        //}
        Vector3 position = GetCenter(LookAtObject);
        //Debug.Log(position);
        GameObject wCenter = new GameObject();
        wCenter.transform.position = position;
        VCamOrbit.GetComponent<CinemachineFreeLook>().m_Follow = wCenter.transform;
        VCamOrbit.GetComponent<CinemachineFreeLook>().m_LookAt = wCenter.transform;
    }

    public void Swap() {
        uiScript.DebugLog();
        Time.timeScale = 0f;
        //GameCam.gameObject.SetActive(!GameCam.gameObject.activeSelf);
        UICam.gameObject.SetActive(!UICam.gameObject.activeSelf);
    }
}
