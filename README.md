# 📧 EMailSenderWithSendGrid (.NET 9)

A lightweight and extensible **.NET 9 Web API** for sending transactional emails via **SendGrid**.  
It includes robust **validation** using FluentValidation and structured **logging** via Serilog.

---

## ✨ Features

- ✅ SendGrid API Integration – Easily send emails using the official SendGrid SDK  
- ✅ FluentValidation – Validates request payloads with clear error messages  
- ✅ Serilog – Logs email delivery and errors to both console and a rolling file  
- ✅ Clean Architecture – Organized structure with Controllers, Services, Models, and Validators  
- ✅ API-Ready – Testable and ready for deployment or further extension  

---

## 🛠 Tech Stack

- .NET 9.0 (Preview)  
- ASP.NET Core Web API  
- SendGrid C# SDK  
- Serilog  
- FluentValidation

---

## 🚀 Getting Started

### 1. Clone the Repository

```
git clone https://github.com/miracozal/EMailSenderWithSendGrid.git
cd EMailSenderWithSendGrid
```

### 2. Restore Packages

```
dotnet restore
```

### 3. Configure API Key

Update `appsettings.json` with your SendGrid API key:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "EmailSenderAPIKey": "YOUR_SENDGRID_API_KEY"
}
```

---

## 📬 API Usage

### Endpoint

```
POST /api/email/send-email
```

### Request Body Example

```
{
  "recipient": "user@example.com",
  "subject": "Welcome to our service!",
  "body": "This is a test email.",
  "fromMail": "noreply@yourdomain.com",
  "fromName": "Your App Name"
}
```

### Successful Response

```
200 OK
"Email sending operation was successful."
```

---

## ❌ Validation Example

If the request is invalid, the API returns a 400 response with validation messages:

```
{
  "recipient": "invalid-email",
  "subject": "",
  "body": "",
  "fromMail": "invalid",
  "fromName": ""
}
```

Response:

```
{
  "errors": {
    "Recipient": ["'Recipient' is not a valid email address."],
    "Subject": ["'Subject' must not be empty."],
    "Body": ["'Body' must not be empty."],
    "FromMail": ["'FromMail' is not a valid email address."],
    "FromName": ["'FromName' must not be empty."]
  }
}
```

---

## 📂 Project Structure

```
EMailSenderWithSendGrid/
│
├── Controllers/
│   └── EmailController.cs
│
├── Services/
│   └── EmailService.cs
│
├── Models/
│   └── EmailRequest.cs
│
├── Validators/
│   └── EmailRequestValidator.cs
│
├── logs/
│   └── log.txt
│
├── appsettings.json
└── Program.cs
```

---

## 📊 Logging

All email operations (success/failure) are logged via Serilog:

- Console output  
- File output at: `logs/log.txt` (daily rolling log)

---

## 🧪 Testing Tools

You can test the API using:

- Postman  
- Thunder Client  
- curl (command line)

---

## 🙌 Contributing

Feel free to fork the repository and submit pull requests.  
Suggestions and improvements are welcome!
