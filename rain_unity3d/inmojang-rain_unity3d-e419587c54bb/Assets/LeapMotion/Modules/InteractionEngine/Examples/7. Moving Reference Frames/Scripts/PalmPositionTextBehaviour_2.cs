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
    public class PalmPositionTextBehaviour_2 : MonoBehaviour
    {

        public TextMesh textMesh;

        public string PrefixText;

        public string PostfixText;


        HandModel hand_model;
        Hand leap_hand;

        void Start()
        {
            hand_model = GetComponent<HandModel>();
            leap_hand = hand_model.GetLeapHand();
            if (leap_hand == null) Debug.LogError("No leap_hand founded");
        }

        private Vector3 palm_position;
        void Update()
        {
            //textMesh.text = linearSpeedPrefixText + ship.shipAlignedVelocity.magnitude.ToString("G3") + linearSpeedPostfixText;
            palm_position = hand_model.GetPalmPosition();
            textMesh.text = PrefixText + palm_position.ToString("G3") + PostfixText;

        }
    }
}
