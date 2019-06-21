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
    public class ThumbTextBehaviour : MonoBehaviour
    {

        public TextMesh textMesh;

        public void Show_Active()
        {

            textMesh.text = "Yes, you Thumbed up";
        }

        public void Show_Deactive()
        {

            textMesh.text = "Try Thumb up using your Right Hand";
        }

        public void Show_Extended()
        {

            textMesh.text = "Yes, your four fingers are Extended";
        }

        public void Show_Direction()
        {

            textMesh.text = "Yes Thumb Direction is fine";
        }
    }
}
