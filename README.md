# 🚀 ASP.NET Core Authentication API

This is an **ASP.NET Core Web API** project that provides **Basic Authentication** and **JWT Authentication with Refresh Tokens**. It uses **Entity Framework Core** with SQL Server for user management.

## 📌 Features
✅ Basic Authentication (Username & Password)  
✅ JWT Authentication with Refresh Token  
✅ Entity Framework Core (SQL Server)  
✅ Secure API Endpoints  
✅ Swagger UI for API Documentation  

---

## 📂 Folder Structure
/JwtAuthMicroservice <br/>
<ul>
  <li>📁 JwtAuthMicroservice 
    <ul> 
      <li>📁 Controllers
       <ul> 
          <li> AuthController.cs</li>
          <li> ProtectedController.cs</li>
         </ul>
      </li>
      <li>📁 Middleware
        <ul> 
          <li>BasicAuthenticationHandler.cs</li>
         </ul>
        </li>
      <li>📁 Models
        <ul> 
          <li> User.cs</li>
          <li> LoginRequest.cs </li>
          <li> RefreshRequest.cs </li>
        </ul></li>
      <li> 📁 Services
        <ul> 
          <li> AuthService.cs</li>
          <li> TokenService.cs </li>
        </ul>
      <li> 📁 Data
        <ul> 
          <li> ApplicationDbContext.cs </li>
        </ul>
      </li>
      <li> appsettings.json</li>  
      <li> Program.cs</li>
    </ul>
  </li>

<li>JwtAuthMicroservice.csproj</li>
<li>JwtAuthMicroservice.sln</li>
</ul>
