# Shop Action

## Introduction
ShopAction is my first project to learn ASP.Net Core, docker, podman, Vuejs and angular. It is a small project about ecommerce. This app run on ASP.NET Core, a free, cross-platform and open-source application runtime. It is an online product catalog that customers can browse by category and page, a shopping cart where users can add and remove products, and a checkout where customers can enter their shipping details.

## Technology
- ASP.Net Core 5.0
- Microsoft SQL Server
- Docker
- Angular 10
- MediatR
- AutoMapper
## Overview

### Domain
 This project contain entities, which mapping with database column
### Application
 Contain all business of project. It dependent on domain layer, but independent on any service or another layer.
### Infrastructure
 This service can be used to connect with external service (database, another service, facebook, etc...)
### Web
 Contain all API, define routing, transport data from frontend (such as Postman, swagger, or front end web service, etc...).
