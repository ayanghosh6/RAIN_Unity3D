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
    public class GrabStrengthTextBehaviour : MonoBehaviour
    {

        public TextMesh textMesh;

        //public Spaceship ship;
        public RiggedHand hand;

        public bool IsRight;

        public string PrefixText;

        public string PostfixText;

        private float grab_strength;
        private Hand leap_hand;
        void Update()
        {
            //textMesh.text = linearSpeedPrefixText + ship.shipAlignedVelocity.magnitude.ToString("G3") + linearSpeedPostfixText;
            leap_hand = hand.GetLeapHand();
            if (IsRight)
            {
                if (leap_hand.IsRight)
                {
                    grab_strength = leap_hand.GrabStrength;
                    textMesh.text = PrefixText + grab_strength.ToString("G3") + PostfixText;
                }
            }
            else
            {
                if (leap_hand.IsLeft)
                {
                    grab_strength = leap_hand.GrabStrength;
                    textMesh.text = PrefixText + grab_strength.ToString("G3") + PostfixText;
                }
            }


        }
    }
}
