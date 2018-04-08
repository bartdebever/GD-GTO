using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class OptionScript : MonoBehaviour
    {
        public TurnManagement TurnManager;
        public Slider BpmSlider;
        public Slider YSlider;
        public Slider ZSlider;
        public Slider XSlider;
        public Slider AngleSlider;
        public InputField NameField;

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

        private int player = 0;
        private PlayerScript playerEdit;
        void Start()
        {
            NextPlayer();
            
            BpmSlider.onValueChanged.AddListener(delegate { TurnManager.SetBpm(BpmSlider.value); });
        }

        public void NextPlayer()
        {
            if (playerEdit != null)
            {
                Save();
            }
            SelectPlayer(Game.GetPlayers()[player]);
            player++;
            if (player >= Game.GetPlayers().Count)
                player = 0;
        }
        void SelectPlayer(PlayerScript player)
        {
            playerEdit = player;
            var cameraScript = playerEdit.GetComponentInChildren<CameraScript>();
            xModifier = cameraScript.XModifier;
            yModifier = cameraScript.YModifier;
            zModifier = cameraScript.ZModifier;
            angleModifier = cameraScript.AngleModifier;
            RemoveListeners();
            UpdateSliders();
            AddListeners();
            UpdateUI();
        }

        private void AddListeners()
        {
            YSlider.onValueChanged.AddListener(delegate
            {
                yModifier = YSlider.value;
                SetCameraPos(playerEdit.GetComponentInChildren<Camera>());
            });
            XSlider.onValueChanged.AddListener(delegate
            {
                xModifier = XSlider.value;
                SetCameraPos(playerEdit.GetComponentInChildren<Camera>());
            });
            ZSlider.onValueChanged.AddListener(delegate
            {
                zModifier = ZSlider.value;
                SetCameraPos(playerEdit.GetComponentInChildren<Camera>());
            });
            AngleSlider.onValueChanged.AddListener(delegate
            {
                angleModifier = AngleSlider.value;
                playerEdit.GetComponentInChildren<Camera>().transform.eulerAngles = new Vector3(angleModifier, 0, 0);
            });
        }

        private void RemoveListeners()
        {
            YSlider.onValueChanged.RemoveAllListeners();
            ZSlider.onValueChanged.RemoveAllListeners();
            XSlider.onValueChanged.RemoveAllListeners();
            AngleSlider.onValueChanged.RemoveAllListeners();
        }
        void Update()
        {
            if (rebind && Input.anyKeyDown && Input.inputString.Length.Equals(1))
            {
                var keycode = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString, true);
                if (code == 0)
                    playerEdit.Up = keycode;
                else if (code == 1)
                    playerEdit.Down = keycode;
                else if (code == 2)
                    playerEdit.Left = keycode;
                else if (code == 3)
                    playerEdit.Right = keycode;
                rebind = false;
                UpdateUI();
            }
        }

        public void Save()
        {
            var cameraScript = playerEdit.GetComponentInChildren<CameraScript>();
            cameraScript.AngleModifier = angleModifier;
            cameraScript.XModifier = xModifier;
            cameraScript.YModifier = yModifier;
            cameraScript.ZModifier = zModifier;
            playerEdit.gameObject.name = NameField.text;
        }
        private void SetCameraPos(Camera camera)
        {
            camera.transform.position =
                playerEdit.GetComponentInChildren<CameraScript>().BasePosition + new Vector3(xModifier, yModifier, zModifier);
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
            this.LeftText.text = playerEdit.Left.ToString();
            this.UpText.text = playerEdit.Up.ToString();
            this.DownText.text = playerEdit.Down.ToString();
            this.RightText.text = playerEdit.Right.ToString();
            this.NameField.text = playerEdit.gameObject.name;
        }

        private void UpdateSliders()
        {
            YSlider.value = yModifier;
            ZSlider.value = zModifier;
            XSlider.value = xModifier;
            AngleSlider.value = angleModifier;
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            Game.Restart();
        }
    }
}
