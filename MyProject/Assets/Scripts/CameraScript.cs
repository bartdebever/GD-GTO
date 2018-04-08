using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        public float XModifier = 0;
        public float ZModifier = 0;
        public float YModifier = 0;
        public float AngleModifier = 0;
        public Vector3 BasePosition;
        public void Start()
        {
            this.BasePosition = this.gameObject.transform.position;
        }

    }
}
