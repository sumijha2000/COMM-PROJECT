
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using COMMON_PROJECT_STRUCTURE_API.services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;

WebHost.CreateDefaultBuilder().
ConfigureServices(s=>
{
    IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    s.AddSingleton<login>();
    s.AddSingleton<Authentication>();
    s.AddSingleton<contact>();
    s.AddSingleton<uploader>();
    s.AddSingleton<inventions_page>();
    s.AddSingleton<getallinventions_details>();
    s.AddSingleton<getinventions_detailsbyid>();
    s.AddSingleton<inventor_page>();
    s.AddSingleton<getallinventor_details>();
    s.AddSingleton<getinventor_detailsbyid>();
    s.AddSingleton<blog_page>();
    s.AddSingleton<getallblog_details>();
    s.AddSingleton<getblog_detailsbyid>();
    s.AddSingleton<getblog_detailsbyid>();
    s.AddSingleton<communication>();
    s.AddSingleton<culture>();
    s.AddSingleton<health>();
    s.AddSingleton<food>();
    s.AddSingleton<fashion>();
    s.AddSingleton<transportation>();
    s.AddSingleton<tech>();
    s.AddSingleton<sports>();
    s.AddSingleton<science>();
    s.AddSingleton<politics>();
    s.AddSingleton<medicine>();
    s.AddSingleton<environment>();
    s.AddSingleton<getCommunicationInfo>();
    s.AddSingleton<getCommInfoById>();
    s.AddSingleton<getCultureInfoById>();
    s.AddSingleton<getEnvById>();
    s.AddSingleton<getFashionById>();
    s.AddSingleton<getFoodById>();
    s.AddSingleton<getHealthById>();
    s.AddSingleton<getPoliticsById>();
    s.AddSingleton<getScienceById>();
    s.AddSingleton<getSportsById>();
    s.AddSingleton<getTechById>();
    s.AddSingleton<getTransById>();
    s.AddSingleton<getMedById>();
    s.AddSingleton<getCultureInfo>();
    s.AddSingleton<getEnvInfo>();
    s.AddSingleton<getFesInfo>();
    s.AddSingleton<getFoodInfo>();
    s.AddSingleton<getHealthInfo>();
    s.AddSingleton<getMedInfo>();
    s.AddSingleton<getPoliticInfo>();
    s.AddSingleton<getScienceInfo>();
    s.AddSingleton<getSportInfo>();
    s.AddSingleton<getTechInfo>();
    s.AddSingleton<getTransInfo>();
    s.AddSingleton<getSignupInfo>();
    s.AddSingleton<getUploderData>();
    s.AddSingleton<getUploaderDataForAdmin>();
    s.AddSingleton<getContactInfo>();
    s.AddSingleton<getBlogInfo>();
    s.AddSingleton<AdminLoginService>();
   
   
    
   
// s.AddAuthorization();
// s.AddControllers();
// s.AddCors();
// s.AddAuthentication("SourceJWT").AddScheme<SourceJwtAuthenticationSchemeOptions, SourceJwtAuthenticationHandler>("SourceJWT", options =>
//     {
//         options.SecretKey = appsettings["jwt_config:Key"].ToString();
//         options.ValidIssuer = appsettings["jwt_config:Issuer"].ToString();
//         options.ValidAudience = appsettings["jwt_config:Audience"].ToString();
//         options.Subject = appsettings["jwt_config:Subject"].ToString();
//     });
// }).Configure(app=>
// {
// app.UseAuthentication();
// app.UseAuthorization();

//  app.UseCors(options =>
//          options.WithOrigins("https://localhost:5002", "http://localhost:5001")
//          .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
// app.UseRouting();
// app.UseStaticFiles();
  s.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:5164","http://localhost:5173", "http://localhost:5174") // Change this to match your frontend URL
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });

        // Add authentication
        s.AddAuthentication("SourceJWT").AddScheme<SourceJwtAuthenticationSchemeOptions, SourceJwtAuthenticationHandler>("SourceJWT", options =>
        {
            options.SecretKey = appsettings["jwt_config:Key"].ToString();
            options.ValidIssuer = appsettings["jwt_config:Issuer"].ToString();
            options.ValidAudience = appsettings["jwt_config:Audience"].ToString();
            options.Subject = appsettings["jwt_config:Subject"].ToString();
        });

        // Add authorization
        s.AddAuthorization();

        // Add controllers
        s.AddControllers();
    })
    .Configure(app =>
    {
        app.UseRouting();

        // Use CORS
        app.UseCors("AllowSpecificOrigins");

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();


app.UseEndpoints(e=>
{
           var login=  e.ServiceProvider.GetRequiredService<login>();
     
           var auth = e.ServiceProvider.GetRequiredService<Authentication>();
           var getSignupInfo = e.ServiceProvider.GetRequiredService<getSignupInfo>();
           var contact = e.ServiceProvider.GetRequiredService<contact>();
           var getContactInfo = e.ServiceProvider.GetRequiredService<getContactInfo>();
           var uploader = e.ServiceProvider.GetRequiredService<uploader>();
           var inventions_page = e.ServiceProvider.GetRequiredService<inventions_page>();
           var getallinventions_details = e.ServiceProvider.GetRequiredService<getallinventions_details>();
           var getinventions_detailsbyid = e.ServiceProvider.GetRequiredService<getinventions_detailsbyid>();
           var inventor_page = e.ServiceProvider.GetRequiredService<inventor_page>();
           var getallinventor_details = e.ServiceProvider.GetRequiredService<getallinventor_details>();
           var getinventor_detailsbyid = e.ServiceProvider.GetRequiredService<getinventor_detailsbyid>();
           var blog_page = e.ServiceProvider.GetRequiredService<blog_page>();
           var getBlogInfo = e.ServiceProvider.GetRequiredService<getBlogInfo>();
           var getallblog_details = e.ServiceProvider.GetRequiredService<getallblog_details>();
           var getblog_detailsbyid = e.ServiceProvider.GetRequiredService<getblog_detailsbyid>();
           var communication = e.ServiceProvider.GetRequiredService<communication>();
           var culture = e.ServiceProvider.GetRequiredService<culture>();
           var health = e.ServiceProvider.GetRequiredService<health>();
           var food = e.ServiceProvider.GetRequiredService<food>();
           var fashion = e.ServiceProvider.GetRequiredService<fashion>();
           var transportation = e.ServiceProvider.GetRequiredService<transportation>();
           var tech = e.ServiceProvider.GetRequiredService<tech>();
           var sports = e.ServiceProvider.GetRequiredService<sports>();
           var science = e.ServiceProvider.GetRequiredService<science>();
           var politics = e.ServiceProvider.GetRequiredService<politics>();
           var medicine = e.ServiceProvider.GetRequiredService<medicine>();
           var environment = e.ServiceProvider.GetRequiredService<environment>();
           var getCommunicationInfo = e.ServiceProvider.GetRequiredService<getCommunicationInfo>();
           var getCommInfoById = e.ServiceProvider.GetRequiredService<getCommInfoById>();
           var getCultureInfoById = e.ServiceProvider.GetRequiredService<getCultureInfoById>();
           var getEnvById = e.ServiceProvider.GetRequiredService<getEnvById>();
           var getFashionById = e.ServiceProvider.GetRequiredService<getFashionById>();
           var getFoodById = e.ServiceProvider.GetRequiredService<getFoodById>();
           var getHealthById = e.ServiceProvider.GetRequiredService<getHealthById>();
           var getPoliticsById = e.ServiceProvider.GetRequiredService<getPoliticsById>();
           var getScienceById = e.ServiceProvider.GetRequiredService<getScienceById>();
           var getSportsById = e.ServiceProvider.GetRequiredService<getSportsById>();
           var getTechById = e.ServiceProvider.GetRequiredService<getTechById>();
           var getTransById = e.ServiceProvider.GetRequiredService<getTransById>();
           var getMedById = e.ServiceProvider.GetRequiredService<getMedById>();
           var getCultureInfo = e.ServiceProvider.GetRequiredService<getCultureInfo>();
           var getEnvInfo = e.ServiceProvider.GetRequiredService<getEnvInfo>();
           var getFesInfo = e.ServiceProvider.GetRequiredService<getFesInfo>();
           var getFoodInfo = e.ServiceProvider.GetRequiredService<getFoodInfo>();
           var getHealthInfo = e.ServiceProvider.GetRequiredService<getHealthInfo>();
           var getMedInfo = e.ServiceProvider.GetRequiredService<getMedInfo>();
           var getPoliticInfo = e.ServiceProvider.GetRequiredService<getPoliticInfo>();
           var getScienceInfo = e.ServiceProvider.GetRequiredService<getScienceInfo>();
           var getSportInfo = e.ServiceProvider.GetRequiredService<getSportInfo>();
           var getTechInfo = e.ServiceProvider.GetRequiredService<getTechInfo>();
           var getTransInfo = e.ServiceProvider.GetRequiredService<getTransInfo>();
           var getUploderData = e.ServiceProvider.GetRequiredService<getUploderData>();
           var getUploaderDataForAdmin = e.ServiceProvider.GetRequiredService<getUploaderDataForAdmin>();
            var adminLoginService = e.ServiceProvider.GetRequiredService<AdminLoginService>();
       
            
          

         
          
        e.MapPost("login",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await login.Login(rData));

         });


                
         e.MapPost("authenticate",
        [AllowAnonymous] async (HttpContext http) =>
        {
            var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
            var rData = JsonSerializer.Deserialize<requestData>(body);
            var result = await auth.HandleAuthentication(rData);
            await http.Response.WriteAsJsonAsync(result);
        });

      e.MapPost("deleteAccount",
    [AllowAnonymous] async (HttpContext http) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        rData.addInfo["action"] = "delete"; // Ensure the action is set to delete
        var result = await auth.HandleAuthentication(rData);
        await http.Response.WriteAsJsonAsync(result);
    });


           e.MapPost("getSignupInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getSignupInfo.GetSignupInfo(rData));

         });

         
          e.MapPost("contact",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await contact.Contact(rData));

         });
      e.MapPost("/contact/deleteContact",
    [AllowAnonymous] async (HttpContext http) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await new contact().DeleteContact(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

        

          e.MapPost("getContactInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getContactInfo.GetContactInfo(rData));

         });
         
          e.MapPost("uploader",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await uploader.Uploader(rData));

         });

         e.MapPost("/uploader/editUploader",
    [AllowAnonymous] async (HttpContext http, uploader up) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await up.EditUploader(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/uploader/deleteUploader",
    [AllowAnonymous] async (HttpContext http, uploader up) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await up.DeleteUploader(rData);
        await http.Response.WriteAsJsonAsync(result);
    });
     e.MapPost("getuserdatabycontact",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await uploader.GetUserDataByContact(rData));

         });

      


           e.MapPost("inventions_page",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await inventions_page.Inventions_page(rData));

         });


         e.MapPost("/inventions/editInvention", 
    [AllowAnonymous] async (HttpContext http, inventions_page inv) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await inv.EditInvention(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/inventions/deleteInvention", 
    [AllowAnonymous] async (HttpContext http, inventions_page inv) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await inv.DeleteInvention(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         e.MapPost("getallinventions_details",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getallinventions_details.Getallinventions_details(rData));

         });
          e.MapPost("getinventions_detailsbyid",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getinventions_detailsbyid.Getinventions_detailsbyid(rData));

         });
         e.MapPost("inventor_page",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await inventor_page.Inventor_page(rData));

         });
         e.MapPost("/inventor/editInventor", 
    [AllowAnonymous] async (HttpContext http, inventor_page inv) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await inv.EditInventor(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/inventor/deleteInventor", 
    [AllowAnonymous] async (HttpContext http, inventor_page inv) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await inv.DeleteInventor(rData);
        await http.Response.WriteAsJsonAsync(result);
    });


          e.MapPost("getallinventor_details",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getallinventor_details.Getallinventor_details(rData));

         });
          e.MapPost("getinventor_detailsbyid",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getinventor_detailsbyid.Getinventor_detailsbyid(rData));

         });
          

          e.MapPost("blog_page",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await blog_page. Blog_page(rData));

         });

            e.MapPost("/blog/editBlog", 
    [AllowAnonymous] async (HttpContext http, blog_page bp) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await bp.EditBlog(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

       e.MapPost("/blog/deleteBlog", 
    [AllowAnonymous] async (HttpContext http, blog_page bp) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await bp.DeleteBlog(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

          e.MapPost("getBlogInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getBlogInfo. GetBlogInfo(rData));

         });

           e.MapPost("getallblog_details",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getallblog_details.Getallblog_details(rData));

         });

           e.MapPost("getblog_detailsbyid",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getblog_detailsbyid.Getblog_detailsbyid(rData));

         });
          e.MapPost("communication",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await communication.Communication(rData));

         });

         e.MapPost("/communication/editCommunication",
    [AllowAnonymous] async (HttpContext http, communication cm) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await cm.EditCommunication(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/communication/deleteCommunication",
    [AllowAnonymous] async (HttpContext http, communication cm) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await cm.DeleteCommunication(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

           e.MapPost("getCommunicationInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getCommunicationInfo.GetCommunicationInfo(rData));

         });

           e.MapPost("getCommInfoById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getCommInfoById.GetCommInfoById(rData));

         });



         e.MapPost("culture",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await culture.Culture(rData));

         });

         e.MapPost("/culture/editCulture",
    [AllowAnonymous] async (HttpContext http, culture cl) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await cl.EditCulture(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/culture/deleteCulture",
    [AllowAnonymous] async (HttpContext http, culture cl) =>
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await cl.DeleteCulture(rData);
        await http.Response.WriteAsJsonAsync(result);
    });
         e.MapPost("getCultureInfoById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getCultureInfoById.GetCultureInfoById(rData));

         });

          e.MapPost("getCultureInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getCultureInfo.GetCultureInfo(rData));

         });

         e.MapPost("health",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await health.Health(rData));

         });


         e.MapPost("/health/editHealth", 
    [AllowAnonymous] async (HttpContext http, health hlth) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await hlth.EditHealth(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/health/deleteHealth", 
    [AllowAnonymous] async (HttpContext http, health hlth) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await hlth.DeleteHealth(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         e.MapPost("getHealthById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getHealthById.GetHealthById(rData));

         });

         e.MapPost("getHealthInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getHealthInfo.GetHealthInfo(rData));

         });

         e.MapPost("food",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await food.Food(rData));

         });
         e.MapPost("/food/editFood", 
    [AllowAnonymous] async (HttpContext http, food fd) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await fd.EditFood(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/food/deleteFood", 
    [AllowAnonymous] async (HttpContext http, food fd) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await fd.DeleteFood(rData);
        await http.Response.WriteAsJsonAsync(result);
    });


         e.MapPost("getFoodById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getFoodById.GetFoodById(rData));

         });

          e.MapPost("getFoodInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getFoodInfo.GetFoodInfo(rData));

         });


         e.MapPost("fashion",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await fashion.Fashion(rData));

         });

         e.MapPost("/fashion/editFashion", 
    [AllowAnonymous] async (HttpContext http, fashion fsh) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await fsh.EditFashion(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/fashion/deleteFashion", 
    [AllowAnonymous] async (HttpContext http, fashion fsh) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await fsh.DeleteFashion(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         
         e.MapPost("getFashionById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getFashionById.GetFashionById(rData));

         });

         e.MapPost("getFesInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getFesInfo.GetFesInfo(rData));

         });

         e.MapPost("transportation",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await transportation.Transportation(rData));

         });

         
         
         e.MapPost("getTransById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getTransById.GetTransById(rData));

         });

         e.MapPost("/transportation/editTransportation", 
    [AllowAnonymous] async (HttpContext http, transportation tc) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await tc.EditTransportation(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/transportation/deleteTransportation", 
    [AllowAnonymous] async (HttpContext http, transportation tc) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await tc.DeleteTransportation(rData);
        await http.Response.WriteAsJsonAsync(result);
    });



          e.MapPost("getTransInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getTransInfo.GetTransInfo(rData));

         });

         e.MapPost("tech",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await tech.Tech(rData));

         });

         e.MapPost("/tech/editTech", 
    [AllowAnonymous] async (HttpContext http, tech tc) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await tc.EditTech(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/tech/deleteTech", 
    [AllowAnonymous] async (HttpContext http, tech tc) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await tc.DeleteTech(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         
         e.MapPost("getTechById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getTechById.GetTechById(rData));

         });

          e.MapPost("getTechInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getTechInfo.GetTechInfo(rData));

         });

         e.MapPost("sports",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await sports.Sports(rData));

         });

         e.MapPost("/sports/editSports", 
    [AllowAnonymous] async (HttpContext http, sports sp) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await sp.EditSports(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/sports/deleteSports", 
    [AllowAnonymous] async (HttpContext http, sports sp) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await sp.DeleteSports(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         
         e.MapPost("getSportsById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getSportsById.GetSportsById(rData));

         });

          e.MapPost("getSportInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getSportInfo.GetSportInfo(rData));

         });

         e.MapPost("science",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await science.Science(rData));

         });

         e.MapPost("/science/editScience", 
    [AllowAnonymous] async (HttpContext http, science sci) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await sci.EditScience(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/science/deleteScience", 
    [AllowAnonymous] async (HttpContext http, science sci) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await sci.DeleteScience(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         
         e.MapPost("getScienceById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getScienceById.GetScienceById(rData));

         });

         e.MapPost("getScienceInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getScienceInfo.GetScienceInfo(rData));

         });


         e.MapPost("politics",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await politics.Politics(rData));

         });

         e.MapPost("/politics/editPolitics", 
    [AllowAnonymous] async (HttpContext http, politics pol) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await pol.EditPolitics(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/politics/deletePolitics", 
    [AllowAnonymous] async (HttpContext http, politics pol) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await pol.DeletePolitics(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

         e.MapPost("getPoliticsById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getPoliticsById.GetPoliticsById(rData));

         });

         e.MapPost("getPoliticInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getPoliticInfo.GetPoliticInfo(rData));

         });
         

         e.MapPost("medicine",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await medicine.Medicine(rData));

         });

         e.MapPost("/medicine/editMedicine", 
    [AllowAnonymous] async (HttpContext http, medicine med) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await med.EditMedicine(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/medicine/deleteMedicine", 
    [AllowAnonymous] async (HttpContext http, medicine med) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await med.DeleteMedicine(rData);
        await http.Response.WriteAsJsonAsync(result);
    });


         
         e.MapPost("getMedById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getMedById.GetMedById(rData));

         });

         e.MapPost("getMedInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getMedInfo.GetMedInfo(rData));

         });

         e.MapPost("environment",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await environment.Environment(rData));

         });

         e.MapPost("/environment/editEnvironment", 
    [AllowAnonymous] async (HttpContext http, environment env) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await env.EditEnvironment(rData);
        await http.Response.WriteAsJsonAsync(result);
    });

