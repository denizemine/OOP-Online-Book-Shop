﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore
{
    ///create a new AdminUserClass instance of UserClass
    public class AdminUserClass:UserClass
    {
        /**
         * @brief Default Constructor  
         * Constructs the object with default parameters 
         * @param string CustomerID
         * @param string Name
         * @param string SurName
         * @param string Address
         * @param string Email
         * @param string UserName
         * @param string Password
         * @param bool isAdmin
         */
        public AdminUserClass(string CustomerID, string Name, string SurName, string Address, string Email, string UserName, string Password, bool isAdmin):base(CustomerID,Name,SurName,Address,Email,UserName,Password, isAdmin)
        {
        }
        /**
        * @brief Default Constructor  
        * Constructs the object with default parameters 
        * userclass have constructor so AdminUserClass should have constructor
        */
        private AdminUserClass() : base() { }//singleton pattern

        public bool addCustomer() { return true; }

        /**
        * Addnew Book, Magazine, MusicCD is gathered under 1 function as they all derived from ProductClass
        */
        public bool addNewProduct(ProductClass product)
        {
            DatabaseHelperClass dbHelper = DatabaseHelperClass.Instance;
            bool affected = dbHelper.addAProductToDB(product);
            return affected;
        }
       

        public bool deleteProduct(Type type, string id)
        {
            DatabaseHelperClass dbHelper = DatabaseHelperClass.Instance;
            bool affected = dbHelper.deleteAnItemObjectFromDBByID(type, id);
            return affected;
        }

        public bool updateProduct(ProductClass product)
        {
            DatabaseHelperClass dbHelper = DatabaseHelperClass.Instance;
            bool affected = dbHelper.updateAProductAtDB(product);
            return affected;
        }

        public override bool isAdmin()
        {
            return true;
        }

        public override bool saveCustomer(string id, string name, string surname, string address, string email, string username, string password, bool isadmin)
        {
            bool operationResult = userOperations("Add", id, name, surname, address, email, username, password, isadmin);
            return operationResult;
        }

        public static bool confirmUser(string userID)
        {
            DatabaseHelperClass dbHelper = DatabaseHelperClass.Instance;
            bool affected = dbHelper.confirmAUser(userID);
            return affected;
        }

        ///Initialize static member of AdminUserClass
        private static AdminUserClass admin = null;
        public static AdminUserClass Instance
        {
            get
            {
                if (admin == null)
                {
                    admin = new AdminUserClass();
                }
                return admin;
            }
        }

    }
}
