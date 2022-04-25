using Login_Entity;
using Common_Entities;
using System;
using System.Collections.Generic;
using System.Text;



namespace Login_Interface
{
    public class ILogin
    {
        JsonResponse GetUserCredentials(string Username);

       
    }
}
