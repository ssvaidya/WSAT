using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WSATTest
{
    public class GetAllUsers
    {
        public GetAllUsers()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet CustomGetAllUsers()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = ds.Tables.Add("Users");


            MembershipUserCollection muc = Membership.GetAllUsers();


            dt.Columns.Add("UserName", Type.GetType("System.String"));
            dt.Columns.Add("Email", Type.GetType("System.String"));
            //dt.Columns.Add("PasswordQuestion", Type.GetType("System.String"));
            //dt.Columns.Add("Comment", Type.GetType("System.String"));
            //dt.Columns.Add("ProviderName", Type.GetType("System.String")); // who the hell cares about provider name? :P
            dt.Columns.Add("CreationDate", Type.GetType("System.DateTime"));
            dt.Columns.Add("LastLoginDate", Type.GetType("System.DateTime"));
          //  dt.Columns.Add("LastActivityDate", Type.GetType("System.DateTime"));
           // dt.Columns.Add("LastPasswordChangedDate", Type.GetType("System.DateTime"));
           // dt.Columns.Add("LastLockoutDate", Type.GetType("System.DateTime"));
           // dt.Columns.Add("IsApproved", Type.GetType("System.Boolean"));
           // dt.Columns.Add("IsLockedOut", Type.GetType("System.Boolean"));
           // dt.Columns.Add("IsOnline", Type.GetType("System.Boolean"));


            /* Here is the list of columns returned of the Membership.GetAllUsers() method
             * UserName, Email, PasswordQuestion, Comment, IsApproved
             * IsLockedOut, LastLockoutDate, CreationDate, LastLoginDate
             * LastActivityDate, LastPasswordChangedDate, IsOnline, ProviderName
             */


            foreach (MembershipUser mu in muc)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["UserName"] = mu.UserName;
                dr["Email"] = mu.Email;
                dr["CreationDate"] = mu.CreationDate;
                dr["LastLoginDate"] = mu.LastLoginDate;
                // you can add up the other columns that you want to include in your return value
                dt.Rows.Add(dr);
            }
            return ds;
        }
    }
}