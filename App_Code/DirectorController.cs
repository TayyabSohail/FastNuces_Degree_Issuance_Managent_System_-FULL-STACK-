using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StuController
/// </summary>
public class DirectorController
{
    private static DirectorController unique_controller = null;
    private Director direct = null;
    private DirectorController()
    {
        direct = new Director();
    }

    public static DirectorController getInstance()
    {
        if (unique_controller == null)
        {
            unique_controller = new DirectorController(); ;

        }
        return unique_controller;
    }

    public Director getDirector()
    {
        return direct;
    }


    public static void ResetUniqueController()
    {
        unique_controller = null;
        
    }
}