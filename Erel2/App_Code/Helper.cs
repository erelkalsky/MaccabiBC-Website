using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public static class Helper
{
    public const string DBName = "Database1.mdf";   //השם של הדטא בייס
    public const string tblName = "usersTable";      // השם של הטבלת משתמשים בדטאבייס
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\" + DBName + ";Integrated Security=True"; // החיבור לדטא בייס (Connection String)
    //Integrated Security when false, User ID and Password are specified in the connection.
    //When true, the current Windows account credentials are used for authentication.

    public static void Insert1(User user)
    //הפעולה מקבלת משתמש ומכניסה אותו לטבלה כשורה חדשה
    //הפעולה לא בודקת האם המשתמש קיים
    //שיטה לא מקושרת
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName + " WHERE 0=1";
        SqlCommand cmd = new SqlCommand(SQLStr, con); //בניית הפקודה

        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים | בונה מתאם
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].NewRow();
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["userName"] = user.userName;
        dr["password"] = user.password;
        dr["gender"] = user.gender;
        dr["phoneAreaCode"] = user.phoneAreaCode;
        dr["phone"] = user.phone;
        dr["email"] = user.email;
        dr["admin"] = user.admin;
        ds.Tables[tblName].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, tblName);
    }

    public static int Insert2(User user)
    //הפעולה מקבלת משתמש ומכניסה אותו לטבלה כשורה חדשה
    //הפעולה לא בודקת האם המשתמש קיים
    //שיטה מקושרת
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"INSERT INTO " + tblName + " " +
                        $"VALUES ('{user.userName}','{user.password}'," +
                        $"N'{user.firstName}',N'{user.lastName}'," +
                        $"N'{user.gender}', '{user.phoneAreaCode}'," +
                        $"'{user.phone}', '{user.email}', '{user.admin}');";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        // מחזיר את מספר השורות שהשתנו מהפעולה
        return n;
    }

    public static void Delete(int[] userIdToDelete)
    //מקבל מערך של איידי של יוזרים שצריך למחוק

    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // טעינת הנתונים
        string SQLStr = "SELECT * FROM " + tblName; //בחירה * = הכל מהטבלת משתמשים
        SqlCommand cmd = new SqlCommand(SQLStr, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds, tblName); //מכניס את הטבלה לתוך הדטא סט

        // מחיקת שורות שנבחרו מתוך הדאטה סט
        for (int i = 0; i < userIdToDelete.Length; i++)
        {
            {
                DataRow[] dr = ds.Tables[tblName].Select($"userId = {userIdToDelete[i]}");
                dr[0].Delete();
            }
        }

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetDeleteCommand();
        adapter.Update(ds, tblName);
    }

    public static void Update(User user)
    //הפעולה מקבלת משתמש עם כל הפרטים ומחפשת בדטא בייס איזה שורה מתאימה לפי מספר הזהוי (איידי) של המשתמש 
    //שיטה לא מקושרת
    // The Method recieve a user objects.
    // Find the user in the DataBase acording to his userId and update all the other properties in DB.
    {
        // connect to DataBase
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // Build SQL Query
        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName + $" WHERE userid='{user.userId}'";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // Build DataAdapter
        //בונה מתאם
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        adapter.Fill(ds, tblName);

        // בניית השורה לעדכון
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["firstName"] = user.firstName;
        dr["lastName"] = user.lastName;
        dr["userName"] = user.userName;
        dr["password"] = user.password;
        dr["gender"] = user.gender;
        dr["phoneAreaCode"] = user.phoneAreaCode;
        dr["phone"] = user.phone;
        dr["email"] = user.email;
        dr["admin"] = user.admin;

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);
    }

    public static int UpdateToAdmin(int[] userIdToAdminOrUser, string value)
    //מקבלת מערך של (איידי) של משתמשים (מספרי זיהוי) ומשתנה מחרוזת של מנהל או משתמש בשביל לנות
    //שיטה מקושרת
    // The Array "userIdToAdminOrUser" contain the id of the users to change to Admin or User. 
    // Change all the users in the array "userIdToAdminOrUser" to set as Admin or User.
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = $"UPDATE " + tblName +
            $" SET admin = '{value}' " +
            $"WHERE ";

        for (int i = 0; i < userIdToAdminOrUser.Length - 1; i++)
        {
            {
                SQLStr += $" userId = {userIdToAdminOrUser[i]} ";
                SQLStr += "OR ";
            }
        }
        SQLStr += $" userId = {userIdToAdminOrUser[userIdToAdminOrUser.Length - 1]} ";
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        // מחזיר את מספר השורות שהשתנו מהפעולה
        return n;
    }

    public static Boolean IsUserExist1(string userName, string password)
    //בודק האם משתמש קיים לפי שם משתמש וסיסמא מחזירה נכון או לא נכון בהתאם להאם המשתמש קיים
    //מחזירה נכון אם קיים ואם לא מחזירה לא נכון
    //שיטה מקושרת בכלל GetScalar()
    {
        int count = 0;

        // בדיקה אם קיים שם משתמש
        string SQLStr = $"SELECT * FROM " + tblName +
            $" WHERE userName='{userName}' AND password = '{password}'";

        object result = Helper.GetScalar(SQLStr); //מחזיר אובייקט
        if (result != null)
            count = (int)result; //ממיר את האוביקט למספר שלם

        return (count != 0); //אם הכאוונטר שונה מאפס מחזיר נכון אם לא מחזיר לא נכון
    }

    public static Boolean IsUserExist1(string userName)
    //בדיקה אם משתמש קיים לפי שם משתמש מחזירה נכון או לא נכון בהתאם להאם המשתמש קיים
    //בשביל לשנות שם משתמש או ליצור חדש
    //שיטה מקושרת בכלל GetScalar()
    {
        int count = 0;

        // בדיקה אם קיים שם משתמש
        string SQLStr = $"SELECT * FROM " + tblName +
            $" WHERE userName='{userName}'";

        object result = Helper.GetScalar(SQLStr); //מחזיר אובייקט
        if (result != null)
            count = (int)result; //ממיר את האוביקט למספר שלם

        return (count != 0); //אם הכאוונטר שונה מאפס מחזיר נכון אם לא מחזיר לא נכון
    }

    public static Boolean IsUserExist2(string userName, string password)
    //מקבלת שם משתמש וסיסמא מחפש את השורה שלו בדטאבייס, יוצר דטא סט שמכיל את כל המידע בשורה ובודק אם השורה ריקה או לא
    //שיטה לא מקושרת
    {
        // בדיקה אם קיים שם משתמש
        string SQLStr = $"SELECT * FROM " + tblName +
            $" WHERE userName='{userName}' AND password = '{password}'";

        DataSet ds = Helper.RetrieveTable(SQLStr);
        return (ds.Tables[tblName].Rows.Count > 0); //מחזיר נכון עם משספר השורות שיש גדול מאפס
    }

    public static Boolean IsUserExist2(string userName)
    //מקבלת שם משתמש השורה שלו בדטאבייס, יוצר דטא סט שמכיל את כל המידע בשורה ובודק אם השורה ריקה או לא
    //שיטה לא מקושרת
    {
        // בדיקה אם קיים שם משתמש
        string SQLStr = $"SELECT * FROM " + tblName +
            $" WHERE userName='{userName}'";

        DataSet ds = Helper.RetrieveTable(SQLStr);
        return (ds.Tables[tblName].Rows.Count > 0); //מחזיר נכון עם משספר השורות שיש גדול מאפס
    }

    public static Boolean IsAdmin1(string userName)
    //הפעולה מקבלת שם משתמש ולפיו בודקת האם הוא מנהל או לא
    //שיטה לא מקושרת
    {
        // בדיקה אם קיים שם משתמש
        string SQLStr = $"SELECT * FROM " + tblName +
            $" WHERE userName='{userName}'";

        DataSet ds = Helper.RetrieveTable(SQLStr);
        return (Boolean)(ds.Tables[tblName].Rows[0]["admin"]); //מחזיר אם בדטא סט בטבלה של היוזר טייבל בשורה 0 השורה שביקשנו איפה שאדמין נמצא אם הוא נכון או לא נכון
    }

    public static Boolean IsAdmin2(string userName)
    //הפעולה מקבלת שם משתמש ולפיו בודקת האם הוא מנהל או לא
    //שיטה לא מקושרת
    {
        // בדיקה אם קיים שם משתמש
        string SQLStr = $"SELECT * FROM " + tblName +
            $" WHERE userName='{userName}'";

        User user = GetUserData2(SQLStr);
        return user.admin;
    }

    public static DataSet RetrieveTable(string SQLStr)
    //הפעולה מקבלת שורה או חיבור טבלה מתוך הדטאבייס מתחברת לטבלה ויצרת דאטה סטומחזירה אותו עם כל המידע של הטבלה
    //שיטה לא מקושרת
    // Gets A table from the data base acording to the SELECT Command in SQLStr;
    // Returns DataSet with the Table.
    {
        // connect to DataBase
        SqlConnection con = new SqlConnection(conString);

        // Build SQL Query
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // Build DataAdapter
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        DataSet ds = new DataSet();

        // Get Data form DataBase into the DataSet
        // con.Open();
        adapter.Fill(ds, tblName);
        // con.Close()
        return ds;
    }

    public static object GetScalar(string SQLStr)
    //מקבלת מחרוזת שהיא קישור לדטאבייס לאיפה לחפש | ומחזירה את מספר הזיהוי של השורה הזאת
    //שיטה מקושרת
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // ביצוע השאילתא
        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }

    public static User GetUserData1(string SQLStr)
    //הפעולה מקבלת יוזר ובודקת אם הוא קיים. אם כן יוצרת יוזר חדש עם הפרטים שלו אם לא יוצרת יוזר חדש וקוראת לו מבקר
    //שיטה לא מקושרת
    // The Method check if there is a user. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        DataSet ds = RetrieveTable(SQLStr);
        DataTable dt = ds.Tables[tblName];
        User user = new User();
        if (ds.Tables[tblName].Rows.Count > 0)
        {
            // שימוש בנתונים שהתקבלו
            DataRow dr = dt.Rows[0];
            user.userId = (int)dr["UserId"];
            user.userName = dr["userName"].ToString();
            user.password = dr["password"].ToString();
            user.firstName = dr["firstName"].ToString();
            user.lastName = dr["lastName"].ToString();
            user.gender = dr["gender"].ToString();
            user.phoneAreaCode = dr["phoneAreaCode"].ToString();
            user.phone = dr["phone"].ToString();
            user.email = dr["email"].ToString();
            user.admin = (Boolean)dr["admin"];
        }
        else
        {
            user.userName = "Visitor";
            user.admin = false;
        }
        return user;
    }

    public static User GetUserData2(string SQLStr)
    //הפעולה מקבלת יוזר ובודקת אם הוא קיים. אם כן יוצרת יוזר חדש עם הפרטים שלו אם לא יוצרת יוזר חדש וקוראת לו מבקר
    //שיטה מקושרת
    // The Method check if there is a user. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // שימוש בנתונים שהתקבלו
        User user = new User();
        if (reader.HasRows)
        {
            reader.Read();
            user.userId = reader.GetInt32(0);
            user.userName = reader.GetString(1);
            user.password = reader.GetString(2);
            user.firstName = reader.GetString(3);
            user.lastName = reader.GetString(4);
            user.gender = reader.GetString(5);
            user.phoneAreaCode = reader.GetString(6);
            user.phone = reader.GetString(7);
            user.email = reader.GetString(8);
            user.admin = reader.GetBoolean(9);
        }
        else
        {
            user.userName = "Visitor";
            user.admin = false;
        }
        reader.Close();
        con.Close();
        return user;
    }

    public static User GetUserData1(string userName, string password)
    //הפעולה מקבלת שם משתמש וסיסמה ולוקחת מהטבלה את השורה עם שם המשתמש והסיסמה ומחזירה את הפעולה שמחזירה יוזר עם הפרטים
    //שיטה לא מקושרת
    // The Method check if there is a user with userName and password. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName +
        $" WHERE userName='{userName}' AND password='{password}'";

        return GetUserData1(SQLStr);
    }

    public static User GetUserData1(int userId)
    //הפעולה מקבלת מספר זיהוי ולוקחת מהטבלה את השורה עם שם המשתמש והסיסמה ומחזירה את הפעולה שמחזירה יוזר עם הפרטים
    //שיטה לא מקושרת
    // The Method check if there is a user with userName. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName + $" WHERE userid='{userId}'";
        return GetUserData1(SQLStr);
    }

    public static User GetUserData2(string userName, string password)
    //הפעולה מקבלת שם משתמש וסיסמה ולוקחת מהטבלה את השורה עם שם המשתמש והסיסמה ומחזירה את הפעולה שמחזירה יוזר עם הפרטים
    //שיטה מקושרת
    // The Method check if there is a user with userName and password. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName +
        $" WHERE userName='{userName}' AND password='{password}'";

        return GetUserData2(SQLStr);
    }

    public static User GetUserData2(int userId)
    //הפעולה מקבלת מספר זיהוי ולוקחת מהטבלה את השורה עם המספר זיהוי ומחזירה את הפעולה שמחזירה יוזר עם הפרטים
    //שיטה מקושרת
    // The Method check if there is a user with userName. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName + $" WHERE userid='{userId}'";
        return GetUserData2(SQLStr);
    }

    public static User GetUserDataS(string userName, string email)
    //הפעולה מקבלת שם משתמש ואימייל ולוקחת מהטבלה את השורה עם שם המשתמש והסיסמה ומחזירה את הפעולה שמחזירה יוזר עם הפרטים
    //שיטה לא מקושרת
    // The Method check if there is a user with userName and password. 
    // If true the Method return a user with his data (properties).
    // If not the Method return a user with first name "Visitor" and admin = false
    {
        // בניית פקודת SQL
        string SQLStr = $"SELECT * FROM " + tblName +
        $" WHERE userName='{userName}' And email = '{email}' ";

        return GetUserData1(SQLStr);
    }

    public static string BuildSimpleFullUsersTable()
    // the Method Build HTML users table.
    //לוקחים את טבלת המשתמשים מהדטאבייס ויוצרים מחרוזת חדשה עוברים על כל השורות והעמודות ומכניסים את כל התוכן של הטבלה לסטרינג
    //הסטרינג ישמש כהצגה בטבלת המשתמשים את הטבלה
    {
        string SQLStr = "SELECT * FROM " + tblName;
        DataSet ds = RetrieveTable(SQLStr);
        DataTable dt = ds.Tables[tblName];

        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }
        str += "</tr>";

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
                if(column.ColumnName.Equals("admin"))
                {
                    if((bool) row[column] == true)
                    {
                        str += "<td> Admin </td>";
                    }
                    else
                    {
                        str += "<td> User </td>";
                    }
                } 
                else
                {
                    str += "<td>" + row[column] + "</td>";
                }
            }
            str += "</tr>";
        }

        str += "</Table>";
        return str;
    }

    public static string CreateRadioBtn(string id)
        //יוצרת כפתור שניתן ללחוץ עליו בטבלה
        //האיידי שמקבלים הוא היוזר איידי בשביל האיידי של הכפתור לזיהוי המשתמש בטבלת המשתמשים כאשר מסמנים את הכפתור
    {
        return $"<input type='checkbox' name='chk{id}' id='chk{id}' runat='server' />";
    }

    public static string BuildUsersTable(DataTable dt)
    // לוקחים את טבלת המשתמשים מהדאטה בייס ויוצרים מחרוזת חדשה ועוברים על כל השורות והעמודות ומכניסים את כל התוכן של הטבלה לסטרינג וכך בונים את ה html..
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {
        string str = "<table class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td class='bgColor'> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td class='bgColor'>" + column.ColumnName + "</td>";
        }
        str += "</tr>";

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td class='bgColor'>" + CreateRadioBtn(row["userId"].ToString()) + "</td>";
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName.Equals("admin"))
                {
                    if ((bool)row[column] == true)
                    {
                        str += "<td> Admin </td>";
                    }
                    else
                    {
                        str += "<td> User </td>";
                    }
                }
                else
                {
                    str += "<td>" + row[column] + "</td>";
                }
            }
            str += "</tr>";
        }

        str += "</Table>";
        return str;
    }

    public static string BuildFullUsersTable()
    // שאילת שמחזירה את כל היוזרים בטבלה ומחזירה את כל התוצאות לקלאס מסוג דאטה טייבל ומפעילה פעולה שבונה את ה html.
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {
        string SQLStr = "SELECT * FROM " + tblName;
        DataSet ds = RetrieveTable(SQLStr);
        DataTable dt = ds.Tables[tblName];
        return BuildUsersTable(dt);
    }

    public static string BuildSortedUsersTable(string sortColumn, string order)
    //פעולה הבונה טבלה חדשה ומסודרת לפי שם השדה וסדר עולה או יורד
    {
        string SQLStr = $"SELECT * FROM " + tblName + $" ORDER BY {sortColumn} {order}";
        DataSet ds = RetrieveTable(SQLStr);
        DataTable dt = ds.Tables[tblName];
        return BuildUsersTable(dt);
    }

    public static string BuildFilteredByNameUsersTable(string filter)
    // פעולה שמקבלת שם, ובודקת את כל השורות בדאטה בייס עם השם הפרטי,משפחה או שם משתמש ויוצרת טבלה חדשה
    {
        string SQLStr = $"SELECT * FROM " + tblName + " WHERE" +
                        $" firstName LIKE N'%{filter}%' OR" +
                        $" lastName LIKE N'%{filter}%' OR" +
                        $" userName LIKE N'%{filter}%'";
        DataSet ds = RetrieveTable(SQLStr);
        DataTable dt = ds.Tables[tblName];
        return BuildUsersTable(dt);
    }
}