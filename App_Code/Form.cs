using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Form
/// </summary>
public class Forms
{
    protected string name;
    protected string form_id;
    protected string user_id;
    protected string submission_date;
   


    public Forms()
    {
       

    }


    public void SetDate(string value)
    {
        this.submission_date = value;
    }


    public void SetFormId(string value)
    {
        this.form_id = value;
    }

    
    public void SetUserId(string value)
    {
        user_id = value;
    }

   

    public string getFormId()
    {
        return form_id;
    }

    public string getUserId()
    {
        return user_id;
    }

    

  

    

}