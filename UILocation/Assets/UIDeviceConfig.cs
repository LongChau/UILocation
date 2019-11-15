using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System;
using UnityEngine.iOS;

namespace Tongull.Ultility
{
    public class UIDeviceConfig : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private DeviceGeneration _curDeviceType = DeviceGeneration.Unknown;
        [SerializeField]
        private ERectTransformType _rectTransformType;

        [SerializeField]
        private DictUIPosition _dictUIPos;

        [SerializeField]
        private RectTransform _curRectTransform;
        #endregion

        #region Property
        public DeviceGeneration CurDeviceType
        {
            get => _curDeviceType;
            set
            {
                Log.Info($"Change to {value}");
                _curDeviceType = value;

                //// still unknow... We find it by check resolution.
                //if (_curDeviceType == DeviceGeneration.Unknown)
                //    CheckResolution();

                //Log.Info($"position: {_curRectTransform.anchoredPosition}");
                SetupUI();
            }
        }

        #endregion

        private void OnValidate()
        {
            //_curDeviceType = Device.generation;
            _curRectTransform = GetComponent<RectTransform>();
        }

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            //            if (CurDeviceType == DeviceGeneration.Unknown)
            //                CurDeviceType = Device.generation;
            //#if UNITY_EDITOR
            //            else
            //                SetupUI();
            //#endif

            CheckResolution();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void SetupUI()
        {
            UIPosition newUIPosition = _dictUIPos[_curDeviceType];

            if (_rectTransformType == ERectTransformType.Normal)
            {
                _curRectTransform.anchoredPosition = new Vector3(newUIPosition.Position.x, newUIPosition.Position.y, newUIPosition.Position.z);
                _curRectTransform.sizeDelta = new Vector2(newUIPosition.Width, newUIPosition.Height);
            }
            else if (_rectTransformType == ERectTransformType.Stretch)
            {
                //Log.Info($"position: {_curRectTransform.anchoredPosition}");
                //_curRectTransform.rect.Set(newUIPosition.Position.x, newUIPosition.Position.y, newUIPosition.Position.z, newUIPosition.Width);
                _curRectTransform.offsetMin = new Vector2(newUIPosition.Position.x, newUIPosition.Position.y);
                _curRectTransform.offsetMax = new Vector2(-newUIPosition.Position.z, -newUIPosition.Position.w);
            }
        }

        // Find device generation
        [ContextMenu("CheckResolution")]
        private void CheckResolution()
        {
            Log.Info($"Camera.main.aspect: {Camera.main.aspect}");

            if (Math.Abs( Camera.main.aspect - (9f / 16f) ) <= 0.1)
            {
                CurDeviceType = DeviceGeneration.iPhone8;
            }
            else if (Math.Abs(Camera.main.aspect - (1125f / 2436f)) <= 0.1)
            {
#if !UNITY_EDITOR
                if (Device.generation == DeviceGeneration.iPhoneXR)
                    CurDeviceType = Device.generation;
                else
                    CurDeviceType = DeviceGeneration.iPhoneX;
#else
                if (CurDeviceType == DeviceGeneration.iPhoneXR)
                    CurDeviceType = DeviceGeneration.iPhoneXR;
                else
                    CurDeviceType = DeviceGeneration.iPhoneX;
#endif
            }
        }
    }

    [Serializable]
    public struct UIPosition
    {
        [SerializeField]
        private Vector4 position;
        [SerializeField]
        private float width;
        [SerializeField]
        private float height;

        public Vector4 Position { get => position; set => position = value; }
        public float Width { get => width; set => width = value; }
        public float Height { get => height; set => height = value; }
    }

    [Serializable]
    public class DictUIPosition : SerializableDictionaryBase<DeviceGeneration, UIPosition> { }
}
