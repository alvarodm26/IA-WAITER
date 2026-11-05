# IA-WAITER - SOFTWARE ARCHITECTURE

# 1. VISIÓN GENERAL

IA-WAITER es una plataforma SaaS Multi-Restaurante impulsada por Inteligencia Artificial que permite automatizar el proceso de atención, toma de pedidos, pagos y recomendaciones dentro de restaurantes mediante un asistente virtual accesible a través de códigos QR.

La plataforma está diseñada para operar en múltiples restaurantes y sucursales utilizando una arquitectura moderna, escalable y orientada a microservicios en fases futuras.

---

# 2. OBJETIVOS TÉCNICOS

## Objetivos Principales

- Escalabilidad horizontal.
- Alto rendimiento.
- Alta disponibilidad.
- Seguridad empresarial.
- Arquitectura mantenible.
- Integración con Inteligencia Artificial.
- Preparación para miles de usuarios concurrentes.
- Compatibilidad multidispositivo.

---

# 3. ARQUITECTURA GENERAL

```text
Cliente
    │
    ▼
Cloudflare
    │
    ▼
Frontend (Next.js)
    │
    ▼
Backend API (.NET)
    │
    ├── PostgreSQL
    │
    ├── Redis
    │
    ├── OpenAI
    │
    ├── Sistema de Pagos
    │
    └── Notificaciones
```

---

# 4. ARQUITECTURA DE SOFTWARE

## Patrón Arquitectónico

Se utilizará:

```text
Clean Architecture
```

Separando el sistema en capas independientes.

---

## Capas

### Domain

Contiene:

- Entidades
- Enums
- Reglas de negocio
- Interfaces

Ejemplos:

```text
Restaurant
Product
Order
Customer
Payment
```

---

### Application

Contiene:

- Casos de uso
- CQRS
- Validaciones
- DTOs
- Servicios

Ejemplos:

```text
CreateOrder
UpdateOrderStatus
ProcessPayment
CreateConversation
```

---

### Infrastructure

Contiene:

- Entity Framework Core
- PostgreSQL
- Redis
- OpenAI
- Proveedores externos

---

### API

Contiene:

- Controllers
- Authentication
- Middleware
- Swagger

---

# 5. FRONTEND

## Tecnología Principal

```text
Next.js
```

---

## Lenguaje

```text
TypeScript
```

---

## Librerías

```text
React
Tailwind CSS
Zustand
React Query
React Hook Form
Zod
```

---

## Aplicaciones Frontend

### Customer App

Cliente final.

Funciones:

- Escanear QR
- Menú
- Carrito
- Pedidos
- Pago
- Chat IA

---

### Admin Panel

Administrador del restaurante.

Funciones:

- Productos
- Categorías
- Promociones
- Usuarios
- Reportes

---

### Kitchen Display

Pantalla de cocina.

Funciones:

- Pedidos
- Estado
- Tiempo de preparación
- Alertas

---

# 6. BACKEND

## Tecnología Principal

```text
ASP.NET Core 9
```

---

## ORM

```text
Entity Framework Core
```

---

## Base de Datos

```text
PostgreSQL 18
```

---

## Cache

```text
Redis
```

---

# 7. AUTENTICACIÓN

## Método

```text
JWT Bearer Authentication
```

---

## Flujo

```text
Login
    ↓
JWT Token
    ↓
Frontend
    ↓
API
```

---

## Roles

```text
SuperAdmin
Owner
Manager
Cashier
Kitchen
Waiter
```

---

# 8. SISTEMA DE PERMISOS

## Ejemplos

```text
Products.Read
Products.Create
Products.Update
Products.Delete

Orders.Read
Orders.Update

Payments.Process

Reports.View
```

---

# 9. MULTI-TENANCY

## Estrategia

```text
Shared Database
```

Todos los restaurantes compartirán la misma base de datos.

---

## Aislamiento

Cada tabla incluirá:

```text
RestaurantId
```

para separar la información.

---

# 10. PAGOS

## Integraciones Planeadas

### Perú

```text
Yape
Plin
Niubiz
Izipay
Mercado Pago
```

---

## Estados

```text
Pending
Approved
Rejected
Refunded
```

---

# 11. INTELIGENCIA ARTIFICIAL

## Proveedor Principal

```text
Azure OpenAI
```

---

## Modelos

```text
GPT-5 Mini
GPT-5
```

---

## Responsabilidades

### Atención

Ejemplo:

```text
Quiero una hamburguesa.
```

---

### Recomendaciones

Ejemplo:

```text
También puedo recomendarle papas grandes por S/5 adicionales.
```

---

### Venta Cruzada

Ejemplo:

```text
¿Desea agregar una bebida?
```

---

### Resolución de Preguntas

Ejemplo:

```text
¿Este plato contiene gluten?
```

---

# 12. VOZ

## Proveedor

```text
ElevenLabs
```

---

## Capacidades

```text
Speech To Text
Text To Speech
```

---

# 13. AVATAR VIRTUAL

## Proveedor Inicial

```text
HeyGen
```

---

## Funciones

```text
Sincronización Labial
Expresiones Faciales
Conversación Natural
```

---

# 14. QR DINÁMICO

Cada mesa tendrá un QR único.

Ejemplo:

```text
https://app.ia-waiter.com/table/15
```

---

## Flujo

```text
Escanear QR
      ↓
Abrir Menú
      ↓
Iniciar Conversación
      ↓
Realizar Pedido
      ↓
Pago
```

---

# 15. NOTIFICACIONES

## Canales

```text
Email
Push Notifications
SMS (futuro)
WhatsApp (futuro)
```

---

# 16. AUDITORÍA

Todas las operaciones relevantes serán registradas.

Ejemplos:

```text
Creación de producto
Actualización de pedido
Registro de pago
Inicio de sesión
```

---

# 17. MONITOREO

## Servicios

```text
Application Insights
Serilog
Seq
```

---

## Métricas

```text
Usuarios Activos
Pedidos por Hora
Ventas por Día
Tiempo de Atención
Errores del Sistema
```

---

# 18. SEGURIDAD

## Medidas

```text
HTTPS
TLS 1.3
JWT
Rate Limiting
Cloudflare WAF
Validación de Entradas
Protección CSRF
Protección XSS
Protección SQL Injection
```

---

# 19. INFRAESTRUCTURA

## Cloud Principal

```text
Microsoft Azure
```

---

## Servicios

```text
Azure App Service
Azure Database for PostgreSQL
Azure Redis Cache
Azure OpenAI
Azure Storage
Azure Key Vault
```

---

# 20. ROADMAP TÉCNICO

## Fase 1

MVP

```text
Productos
Categorías
Mesas
QR
Pedidos
```

---

## Fase 2

```text
Pagos
Cocina
Dashboard
```

---

## Fase 3

```text
Chat IA
OpenAI
Recomendaciones
```

---

## Fase 4

```text
Voz
Speech To Text
Text To Speech
```

---

## Fase 5

```text
Avatar Virtual
HeyGen
```

---

## Fase 6

```text
Multiempresa Comercial
Facturación SaaS
Marketplace
```