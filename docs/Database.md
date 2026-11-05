# IA-WAITER - DATABASE DESIGN

## Descripción

Este documento define el modelo de datos principal para la plataforma IA-WAITER.

La plataforma está diseñada como un sistema SaaS Multi-Restaurante con capacidad de crecimiento hacia múltiples sedes, cocina digital, pagos electrónicos, programas de fidelización e inteligencia artificial conversacional.

---

# 1. MULTI TENANT

## Restaurant

```text
Id (UUID)
Name
BusinessName
Ruc
Email
Phone
LogoUrl
SubscriptionPlan
Status
CreatedAt
UpdatedAt
```

## Branch

```text
Id (UUID)
RestaurantId
Name
Address
Phone
Latitude
Longitude
Status
CreatedAt
UpdatedAt
```

---

# 2. GESTIÓN DE MESAS

## Table

```text
Id (UUID)
BranchId
Name
Number
Capacity
QrCode
Status
CreatedAt
UpdatedAt
```

Estados:

```text
Available
Occupied
Reserved
Disabled
```

---

# 3. MENÚ

## Category

```text
Id
RestaurantId
Name
Description
DisplayOrder
Status
CreatedAt
UpdatedAt
```

## Product

```text
Id
CategoryId
Name
Description
Price
ImageUrl
PreparationTimeMinutes
Status
CreatedAt
UpdatedAt
```

## ModifierGroup

Ejemplos:

```text
Extras
Salsas
Bebidas
Acompañamientos
```

Campos:

```text
Id
RestaurantId
Name
Required
MinSelection
MaxSelection
CreatedAt
UpdatedAt
```

## ModifierOption

Ejemplos:

```text
Extra Queso
Extra Carne
Sin Cebolla
Sin Tomate
```

Campos:

```text
Id
ModifierGroupId
Name
Price
Status
CreatedAt
UpdatedAt
```

## ProductModifierGroup

```text
ProductId
ModifierGroupId
```

---

# 4. PEDIDOS

## Order

```text
Id
RestaurantId
BranchId
TableId
OrderNumber
Status
SubTotal
Tax
Discount
Total
CreatedAt
ClosedAt
```

Estados:

```text
Created
Confirmed
Preparing
Ready
Delivered
Paid
Cancelled
```

## OrderItem

```text
Id
OrderId
ProductId
Quantity
UnitPrice
Notes
CreatedAt
```

## OrderItemModifier

```text
Id
OrderItemId
ModifierOptionId
Price
```

---

# 5. PAGOS

## Payment

```text
Id
OrderId
Method
Amount
Status
TransactionId
PaidAt
CreatedAt
```

Métodos:

```text
Cash
Yape
Plin
Visa
Mastercard
MercadoPago
Niubiz
Izipay
```

Estados:

```text
Pending
Approved
Rejected
Refunded
```

## Invoice

```text
Id
OrderId
DocumentType
DocumentNumber
CustomerName
CustomerDocument
SubTotal
Tax
Total
IssuedAt
```

Tipos:

```text
Boleta
Factura
```

---

# 6. COCINA

## KitchenStation

```text
Id
RestaurantId
Name
Description
CreatedAt
```

Ejemplos:

```text
Parrillas
Cocina
Bebidas
Postres
```

## KitchenTicket

```text
Id
OrderId
KitchenStationId
Status
StartTime
ReadyTime
CreatedAt
```

Estados:

```text
Pending
InProgress
Ready
Delivered
```

---

# 7. USUARIOS Y SEGURIDAD

## User

```text
Id
RestaurantId
FirstName
LastName
Email
PasswordHash
Status
CreatedAt
UpdatedAt
```

## Role

```text
Id
Name
Description
```

Roles iniciales:

```text
Owner
Admin
Manager
Cashier
Kitchen
Waiter
```

## UserRole

```text
UserId
RoleId
```

## Permission

```text
Id
Name
Description
```

## RolePermission

```text
RoleId
PermissionId
```

---

# 8. CLIENTES

## Customer

```text
Id
RestaurantId
Name
Phone
Email
CreatedAt
UpdatedAt
```

## CustomerAddress

```text
Id
CustomerId
Address
Reference
Latitude
Longitude
```

---

# 9. PROMOCIONES

## Promotion

```text
Id
RestaurantId
Name
Description
DiscountType
DiscountValue
StartDate
EndDate
Status
```

## Coupon

```text
Id
Code
PromotionId
ExpirationDate
UsageLimit
Status
```

---

# 10. FIDELIZACIÓN

## LoyaltyAccount

```text
Id
CustomerId
CurrentPoints
CreatedAt
```

## LoyaltyTransaction

```text
Id
CustomerId
Points
MovementType
Description
CreatedAt
```

Tipos:

```text
Earn
Redeem
Expire
```

---

# 11. INTELIGENCIA ARTIFICIAL

## Conversation

```text
Id
RestaurantId
TableId
CustomerId
StartedAt
EndedAt
```

## ConversationMessage

```text
Id
ConversationId
Sender
Message
CreatedAt
```

Sender:

```text
User
Assistant
System
```

## AIRecommendation

```text
Id
ConversationId
ProductId
Reason
CreatedAt
```

---

# 12. NOTIFICACIONES

## Notification

```text
Id
RestaurantId
Title
Message
Type
Status
CreatedAt
```

Tipos:

```text
Order
Payment
Promotion
System
```

---

# 13. AUDITORÍA

## AuditLog

```text
Id
UserId
EntityName
EntityId
Action
OldValues
NewValues
CreatedAt
```

Acciones:

```text
Create
Update
Delete
Login
Logout
```

---

# 14. CONFIGURACIÓN

## RestaurantSetting

```text
Id
RestaurantId
SettingKey
SettingValue
```

Ejemplos:

```text
TaxPercentage
Currency
TimeZone
Language
OpeningTime
ClosingTime
```

---

# TECNOLOGÍAS DE BASE DE DATOS

Motor:

```text
PostgreSQL 18
```

ORM:

```text
Entity Framework Core
```

Cache:

```text
Redis
```

Identificadores:

```text
UUID
```

Estrategia de Eliminación:

```text
Soft Delete
```

Campos estándar para todas las entidades:

```text
CreatedAt
UpdatedAt
DeletedAt
CreatedBy
UpdatedBy
```