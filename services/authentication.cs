// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;

// namespace COMMON_PROJECT_STRUCTURE_API.services
// {
//     public class Authentication
//     {
//         private readonly dbServices ds = new dbServices();

//         public async Task<responseData> SignUp(requestData rData)
//         {
//             responseData resData = new responseData();
//             try
//             {
//                 var email = rData.addInfo["EMAIL"];
//                 var password = rData.addInfo["PASSWORD"];
                
//                 // Check if the email already exists
//                 var query = @"SELECT * FROM mydb.signup WHERE EMAIL=@EMAIL";
//                 MySqlParameter[] myParam = new MySqlParameter[]
//                 {
//                     new MySqlParameter("@EMAIL", email)
//                 };
//                 var dbData = ds.executeSQL(query, myParam);
//                 if (dbData[0].Any())
//                 {
//                     resData.rData["rMessage"] = "Email already exists";
//                 }
//                 else
//                 {
//                     // Insert new user
//                     var insertQuery = @"INSERT INTO mydb.signup (EMAIL, PASSWORD) VALUES (@EMAIL, @PASSWORD)";
//                     MySqlParameter[] insertParams = new MySqlParameter[]
//                     {
//                         new MySqlParameter("@EMAIL", email),
//                         new MySqlParameter("@PASSWORD", password)
//                     };
//                     var insertResult = ds.executeSQL(insertQuery, insertParams);
//                     resData.rData["rMessage"] = "Signup Successful";
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Handle exceptions appropriately
//                 resData.rData["rMessage"] = "Error: " + ex.Message;
//             }
//             return resData;
//         }

//         public async Task<responseData> SignIn(requestData rData)
//         {
//             responseData resData = new responseData();
//             try
//             {
//                 var email = rData.addInfo["EMAIL"];
//                 var password = rData.addInfo["PASSWORD"];

//                 // Check if the user exists and the password matches
//                 var query = @"SELECT * FROM mydb.signup WHERE EMAIL=@EMAIL AND PASSWORD=@PASSWORD";
//                 MySqlParameter[] myParam = new MySqlParameter[]
//                 {
//                     new MySqlParameter("@EMAIL", email),
//                     new MySqlParameter("@PASSWORD", password)
//                 };
//                 var dbData = ds.executeSQL(query, myParam);
//                 if (dbData[0].Any())
//                 {
//                     resData.rData["rMessage"] = "Signin Successful";
//                 }
//                 else
//                 {
//                     resData.rData["rMessage"] = "Invalid email or password";
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Handle exceptions appropriately
//                 resData.rData["rMessage"] = "Error: " + ex.Message;
//             }
//             return resData;
//         }

//         public async Task<responseData> HandleAuthentication(requestData rData)
//         {
//             if (rData.addInfo["action"].ToString() == "signup")
//             {
//                 return await SignUp(rData);
//             }
//             else if (rData.addInfo["action"].ToString() == "signin")
//             {
//                 return await SignIn(rData);
//             }
//             else
//             {
//                 return new responseData
//                 {
//                     rData = new Dictionary<string, object>
//                     {
//                         ["rMessage"] = "Invalid action"
//                     }
//                 };
//             }
//         }
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;

// namespace COMMON_PROJECT_STRUCTURE_API.services
// {
//     public class Authentication
//     {
//         private readonly dbServices ds = new dbServices();

//         public async Task<responseData> SignUp(requestData rData)
//         {
//             responseData resData = new responseData();
//             try
//             {
//                 var email = rData.addInfo["EMAIL"];
//                 var password = rData.addInfo["PASSWORD"];
                
//                 // Check if the email already exists
//                 var query = @"SELECT * FROM mydb.signup WHERE EMAIL=@EMAIL";
//                 MySqlParameter[] myParam = new MySqlParameter[]
//                 {
//                     new MySqlParameter("@EMAIL", email)
//                 };
//                 var dbData = ds.executeSQL(query, myParam);
//                 if (dbData[0].Any())
//                 {
//                     resData.rData["rMessage"] = "Email already exists";
//                 }
//                 else
//                 {
//                     // Insert new user
//                     var insertQuery = @"INSERT INTO mydb.signup (EMAIL, PASSWORD) VALUES (@EMAIL, @PASSWORD)";
//                     MySqlParameter[] insertParams = new MySqlParameter[]
//                     {
//                         new MySqlParameter("@EMAIL", email),
//                         new MySqlParameter("@PASSWORD", password)
//                     };
//                     var insertResult = ds.executeSQL(insertQuery, insertParams);
//                     resData.rData["rMessage"] = "Signup Successful";
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Handle exceptions appropriately
//                 resData.rData["rMessage"] = "Error: " + ex.Message;
//             }
//             return resData;
//         }

//         public async Task<responseData> SignIn(requestData rData)
//         {
//             responseData resData = new responseData();
//             try
//             {
//                 var email = rData.addInfo["EMAIL"];
//                 var password = rData.addInfo["PASSWORD"];

