/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2018.                                 *
 * Leap Motion proprietary and confidential.                                  *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;

namespace Leap.Unity.Examples
{

    [AddComponentMenu("")]
    public class PalmPositionTextBehaviour : MonoBehaviour
    {

        public TextMesh textMesh;

        //public Spaceship ship;
        public RiggedHand hand;

        public bool IsRight;

        public string PrefixText;

        public string PostfixText;

        private Vector3 palm_position;
        private Vector3 palm_normal;
        private Vector3 palm_direction;
        private float grab_strength;
        private Hand leap_hand;
        void Update()
        {
            //textMesh.text = linearSpeedPrefixText + ship.shipAlignedVelocity.magnitude.ToString("G3") + linearSpeedPostfixText;
            leap_hand = hand.GetLeapHand();
            if (leap_hand!=null)
            {
                if (IsRight)
                {
                    if (leap_hand.IsRight)
                    {
                        palm_position = hand.GetPalmPosition();
                        grab_strength = leap_hand.GrabStrength;
                        palm_normal = hand.GetPalmNormal();
                        palm_direction = hand.GetPalmDirection();
                        textMesh.text = // "Right- Palm Position: " + palm_position.ToString("G3") + " Grab: " + grab_strength.ToString("G3") +
                             "Normal :" + palm_normal.ToString("G2") + " Direction :" + palm_direction.ToString("G2");
                    }
                }
                else
                {
                    if (leap_hand.IsLeft)
                    {
                        palm_position = hand.GetPalmPosition();
                        grab_strength = leap_hand.GrabStrength;
                        textMesh.text = "Left- Palm Position: " + palm_position.ToString("G3") + " Grab: " + grab_strength.ToString("G3");
                    }
                }
            }



        }
    }
}
