using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for StuController
/// </summary>
public  class StuController
{
    private static StuController unique_controller = null;
    private Student stu = null;
    
    private StuController()
    {
        stu = new Student();
    }

    public static StuController getInstance()
    {
       

        if (unique_controller == null)
        {
            unique_controller = new StuController(); 

        }
        return unique_controller;    
    }

    public Student getStudent()
    {
        return stu;
    }


    public static void  ResetUniqueController()
    {
        unique_controller = null;
        
    }

}