# ABC Retail Web Application

## Overview 

The ASP.NET Core MVC web application Abc Retail enables customers to work with Azure Storage 
Services to handle contract files, customer profiles, product photos, and order processing.

## Feautures

- **Submit Product Images**: Azure Blob Storage allows users to submit images.
- **Add Customer Profiles**: Azure Table Storage allows users to add new customer profiles.
- **Process Orders**: To process orders, users can communicate with Azure Queue Storage.
- **Upload Contracts**: Azure File Storage allows users to upload contract files.

## Prerequisites

- **Azure Subscription**: Required to access Azure Storage Services.
- **Azure Storage Account**: Must be configured with Blob, Table, Queue, and File services.
- **ASP.NET Core SDK**: Should be installed on your development machine.
- **Github Repository**: Must push the code to your repository

## Setup and Installation

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/yourusername/ABCretilApp.git
   ```

2. **Configure Azure Storage Connection**:
   Update the `appsettings.json` file with your Azure Storage connection string:

   ```json
   {
     "AzureStorage": {
       "ConnectionString": "YourAzureStorageConnectionStringHere"
     }
   }
   ```
3. **Restore the Dependencies and Build the Project**:

   ```bash
   dotnet restore
   dotnet build
   ```

4. **Run the Application**:

   ```bash
   dotnet run
   ```

5. **Access the Application**:

   Open your web browser and navigate to `https://st10301125-cldv.azurewebsites.net', where you will find my ABC Retail Web Application 
