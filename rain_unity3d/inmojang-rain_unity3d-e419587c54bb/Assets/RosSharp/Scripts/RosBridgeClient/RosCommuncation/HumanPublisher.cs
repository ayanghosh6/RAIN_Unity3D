using Leap;
using Leap.Unity;
using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class HumanPublisher : Publisher<Messages.Sensor.Human>
    {
        // private JoyAxisReader[] JoyAxisReaders;
        // private JoyButtonReader[] JoyButtonReaders;

        public string FrameId = "Unity";
        public HandModelBase Righthand;
        public HandModelBase Lefthand;

        private Messages.Sensor.Human message;
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
            message = new Messages.Sensor.Human();
            message.header.frame_id = FrameId;
            message.right_hand = new Messages.Sensor.Hand();
            message.left_hand = new Messages.Sensor.Hand();
        }

        private void UpdateMessage()
        {
            // Right hand
            leap_hand_right = Righthand.GetLeapHand();
            if (leap_hand_right != null){
                message.right_hand.grab_strength = leap_hand_right.GrabStrength;
                message.right_hand.palm_center.x = leap_hand_right.PalmPosition.x;
                message.right_hand.palm_center.y = leap_hand_right.PalmPosition.y;
                message.right_hand.palm_center.z = leap_hand_right.PalmPosition.z;


            }

            // Left hand
            leap_hand_left = Lefthand.GetLeapHand();
            if (leap_hand_left != null)
            {
                message.left_hand.grab_strength = leap_hand_left.GrabStrength;
                message.left_hand.palm_center.x = leap_hand_left.PalmPosition.x;
                message.left_hand.palm_center.y = leap_hand_left.PalmPosition.y;
                message.left_hand.palm_center.z = leap_hand_left.PalmPosition.z;

            }

            Publish(message);

        }
    }
}
