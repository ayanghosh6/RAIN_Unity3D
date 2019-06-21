using Leap;
using Leap.Unity;
using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class HumanOrionPublisher : Publisher<Messages.Sensor.Human_orion>
    {
        // private JoyAxisReader[] JoyAxisReaders;
        // private JoyButtonReader[] JoyButtonReaders;

        public string FrameId = "Unity";
        public HandModelBase Righthand;
        public HandModelBase Lefthand;

        private Messages.Sensor.Human_orion message;
        private Hand leap_hand_right;
        private Hand leap_hand_left;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void Update()
        {
            UpdateMessage();
        }      

        private void InitializeMessage()
        {
            message = new Messages.Sensor.Human_orion();
            message.header.frame_id = FrameId;
            message.right_hand = new Messages.Sensor.Hand_orion();
            message.left_hand = new Messages.Sensor.Hand_orion();
        }

        private void UpdateMessage()
        {
            message.right_hand.is_present = false;
            message.left_hand.is_present = false;

            // Right hand
            leap_hand_right = Righthand.GetLeapHand();
            
            if (Righthand.IsTracked && leap_hand_right.IsRight)
            {
                message.right_hand.is_present = true;

                message.right_hand.grab_strength = leap_hand_right.GrabStrength;
                message.right_hand.palm_center.x = leap_hand_right.PalmPosition.x;
                message.right_hand.palm_center.y = leap_hand_right.PalmPosition.y;
                message.right_hand.palm_center.z = leap_hand_right.PalmPosition.z;

               
                message.right_hand.palm_velocity = leap_hand_right.PalmVelocity.ToFloatArray();

                message.right_hand.palm_normal.x = leap_hand_right.PalmNormal.x;
                message.right_hand.palm_normal.y = leap_hand_right.PalmNormal.y;
                message.right_hand.palm_normal.z = leap_hand_right.PalmNormal.z;

                message.right_hand.palm_direction.x = leap_hand_right.Direction.x;
                message.right_hand.palm_direction.y = leap_hand_right.Direction.y;
                message.right_hand.palm_direction.z = leap_hand_right.Direction.z;
            }


            // Left hand
            leap_hand_left = Lefthand.GetLeapHand();
            if (Lefthand.IsTracked && leap_hand_left.IsLeft)
            {
                message.left_hand.is_present = true;

                message.left_hand.grab_strength = leap_hand_left.GrabStrength;
                message.left_hand.palm_center.x = leap_hand_left.PalmPosition.x;
                message.left_hand.palm_center.y = leap_hand_left.PalmPosition.y;
                message.left_hand.palm_center.z = leap_hand_left.PalmPosition.z;

                message.left_hand.palm_velocity = leap_hand_left.PalmVelocity.ToFloatArray();

                message.left_hand.palm_normal.x = leap_hand_left.PalmNormal.x;
                message.left_hand.palm_normal.y = leap_hand_left.PalmNormal.y;
                message.left_hand.palm_normal.z = leap_hand_left.PalmNormal.z;
                
                message.left_hand.palm_direction.x = leap_hand_left.Direction.x;
                message.left_hand.palm_direction.y = leap_hand_left.Direction.y;
                message.left_hand.palm_direction.z = leap_hand_left.Direction.z;

            }
 
            Publish(message);

        }
    }
}
