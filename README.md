# Email Service 🚀

A **resilient Email Service** built in **.NET 9 (C#)** using **Clean Architecture (DDD)** principles.  
This project implements a **failover strategy** with [Polly](https://www.nuget.org/packages/polly/), ensuring high reliability when sending emails by automatically switching between **SendGrid** and **Mailgun** if one provider fails.  

---

## ✨ Features

- ✅ Built with **.NET 9** and **C#**  
- ✅ **Clean Architecture (DDD)** structure  
- ✅ **Failover with Polly** (resilience & retries)  
- ✅ **Infrastructure Layer** with **SendGrid** and **Mailgun**  
- ✅ Configurable via `.env` file  
- ✅ Ready for **free test accounts** in both providers  

---

## 📂 Project Structure

```bash
EmailService
├── Application       # Use cases & business rules
├── Domain            # Entities & core logic
├── Infrastructure    # SendGrid & Mailgun implementations
├── API               # Presentation layer
└── .env              # Environment configuration

````


## ⚙️ Environment Configuration

The project uses a `.env` file to store credentials. Example:  

```env
# SENDGRID
SEND-GRID-API-KEY=
SEND-GRID-EMAIL-ADDRESS=
SEND-GRID-EMAIL-NAME=

# MAILGUN
MALIGUN-API-KEY=
MALIGUN-EMAIL-ADDRESS=
MALIGUN-URL=
MALIGUN-SANDBOX-DOMAIN=
````

## 🔄 Failover Strategy

This service uses **Polly** to handle transient failures and fallback logic:  

1. **SendGrid** is attempted first.  
2. If SendGrid fails, **Mailgun** is automatically used as a backup.  

This guarantees maximum reliability when sending emails.  

---

## 🧪 Getting Free Test Accounts

### 1. SendGrid (Free Plan)

1. Go to [SendGrid Signup](https://signup.sendgrid.com/)  
2. Create a **free account** (no credit card required).  
3. Verify your email & phone.  
4. Create an **API Key** under **Settings > API Keys**.  
   - Choose **Full Access** or restrict to **Mail Send**.  
5. Add the key to your `.env`:

```env
SEND-GRID-API-KEY=your_api_key_here
SEND-GRID-EMAIL-ADDRESS=your_verified_sender@example.com
SEND-GRID-EMAIL-NAME=Your App Name
````
6. Before sending emails, you must verify a sender domain or use a single sender (e.g. Gmail or company email).

### SendGrid – Free Account Setup
1. Go to [SendGrid Free Tier](https://signup.sendgrid.com/) and create a free account.
2. Verify your email and log in.
3. Navigate to **Settings > Sender Authentication**.
   - Option A: Verify a domain (recommended for production).
   - Option B: Verify a **Single Sender** for quick testing.
4. Generate an **API Key**:
   - Go to **Settings > API Keys**.
   - Create an API Key with `Full Access` or at least `Mail Send`.
   - Copy and paste it into your `.env` file under `SEND-GRID-API-KEY`.

Free Tier includes **100 emails/day**.

---

### Mailgun – Free Account Setup
1. Go to [Mailgun Free Trial](https://signup.mailgun.com/new/signup) and create an account.
2. Confirm your email and phone number.
3. You will receive a **sandbox domain** (e.g. `sandboxXXX.mailgun.org`).
4. Add this to your `.env` file as `MALIGUN-SANDBOX-DOMAIN`.
5. Generate an **API Key** in **API Security**.
6. Add the key to your `.env` as `MALIGUN-API-KEY`.

⚠️ Note: In sandbox mode, you must add authorized recipients before sending emails.  
To remove this restriction, upgrade to a paid plan and verify your own domain.

---

## ▶️ Running the Project

```bash
dotnet build
dotnet run --project EmailService.Presentation
````

The API will start and expose endpoints to send emails using the failover strategy.

---

## ✅ Example API Request

### Using HTTP Client (e.g., Postman or Insomnia)
`POST /api/email/send`

**Body:**
```json
{
  "to": "test@example.com",
  "subject": "Hello World",
  "body": "<h1>This is a test email</h1>"
}
````

If SendGrid fails, Polly will retry and automatically fall back to Mailgun.

````curl
curl -X POST http://localhost:5000/api/email/send \
  -H "Content-Type: application/json" \
  -d '{
    "to": "test@example.com",
    "subject": "Hello World",
    "body": "<h1>This is a test email</h1>"
  }'
````
