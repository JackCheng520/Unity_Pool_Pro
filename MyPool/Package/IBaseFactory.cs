using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：IBaseFactory  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 17:50:25
// ================================
namespace Assets.JackCheng.MyPool
{
    public interface IBaseFactory<T>
    {
        T CreateObj();

        void DestroyObj(T t);

        bool ShowObj(T t);

        bool HideObj(T t);
    }
}
