using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class food
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Food(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                 var query = @"INSERT INTO mydb.food_data(categories, description, video, video_name) values(@categories, @description, @video, @video_name)";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                     new MySqlParameter("@categories", rData.addInfo["categories"]),
                     new MySqlParameter("@description", rData.addInfo["description"]),
                     new MySqlParameter("@video", rData.addInfo["video"]),
                     new MySqlParameter("@video_name", rData.addInfo["video_name"]),

                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > dbData[0].Count()-1)
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

                resData.rData["rMessage"] = "Add Failed" + ex.Message;
            }
            return resData;
        }

           public async Task<responseData> EditFood(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"UPDATE mydb.food_data SET categories=@categories, description=@description, video=@video, video_name=@video_name WHERE idfood_data=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@categories", rData.addInfo["categories"]),
                    new MySqlParameter("@description", rData.addInfo["description"]),
                    new MySqlParameter("@video", rData.addInfo["video"]),
                    new MySqlParameter("@video_name", rData.addInfo["video_name"]),
                    new MySqlParameter("@id", rData.addInfo["id"])
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

        public async Task<responseData> DeleteFood(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"DELETE FROM mydb.food_data WHERE idfood_data=@id";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                    new MySqlParameter("@id", rData.addInfo["id"])
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