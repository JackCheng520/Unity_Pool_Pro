using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：AutoRestoreObj  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 20:37:18
// ================================
namespace Assets.JackCheng.MyPool
{
    public class AutoRestoreObj<T> : IAutoRestoreObj<T>
    {
        private T t;
        public AutoRestoreObj(T _t)
        {
            this.t = _t;
        }
        public IAutoRestoreChecker Checker { get; set; }

        public T Self() {
            return t;
        }
    }
}
