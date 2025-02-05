using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class User
{
    public int userId;
    public string userName;
    public string password;
    public string firstName;
    public string lastName;
    public string gender;
    public string phoneAreaCode;
    public string phone;
    public string email;
    public bool admin;

    public User()
    {
        userId = -1;
        userName = "";
        password = "";
        firstName = "";
        lastName = "";
        gender = "";
        phoneAreaCode = "";
        phone = "";
        email = "";
        admin = false;
    }
}