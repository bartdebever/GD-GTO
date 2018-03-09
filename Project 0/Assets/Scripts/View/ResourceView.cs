using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class ResourceView : MonoBehaviour
    {
        public ResourceModel ResourceModel;
        public Text Text;

        public void Start()
        {
            this.ResourceModel.OnValueChanged += UpdateGUI;
        }

        private void UpdateGUI()
        {
            Text.text = ResourceModel.name + ": " + ResourceModel.amount;
        }
    }
}