e.MapPost("/environment/deleteEnvironment", 
    [AllowAnonymous] async (HttpContext http, environment env) => 
    {
        var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
        var rData = JsonSerializer.Deserialize<requestData>(body);
        var result = await env.DeleteEnvironment(rData);
        await http.Response.WriteAsJsonAsync(result);
    });
         e.MapPost("getEnvById",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getEnvById.GetEnvById(rData));

         });

          e.MapPost("getEnvInfo",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getEnvInfo.GetEnvInfo(rData));

         });
          e.MapPost("getUploderData",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getUploderData.GetUploderData(rData));

         });
          e.MapPost("getUploaderDataForAdmin",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await getUploaderDataForAdmin.GetUploaderDataForAdmin(rData));

         });


       
           e.MapPost("admin/login",
        async context =>
        {
            try
            {
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                var loginRequest = JsonSerializer.Deserialize<LoginRequest>(body);

                var token = await adminLoginService.Authenticate(loginRequest.Username, loginRequest.Password);

                if (token == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid credentials.");
                    return;
                }

                await context.Response.WriteAsJsonAsync(new { token });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"An error occurred: {ex.Message}");
            }
        });


           e.MapPost("admin/logout",
                async context =>
                {
                    await context.Response.WriteAsync("Logged out successfully.");
                });




        IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
 e.MapGet("/dbstring",
               async c =>
               {
                   dbServices dspoly = new dbServices();
                   await c.Response.WriteAsJsonAsync("{'mongoDatabase':" + appsettings["mongodb:connStr"] + "," + " " + "MYSQLDatabase" + " =>" + appsettings["db:connStrPrimary"]);
               });

          e.MapGet("/bing",
                async c => await c.Response.WriteAsJsonAsync("{'Name':'Anish','Age':'26','Project':'COMMON_PROJECT_STRUCTURE_API'}"));
});
}).Build().Run();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
public record requestData
{
    [Required]
    public string eventID { get; set; }
    [Required]
    public IDictionary<string, object> addInfo { get; set; }
}

public record responseData
{
    public responseData()
    {
        eventID = "";
        rStatus = 0;
        rData = new Dictionary<string, object>();
    }
    [Required]
    public int rStatus { get; set; } = 0;
    public string eventID { get; set; }
    public IDictionary<string, object> addInfo { get; set; }
    public IDictionary<string, object> rData { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}