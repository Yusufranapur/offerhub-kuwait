# Deployment Guide

## Infrastructure Architecture

OfferHub Kuwait relies on AWS for production deployments:
- **API**: Amazon ECS (Elastic Container Service) running Fargate tasks.
- **Databases**: Amazon RDS (PostgreSQL) and Amazon ElastiCache (Redis).
- **Web Portals**: Amazon S3 + CloudFront (for both Admin and Vendor portals).
- **Storage**: Amazon S3 (for image/document uploads).
- **Queues/Notifications**: Amazon SQS and SNS.

## CI/CD Pipeline

We use **GitHub Actions** for continuous integration and continuous deployment:
- **CI (`ci.yml`)**: Triggered on pull requests and pushes to `main` and `develop`. Builds and tests both backend and frontend applications.
- **Deploy API (`deploy-api.yml`)**: Builds the Docker image, pushes it to ECR, and updates the ECS service.
- **Deploy Portals (`deploy-admin-portal.yml`, `deploy-vendor-portal.yml`)**: Builds the Vite/React applications, syncs the output to S3, and invalidates the CloudFront cache.

## Local Deployment (Docker Compose)

For local development, we use `docker-compose.yml` to spin up the entire stack.

### Prerequisites
- Docker and Docker Compose
- .NET 7 SDK (Optional, for local builds outside Docker)
- Node.js 18+ (Optional, for local UI dev)

### Starting the Stack
```bash
docker-compose up --build -d
```

### Accessing Services Locally
- API: `http://localhost:5000`
- Vendor Portal: `http://localhost:3000`
- Admin Portal: `http://localhost:3001`
- pgAdmin: `http://localhost:5050`
- LocalStack (AWS Mocks): `http://localhost:4566`
