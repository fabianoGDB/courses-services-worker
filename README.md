# 🛠️ Courses Services Worker

This project is a .NET 6 background service that processes student grade submissions using queue-based messaging, domain-driven validation, and clean architecture principles.

📁 GitHub Repo: [fabianoGDB/courses-services-worker](https://github.com/fabianoGDB/courses-services-worker)

---

## 🧩 Architecture Overview

- **.NET 6 Worker Service** — background execution via `BackgroundService`.
- **Clean Architecture** — separation across Domain, Application, Infrastructure, and Worker layers.
- **Domain-Driven Design (DDD)** — business rules encapsulated in domain entities and services.
- **Chain of Responsibility** — validation logic is modular and extensible.
- **Notification Pattern** — all validation errors are collected in a centralized `NotificationContext`.
- **Queue-Driven Messaging** — message handling via `IQueueClient<T>`, easily mockable and compatible with Amazon SQS or ElasticMQ.

---

## 🚀 How It Works

1. The worker (`GradeServiceWorker`) polls a queue for `SubmitStudentGrade` messages.
2. Each message triggers validation of the `Student`, `Teacher`, and `Subject`.
3. Business rules are applied using a chain of handlers.
4. Validation results are captured in `NotificationContext`.
5. If valid, the message is marked as processed (e.g., removed from the queue).

---

## ⚙️ Technologies Used

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- C# 10
- BackgroundService
- Dependency Injection
- LINQ
- Amazon SQS-compatible queueing (via [ElasticMQ](https://github.com/softwaremill/elasticmq))
- Clean Architecture principles

---

## 🧪 Testing & Development

### 🧾 FakeDbContext

For unit testing and local simulations, `FakeDbContext` includes:

- Pre-seeded students, teachers, and subjects
- In-memory validation without external databases

### 🔁 Queue Mocking

You can use:

- `FakeStudentGradeSubmitClient` — simulates queue messages
- `ElasticMQ` — local SQS-compatible broker

---

## 🐳 Run Locally with ElasticMQ

```bash
docker run -p 9324:9324 softwaremill/elasticmq
In your app, configure the SQS client to point to it:

csharp
Copiar
Editar
var client = new AmazonSQSClient(new BasicAWSCredentials("x", "x"), new AmazonSQSConfig
{
    ServiceURL = "http://localhost:9324"
});
📁 Project Structure
pgsql
Copiar
Editar
Courses.StudentsGradesService.Worker/         → Background service entry point
Courses.StudentsGradesService.Application/    → Validation services, DTOs, and use cases
Courses.StudentsGradesService.Domain/         → Core entities and business rules
Courses.StudentsGradesService.MessageBus/     → Interfaces and implementations for message queues
Courses.StudentsGradesService.IOC/            → Dependency injection configuration
✅ Features
 Validation of student/teacher/subject before grade submission

 Message queue integration (SQS-compatible)

 FakeDbContext for isolated unit tests

 Notification-based error tracking

 Integration with database or reporting service (coming soon)

 API gateway to trigger manual submissions (planned)

📜 License
This project is open-source under the MIT License.

🙌 Author
Made with 💻 by Fabiano Guilherme Dionizio Bortolussi
🔗 GitHub
```
