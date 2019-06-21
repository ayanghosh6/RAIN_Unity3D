using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class TwistPositionOffset : Publisher<Messages.Standard.String>
    {
        private Messages.Standard.String message;
        private float previousRealTime;

        public Camera cam;
        public SphereCollider sphere;

        public Vector3 selected_object_position;
        public Vector3 selected_object_orientation;

        public LineRenderer laserLineRenderer;
        public float laserWidth = 0.00f;
        public float laserMaxLength = 10f;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            InitializeMessage();

            Vector3[] initLaserPositions = new Vector3[2] { sphere.transform.position, sphere.transform.position };
            laserLineRenderer.SetPositions(initLaserPositions);
            laserLineRenderer.startWidth = laserWidth;
            laserLineRenderer.endWidth = laserWidth;
        }

        private void FixedUpdate()
        {
            UpdateMessage();
        }

        private void InitializeMessage()
        {
            
            
        }

       





            // Update is called once per frame
            private void UpdateMessage()
        {
            float deltaTime = Time.realtimeSinceStartup - previousRealTime;
            Ray ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(Input.mousePosition));
            RaycastHit hit;

            float value;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // if (hit.transform.tag == "Cube")
                if (Input.GetMouseButton(0) && (hit.transform.tag == "Cube" ))
                {

                    laserLineRenderer.enabled = true;

                    // laserLineRenderer.SetPosition(0, Input.mousePosition);
                    laserLineRenderer.SetPosition(1, hit.transform.position);
                    selected_object_position = hit.transform.position;
                    selected_object_orientation = hit.transform.rotation.eulerAngles;
                    //hit.collider.gameObject.GetComponent<Renderer>.       
                    value = 0;
                    message.data = value.ToString();
                    Publish(message);
                }

                else if (Input.GetMouseButton(0) && (hit.transform.tag == "Cone"))
                {
                    laserLineRenderer.enabled = true;

                    // laserLineRenderer.SetPosition(0, Input.mousePosition);
                    laserLineRenderer.SetPosition(1, hit.transform.position);
                    selected_object_position = hit.transform.position;
                    selected_object_orientation = hit.transform.rotation.eulerAngles;
                    //hit.collider.gameObject.GetComponent<Renderer>.       
                    value = 1;
                    message.data = value.ToString();
                    Publish(message);
                }

                else if (Input.GetMouseButton(0) && (hit.transform.tag == "Nut"))
                {
                    laserLineRenderer.enabled = true;

                    // laserLineRenderer.SetPosition(0, Input.mousePosition);
                    laserLineRenderer.SetPosition(1, hit.transform.position);
                    selected_object_position = hit.transform.position;
                    selected_object_orientation = hit.transform.rotation.eulerAngles;
                    //hit.collider.gameObject.GetComponent<Renderer>.       
                    value = 2;
                    message.data = value.ToString();
                    Publish(message);
                }

                else if (Input.GetMouseButton(0) && (hit.transform.tag == "Bolt"))
                {
                    laserLineRenderer.enabled = true;

                    // laserLineRenderer.SetPosition(0, Input.mousePosition);
                    laserLineRenderer.SetPosition(1, hit.transform.position);
                    selected_object_position = hit.transform.position;
                    selected_object_orientation = hit.transform.rotation.eulerAngles;
                    //hit.collider.gameObject.GetComponent<Renderer>.       
                    value = 3;
                    message.data = value.ToString();
                    Publish(message);
                }

                else if (Input.GetMouseButton(0) && (hit.transform.tag == "Spring"))
                {
                    laserLineRenderer.enabled = true;

                    // laserLineRenderer.SetPosition(0, Input.mousePosition);
                    laserLineRenderer.SetPosition(1, hit.transform.position);
                    selected_object_position = hit.transform.position;
                    selected_object_orientation = hit.transform.rotation.eulerAngles;
                    //hit.collider.gameObject.GetComponent<Renderer>.       
                    //value = 4;
                    //message.data = value.ToString();
                    //Publish(message);
                }


                else
                {

                    laserLineRenderer.enabled = false;
                }
            }


           
        }
    }
}

