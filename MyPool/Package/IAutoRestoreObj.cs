using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ================================
//* 功能描述：IAutoRestoreObj  
//* 创 建 者：chenghaixiao
//* 创建日期：2016/11/1 19:56:47
// ================================
namespace Assets.JackCheng.MyPool
{
    public interface IAutoRestoreObj<T> 
    {
        IAutoRestoreChecker Checker { get; set; }

        T Self();
    }
}
