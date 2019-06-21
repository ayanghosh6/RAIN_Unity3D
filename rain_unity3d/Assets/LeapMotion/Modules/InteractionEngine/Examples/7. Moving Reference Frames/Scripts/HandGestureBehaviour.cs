using UnityEngine;
namespace Leap.Unity.Examples
{
    [AddComponentMenu("")]
    public class HandGestureBehaviour : MonoBehaviour
    {
        public TextMesh textMesh;
        public void MODE_Deactivate()
        {
            textMesh.text = "Activated: MODE 0";
            textMesh.color = Color.green;
            Global.teleoperation_mode = "MODE_0";
        }

        public void MODE_1()
        {
            textMesh.text = "Activated: MODE 1";
            textMesh.color = Color.red;
            Global.teleoperation_mode = "MODE_1";
        }

        public void MODE_2()
        {
            textMesh.text = "MODE_2";
            Global.teleoperation_mode = "MODE_2";
        }



    }
}