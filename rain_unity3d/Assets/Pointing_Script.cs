using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointing_Script : MonoBehaviour
{
    public Camera cam;
    public SphereCollider sphere;
    public Transform Baselink;

    public Vector3 selected_object_position;
    public Vector3 selected_object_orientation;

    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.00f;
    public float laserMaxLength = 10f;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { sphere.transform.position, sphere.transform.position };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
    }

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(Input.mousePosition));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            // if (hit.transform.tag == "Cube")
            if (Input.GetMouseButton(0) && ((hit.transform.tag == "Cube" || hit.transform.tag == "Cone" || hit.transform.tag == "Spring") || hit.transform.tag == "Nut" || hit.transform.tag == "Bolt"))
            {
                
                laserLineRenderer.enabled = true;

               // laserLineRenderer.SetPosition(0, Input.mousePosition);
                laserLineRenderer.SetPosition(1, hit.transform.position);
                //selected_object_position = hit.transform.position;

                selected_object_position = hit.transform.position - Baselink.transform.position;
                Debug.Log("Base Position: x = " + Baselink.transform.position.x.ToString() + " y = " + Baselink.transform.position.y.ToString() + " z = " + Baselink.transform.position.z.ToString());

                Debug.Log("Object Position: x = " + selected_object_position.x.ToString() + " y = " + selected_object_position.y.ToString() + " z = " + selected_object_position.z.ToString());
                selected_object_orientation = hit.transform.rotation.eulerAngles;
                //hit.collider.gameObject.GetComponent<Renderer>.       
            }
            else
            {
               
                laserLineRenderer.enabled = false;
            }
        }
        
        
        
        //laserLineRenderer.enabled = false;
        //Ray ray = new Ray(Input.mousePosition, Vector3.forward);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 100))
        //{
        //    if (Input.GetMouseButtonDown(0))

        //    {
        //        laserLineRenderer.enabled = true;
        //        laserLineRenderer.SetPosition(0, Input.mousePosition);
        //        laserLineRenderer.SetPosition(1, ray.direction);
        //    }

        //    else
        //    {
        //        laserLineRenderer.enabled = false;
        //    }
        //}


    }
}
