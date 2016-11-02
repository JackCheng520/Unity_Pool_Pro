using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：IBasePool  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 17:40:23
// ================================
namespace Assets.JackCheng.MyPool
{
    public interface IBasePool<T>
    {
        T Pop();

        void Add();

        void Check();

        void Clear();

        int GetActiveNum();

        int GetUnActiveNum();
    }
}
