# Unifrik Backend Platform

Unifrik is a multi-currency, multilingual trade platform designed to power seamless, trusted commerce across Africa. This backend project implements core services such as user authentication, product listings, wallet and payments, KYC verification, and messaging.

This repository is part of a larger ecosystem aimed at simplifying cross-border African trade through localized pricing, verified identity, and direct buyer-seller-logistics interactions.

## Project Status

This project is in active development and is currently at the Minimum Viable Product (MVP) phase.

The following services are in progress:
- Authentication and Identity Management
- KYC Verification and Badge Assignment
- Product Listings
- Wallet and Currency Conversion
- Order Processing

More modules including messaging, real-time notifications, and logistics tracking will be added incrementally.

Expect frequent changes as implementation progresses.

## Project Goals

- Enable verified, borderless eCommerce within Africa
- Handle multiple currencies and languages automatically
- Build trust with KYC verification and role-based access
- Support modular, scalable microservice-based architecture
- Provide open-source reference for scalable .NET backend systems

## Architecture Overview

The system follows a domain-aligned microservice architecture behind an API Gateway.

```text
Clients (Web / Mobile)
        ↓
API Gateway (YARP)
        ↓
Microservices (Auth, Listings, KYC, Wallet, Orders, Messaging)
        ↓
RabbitMQ (async events)  ←→  Background Workers
        ↓
PostgreSQL | MongoDB | Redis | MinIO

Each service is independently deployable and communicates via REST or asynchronous events using RabbitMQ.

```
## Technology Stack

- .NET 8 for backend services
- YARP for API Gateway
- PostgreSQL and MongoDB for data storage
- Redis for caching and token management
- RabbitMQ for event-driven communication
- MinIO for secure file storage (e.g. ID documents)
- Docker and Docker Compose for development orchestration
- GitHub Actions for CI

## Core Services

- **Authentication Service**: Handles registration, login, token issuing, and role management.
- **KYC Service**: Enables document upload, verification workflows, and trust badge assignment.
- **Listings Service**: Allows sellers to post multilingual, multi-currency product listings.
- **Wallet Service**: Manages role-based balances and transactions with escrow support.
- **Orders Service**: Supports order creation, tracking, fulfillment, and delivery confirmation.
- **Translation Service**: Integrates with external APIs to localize user-generated content.
- **Currency Service**: Detects and caches exchange rates for localized price display.

## Getting Started (Local Development)

### Prerequisites
- .NET 8 SDK
- Docker
- Git

### Running with Docker Compose

Clone the repository and run:

```bash
docker-compose up --build
```
Services will be accessible through the API Gateway at http://localhost:5000.

Note: Each service may require its own configuration and .env file. See individual folders for details.

## Development Roadmap (MVP Phase)

1. Authentication and Identity
2. KYC Document Upload and Badge Workflow
3. Listings with Multilingual Support
4. Wallet and Currency Modules
5. Order Escrow and Fulfillment
6. Real-Time Messaging and Notifications
7. Admin Interfaces and Monitoring Tools

## Contributing

This is an open-source project under active development. Contributions are welcome.

To contribute:
1. Fork the repo
2. Create a feature branch
3. Submit a pull request

Before submitting, ensure your code is formatted and unit-tested where applicable.

## License

This project is licensed under the MIT License. You are free to use, copy, and modify it for personal or commercial projects with proper attribution.

## Contact

Maintained by Hope Odomene.

For professional inquiries, collaboration, or feedback, please reach out via:

- GitHub: https://github.com/simplexhopee
- Email: simplehopee@yahoo.com
- LinkedIn: https://www.linkedin.com/in/hope-odomene-3b251471/

