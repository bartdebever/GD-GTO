using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class OptionScript : MonoBehaviour
    {
        public List<PlayerScript> Players;
        public TurnManagement TurnManager;
        public Slider BpmSlider;
        public Slider YSlider;
        public Slider ZSlider;
        public Slider XSlider;
        public Slider AngleSlider;

        public Text UpText;
        public Text DownText;
        public Text LeftText;
        public Text RightText;


        private int code = 0;
        private bool rebind = false; 

        private float yModifier = 0;
        private float zModifier = 0;
        private float xModifier = 0;
        private float angleModifier = 0;

        private Vector3 baseCameraPosition;
        void Start()
        {
            UpdateUI();
            baseCameraPosition = Players[0].GetComponentInChildren<Camera>().transform.position;
            BpmSlider.onValueChanged.AddListener(delegate {TurnManager.SetBpm(BpmSlider.value);});
            YSlider.onValueChanged.AddListener(delegate
            {
                yModifier = YSlider.value;
                SetCameraPos(Players[0].GetComponentInChildren<Camera>());
            });
            XSlider.onValueChanged.AddListener(delegate
            {
                xModifier = XSlider.value;
                SetCameraPos(Players[0].GetComponentInChildren<Camera>());
            });
            ZSlider.onValueChanged.AddListener(delegate
            {
                zModifier = ZSlider.value;
                SetCameraPos(Players[0].GetComponentInChildren<Camera>());
            });
            AngleSlider.onValueChanged.AddListener(delegate
            {
                angleModifier = AngleSlider.value;
                Players[0].GetComponentInChildren<Camera>().transform.eulerAngles = new Vector3(angleModifier, 0, 0);
            });
        }

        void Update()
        {
            if (rebind && Input.anyKeyDown && Input.inputString.Length.Equals(1))
            {
                var keycode = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString, true);
                if (code == 0)
                    Players[0].Up = keycode;
                else if (code == 1)
                    Players[0].Down = keycode;
                else if (code == 2)
                    Players[0].Left = keycode;
                else if (code == 3)
                    Players[0].Right = keycode;
                rebind = false;
                UpdateUI();
            }
        }
        private void SetCameraPos(Camera camera)
        {
            camera.transform.position =
                baseCameraPosition + new Vector3(xModifier, yModifier, zModifier);
        }

        public void Rebind(int code)
        {
            this.code = code;
            this.rebind = true;
            if (code == 0)
                UpText.text = "*";
            else if (code == 1)
                DownText.text = "*";
            else if (code == 2)
                LeftText.text = "*";
            else if (code == 3)
                RightText.text = "*";
        }

        public void UpdateUI()
        {
            this.LeftText.text = Players[0].Left.ToString();
            this.UpText.text = Players[0].Up.ToString();
            this.DownText.text = Players[0].Down.ToString();
            this.RightText.text = Players[0].Right.ToString();
        }
    }
}
