// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using MySql.Data.MySqlClient;

// namespace COMMON_PROJECT_STRUCTURE_API.services
// {
//     public class blog_page
//     {
//         dbServices ds = new dbServices();
//         public async Task<responseData> Blog_page(requestData rData)
//         {
//             responseData resData = new responseData();
//             try
//             {
//                 var query = @"INSERT INTO mydb.blog_data(imageName,image, head, blog_det) values(@imageName,@image, @head, @blog_det)";
//                 MySqlParameter[] myParam = new MySqlParameter[]
//                 {

//                   new MySqlParameter("@imageName", rData.addInfo["imageName"]), 
//                  new MySqlParameter("@image", rData.addInfo["image"]),
//                  new MySqlParameter("@head",rData.addInfo["head"]),
//                      new MySqlParameter("@blog_det", rData.addInfo["blog_det"]),

//                 };
//                 var dbData = ds.executeSQL(query, myParam);
//                 if (dbData[0].Count() > dbData[0].Count()-1)
//                 {
//                     resData.rData["rMessage"] = "ADD SUCCESSFULLY!";
//                 }
//                 else
//                 {
                
//                     resData.rData["rMessage"] = "Something went wrong on server...";

//                 }



//             }
//             catch (Exception ex)
//             {

//                 resData.rData["rMessage"] = "Add Failed" + ex.Message;
//             }
//             return resData;
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
    public class blog_page
    {
        dbServices ds = new dbServices();
        
        public async Task<responseData> Blog_page(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"INSERT INTO mydb.blog_data(imageName, image, head, blog_det) VALUES (@imageName, @image, @head, @blog_det)";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@imageName", rData.addInfo["imageName"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@head", rData.addInfo["head"]),
                    new MySqlParameter("@blog_det", rData.addInfo["blog_det"]),
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > dbData[0].Count() - 1)
                {
                    resData.rData["rMessage"] = "ADD SUCCESSFULLY!";
                }
                else
                {
                    resData.rData["rMessage"] = "Something went wrong on server...";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Add Failed: " + ex.Message;
            }
            return resData;
        }

        public async Task<responseData> EditBlog(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"UPDATE mydb.blog_data SET imageName=@imageName, image=@image, head=@head, blog_det=@blog_det WHERE id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@imageName", rData.addInfo["imageName"]),
                    new MySqlParameter("@image", rData.addInfo["image"]),
                    new MySqlParameter("@head", rData.addInfo["head"]),
                    new MySqlParameter("@blog_det", rData.addInfo["blog_det"]),
                    new MySqlParameter("@id", rData.addInfo["id"]),
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > dbData[0].Count() - 1)
                {
                    resData.rData["rMessage"] = "UPDATE SUCCESSFUL!";
                }
                else
                {
                    resData.rData["rMessage"] = "Update failed.";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Update Failed: " + ex.Message;
            }
            return resData;
        }

        public async Task<responseData> DeleteBlog(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"DELETE FROM mydb.blog_data WHERE id=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@id", rData.addInfo["id"]),
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > dbData[0].Count() - 1)
                {
                    resData.rData["rMessage"] = "DELETE SUCCESSFUL!";
                }
                else
                {
                    resData.rData["rMessage"] = "Delete failed.";
                }
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Delete Failed: " + ex.Message;
            }
            return resData;
        }
    }
}
