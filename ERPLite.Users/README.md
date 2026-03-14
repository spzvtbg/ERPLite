# ERPLite – Users Domain

## Project Description
The **Users Domain** manages all system accounts, authentication, and authorization in ERPLite. 
It centralizes identity and role management for all types of system actors (Managers, Employees, Customers).

The domain provides:
- User account management (create, update, deactivate)
- Authentication (login, password verification)
- Authorization (role-based access control)
- Optional linkage to Customer entities for users who act as customers

This domain is designed to be **scalable** and **microservices-ready**, allowing other domains (Orders, Inventory, Customers) to depend on it for identity and access control.

---

## Business Cases

1. **Account Creation**
   - First 2 users are Admins (created by system or via seeding).
   - Admins can create Manager and Employee accounts.
   - Manager can create a new Employee or Customer account.
   - Customer can self-register.

2. **Login / Authentication**
   - Users authenticate via email/username and password.
   - Optionally, support for JWT tokens for API access.

3. **Role Management**
   - Users can have roles: Admin, Manager, Customer.
   - Role determines access level to system resources.

4. **User-to-Customer Association**
   - A Customer User is linked to a single Customer entity.
   - A Manager can be associated with multiple Customers.

5. **Account Updates & Security**
   - Users can update profile information.
   - Password changes and recovery flows supported.

6. **Audit / Logging**
   - Track user creation, login attempts, role changes.

---

## Pending Tasks Checklist

### Basic MVP Tasks
- [x] Define User model with required properties (Username, Email, PasswordHash, Role, CreatedAt)
- [ ] Implement DTOs for User creation and retrieval
- [ ] Create minimal service layer for Users (CRUD operations)
- [ ] Implement basic validation rules (unique email, required fields)
- [ ] Set up UsersController with endpoints for listing, retrieving, and creating users

### Authentication & Authorization Tasks
- [ ] Implement password hashing and verification
- [ ] Design JWT-based authentication flow
- [ ] Implement role-based authorization checks
- [ ] Secure endpoints based on user roles

### Integration / Business Logic Tasks
- [ ] Define relationship between Users and Customers
- [ ] Enforce role-based access for Customer-specific data
- [ ] Plan how other domains (Orders, Inventory) query user roles
- [ ] Prepare for future microservices separation

### Testing & Quality Tasks
- [ ] Unit tests for service layer and controller logic
- [ ] Validation tests for DTOs
- [ ] Authentication and authorization flow tests

### Documentation Tasks
- [ ] Draw domain diagram showing Users, Customers, and Orders relationships
- [ ] Update README with any changes to planned structure
- [ ] Include API examples and response formats

---

This README serves as a **living document**: as development progresses, new tasks can be added or updated. It is suitable to upload to GitHub from day one, even if the code isn’t implemented yet, so collaborators and recruiters can see a clear project plan.