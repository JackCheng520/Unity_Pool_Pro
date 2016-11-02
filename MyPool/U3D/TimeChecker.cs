using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// ================================
//* 功能描述：TimeChecker  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 20:04:09
// ================================
namespace Assets.JackCheng.MyPool
{
    public class TimeChecker : MonoBehaviour ,IAutoRestoreChecker
    {
        public float fTime = 0;

        

        public void Init(float _time) {
            fTime = _time;
        }

        public void Update() {
            if(fTime < 0)
                return;
            fTime -= Time.deltaTime;
        }

        public bool IsRestore
        {
            get
            {
                return fTime < 0;
            }
        }
    }
}
