using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloommeApi.Codes
{
    public class SN_CustomersInfo
    {
            #region " Private Variables "

            private int _CustomerID;
            private string _Firstname;
            private string _Lastname;
            private string _Middlename;
            private DateTime _DateOfBirth;
            private string _Gender;
            private string _EmailAddress;
            private string _PhoneNo;
            private string _CustomerAddress;
            private string _City;
            private string _State;
            private int _CountryID;
            private string _CustomerPassword;
            private DateTime _DateCreated;
            private string _IPAddress;
            private string _Longitude;
            private string _Latitude;
            private DateTime _LastLoginDate;

            private bool _CustomerActive;
            #endregion

            #region " Properties "
            public int CustomerID
            {
                get { return _CustomerID; }
                set { _CustomerID = value; }
            }

            public string Firstname
            {
                get { return _Firstname; }
                set { _Firstname = value; }
            }

            public string Lastname
            {
                get { return _Lastname; }
                set { _Lastname = value; }
            }

            public string Midllename
            {
                get { return _Middlename; }
                set { _Middlename = value; }
            }

            public System.DateTime DateOfBirth
            {
                get { return _DateOfBirth; }
                set { _DateOfBirth = value; }
            }

            public string Gender
            {
                get { return _Gender; }
                set { _Gender = value; }
            }

            public string EmailAddress
            {
                get { return _EmailAddress; }
                set { _EmailAddress = value; }
            }

            public string PhoneNo
            {
                get { return _PhoneNo; }
                set { _PhoneNo = value; }
            }

            public string CustomerAddress
            {
                get { return _CustomerAddress; }
                set { _CustomerAddress = value; }
            }

            public string City
            {
                get { return _City; }
                set { _City = value; }
            }

            public string State
            {
                get { return _State; }
                set { _State = value; }
            }

            public int CountryID
            {
                get { return _CountryID; }
                set { _CountryID = value; }
            }

            public string CustomerPassword
            {
                get { return _CustomerPassword; }
                set { _CustomerPassword = value; }
            }

            public System.DateTime DateCreated
            {
                get { return _DateCreated; }
                set { _DateCreated = value; }
            }

            public string IPAddress
            {
                get { return _IPAddress; }
                set { _IPAddress = value; }
            }

            public string Longitude
            {
                get { return _Longitude; }
                set { _Longitude = value; }
            }

            public string Latitude
            {
                get { return _Latitude; }
                set { _Latitude = value; }
            }

            public System.DateTime LastLoginDate
            {
                get { return _LastLoginDate; }
                set { _LastLoginDate = value; }
            }

            public bool CustomerActive
            {
                get { return _CustomerActive; }
                set { _CustomerActive = value; }
            }

            #endregion

        
    }
}