//                 // Check if the user exists and the password matches
//                 var query = @"SELECT * FROM mydb.signup WHERE EMAIL=@EMAIL AND PASSWORD=@PASSWORD";
//                 MySqlParameter[] myParam = new MySqlParameter[]
//                 {
//                     new MySqlParameter("@EMAIL", email),
//                     new MySqlParameter("@PASSWORD", password)
//                 };
//                 var dbData = ds.executeSQL(query, myParam);
//                 if (dbData[0].Any())
//                 {
//                     resData.rData["rMessage"] = "Signin Successful";
//                 }
//                 else
//                 {
//                     resData.rData["rMessage"] = "Invalid email or password";
//                 }
//             }
//             catch (Exception ex)
//             {
//                 // Handle exceptions appropriately
//                 resData.rData["rMessage"] = "Error: " + ex.Message;
//             }
//             return resData;
//         }

//         public async Task<responseData> DeleteAccount(requestData rData)
//         {
//             responseData resData = new responseData();
//             try
//             {
//                 var email = rData.addInfo["EMAIL"];

//                 // Delete user account
//                 var deleteQuery = @"DELETE FROM mydb.signup WHERE EMAIL=@EMAIL";
//                 MySqlParameter[] deleteParams = new MySqlParameter[]
//                 {
//                     new MySqlParameter("@EMAIL", email)
//                 };
//                 var deleteResult = ds.executeSQL(deleteQuery, deleteParams);
//                 resData.rData["rMessage"] = "Account deleted successfully";
//             }
//             catch (Exception ex)
//             {
//                 // Handle exceptions appropriately
//                 resData.rData["rMessage"] = "Error: " + ex.Message;
//             }
//             return resData;
//         }

//         public async Task<responseData> HandleAuthentication(requestData rData)
//         {
//             if (rData.addInfo["action"].ToString() == "signup")
//             {
//                 return await SignUp(rData);
//             }
//             else if (rData.addInfo["action"].ToString() == "signin")
//             {
//                 return await SignIn(rData);
//             }
//             else if (rData.addInfo["action"].ToString() == "delete")
//             {
//                 return await DeleteAccount(rData);
//             }
//             else
//             {
//                 return new responseData
//                 {
//                     rData = new Dictionary<string, object>
//                     {
//                         ["rMessage"] = "Invalid action"
//                     }
//                 };
//             }
//         }
//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class Authentication
    {
        private readonly dbServices ds = new dbServices();

        public async Task<responseData> SignUp(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var email = rData.addInfo["EMAIL"];
                var password = rData.addInfo["PASSWORD"];
                
                // Check if the email already exists
                var query = @"SELECT * FROM mydb.signup WHERE EMAIL=@EMAIL";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@EMAIL", email)
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Any())
                {
                    resData.rData["rMessage"] = "Email already exists";
                }
                else
                {
                    // Insert new user
                    var insertQuery = @"INSERT INTO mydb.signup (EMAIL, PASSWORD) VALUES (@EMAIL, @PASSWORD)";
                    MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@EMAIL", email),
                        new MySqlParameter("@PASSWORD", password)
                    };
                    var insertResult = ds.executeSQL(insertQuery, insertParams);
                    resData.rData["rMessage"] = "Signup Successful";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                resData.rData["rMessage"] = "Error: " + ex.Message;
            }
            return resData;
        }

        public async Task<responseData> SignIn(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var email = rData.addInfo["EMAIL"];
                var password = rData.addInfo["PASSWORD"];

                // Check if the user exists and the password matches
                var query = @"SELECT * FROM mydb.signup WHERE EMAIL=@EMAIL AND PASSWORD=@PASSWORD";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@EMAIL", email),
                    new MySqlParameter("@PASSWORD", password)
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Any())
                {
                    resData.rData["rMessage"] = "Signin Successful";
                }
                else
                {
                    resData.rData["rMessage"] = "Invalid email or password";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                resData.rData["rMessage"] = "Error: " + ex.Message;
            }
            return resData;
        }

        public async Task<responseData> DeleteAccount(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var email = rData.addInfo["user_id"];

                // Delete user account
                var deleteQuery = @"DELETE FROM mydb.signup WHERE user_id=@user_id";
                MySqlParameter[] deleteParams = new MySqlParameter[]
                {
                    new MySqlParameter("@user_id", email)
                };
                var deleteResult = ds.executeSQL(deleteQuery, deleteParams);
                resData.rData["rMessage"] = "Account deleted successfully";
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                resData.rData["rMessage"] = "Error: " + ex.Message;
            }
            return resData;
        }

        public async Task<responseData> HandleAuthentication(requestData rData)
        {
            if (rData.addInfo["action"].ToString() == "signup")
            {
                return await SignUp(rData);
            }
            else if (rData.addInfo["action"].ToString() == "signin")
            {
                return await SignIn(rData);
            }
            else if (rData.addInfo["action"].ToString() == "delete")
            {
                return await DeleteAccount(rData);
            }
            else
            {
                return new responseData
                {
                    rData = new Dictionary<string, object>
                    {
                        ["rMessage"] = "Invalid action"
                    }
                };
            }
        }
    }
}