# Dynamic Portfolio v3 - Backend

<!-- Badges -->
[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-5C2D91?logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/aspnet/core)
[![Umbraco](https://img.shields.io/badge/Umbraco%20CMS-16-blue?logo=umbraco&logoColor=white)](https://umbraco.com/)
[![Azure SQL](https://img.shields.io/badge/Azure%20SQL-Database-0078D4?logo=microsoftazure&logoColor=white)](https://learn.microsoft.com/en-us/azure/azure-sql/)
[![Azure Blob Storage](https://img.shields.io/badge/Azure%20Blob-Storage-0078D4?logo=microsoftazure&logoColor=white)](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blobs-introduction)


---

## 📖 Intro  

This is my **backend project** for my [Dynamic Portfolio v3 project](https://github.com/filip-io/Portfolio-Umbraco-React). 

It is built with **ASP.NET Core (.NET 9)** and **Umbraco CMS 16**, exposing a **Headless Delivery API** consumed by the frontend. The API is **hosted on Azure as a Web App**, with media stored in **Azure Blob Storage** and content in **Azure SQL Database**.

---

<!-- Tech Stack Banner -->
<p align="center">
  <img src="/github_repo_assets/dotnet.webp" alt="Umbraco Logo" width="20%"><img src="/github_repo_assets/umbraco.webp" alt="Umbraco Logo" width="20%">
</p>

---


## 🛠️ Tech Stack  
 
- 🟣 **Platform:** [ASP.NET Core (.NET 9)](https://dotnet.microsoft.com/)  
- 🧩 **CMS:** [Umbraco CMS 16](https://umbraco.com/)  
- 🔑 **Headless API:** Umbraco Content Delivery API, hosted as **Azure Web App**
- ☁️ **Storage:**  
  - Azure Blob Storage (media + ImageSharp caching)  
  - Azure SQL Database (content & configuration)  
- ⚙️ **Configuration:**  
  - Wide-open **CORS** for local development  
  - Restricted **CORS** for production (only frontend origin)  
- 📦 **Packages:**  
  - `Umbraco.Cms` (core CMS)  
  - `Umbraco.StorageProviders.AzureBlob` (media storage)  
  - `Umbraco.StorageProviders.AzureBlob.ImageSharp` (image cache)  
  - `uSync` (configuration & content sync)  


&nbsp;

## ✨ Features  

- Headless CMS API exposing content for frontend  
- Media files served via **Azure Blob Storage**  
- Content & configuration stored in **Azure SQL Database**  
- Configurable via **Umbraco Backoffice**   


&nbsp;


## 📦 Installation & Setup  

### Backend (ASP.NET Core + Umbraco)
```bash
# clone repo
git clone https://github.com/filip-io/Portfolio-Umbraco-Backend.git
cd Portfolio-Umbraco-Backend

# restore dependencies
dotnet restore

# run locally
dotnet run
```

&nbsp;

## 🏛️ Architecture diagram

```mermaid
flowchart TD
    A[🌐 Umbraco API - .NET 9] <--> B[☁️ Azure SQL Database]
    A <--> C[☁️ Azure Blob Storage]

```