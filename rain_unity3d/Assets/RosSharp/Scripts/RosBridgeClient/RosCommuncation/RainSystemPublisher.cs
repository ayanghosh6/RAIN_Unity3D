using Leap;
using Leap.Unity;
using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class RainSystemPublisher : Publisher<Messages.System.rain_system>
    {

        public string FrameId = "Unity";
        private Messages.System.rain_system message;

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
            message = new Messages.System.rain_system();
            message.header.frame_id = FrameId;
            message.teleoperation_mode = "";
           
        }

        private void UpdateMessage()
        {
            message.teleoperation_mode = Global.teleoperation_mode;


            Publish(message);

        }
    }
}
