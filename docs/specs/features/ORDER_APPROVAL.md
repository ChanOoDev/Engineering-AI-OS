# ORDER APPROVAL

## Objective

Allow eligible users to submit orders for approval and allow authorized approvers to approve or reject those orders with auditable decisions and clear state transitions.

## Background

Order approval protects high-value or policy-sensitive orders before fulfillment. The workflow must prevent unauthorized approval, duplicate decisions, and invalid state transitions while leaving a durable audit trail.

## Actors

- Requester
- Approver
- Order service
- Notification service
- Audit logging pipeline

## Workflow

1. Requester submits an order that requires approval.
2. System sets the order status to `PendingApproval`.
3. System notifies eligible approvers.
4. Approver reviews order details.
5. Approver approves or rejects the order with an optional comment.
6. System records the decision, updates status, emits an audit event, and notifies the requester.

## Business Rules

- Only orders that meet approval policy enter `PendingApproval`.
- Requesters cannot approve their own orders unless policy explicitly allows it.
- Only authorized approvers can approve or reject.
- Approved orders move to the next fulfillment-ready state.
- Rejected orders must include a reason when policy requires it.
- Decisions are final unless a separate reopen workflow is specified.

## API Changes

Candidate endpoints:

- `POST /api/orders/{orderId}/submit-for-approval`
- `POST /api/orders/{orderId}/approve`
- `POST /api/orders/{orderId}/reject`

All endpoints require authentication and server-side authorization.

## Database Changes

Add or confirm fields for:

- order approval status
- approver id
- approval decision timestamp
- rejection reason or decision comment
- optimistic concurrency token

## UI Changes

- Show pending approval state on order details.
- Show approve and reject actions only to eligible approvers.
- Show decision outcome and safe decision metadata.
- Display validation and authorization failures using standard errors.

## Non-Functional Requirements

- Approval actions must be idempotent or protected by concurrency checks.
- Decision latency should meet normal API targets.
- Notifications should not block final decision persistence.

## Security

- Enforce authorization on the server for every approval action.
- Prevent self-approval unless explicitly allowed by policy.
- Do not expose internal policy details to unauthorized users.
- Audit every approval and rejection decision.

## Logging

Emit structured events:

- `order.approval.requested`
- `order.approval.approved`
- `order.approval.rejected`
- `order.approval.failed`

Include correlation id, order id, actor id, outcome, and failure class. Do not log sensitive order contents unless approved.

## Acceptance Criteria

- Eligible order can be submitted for approval.
- Authorized approver can approve a pending order.
- Authorized approver can reject a pending order.
- Unauthorized users cannot approve or reject.
- Requester self-approval is blocked unless policy allows it.
- Duplicate decisions do not corrupt order state.
- Approval and rejection emit audit events.

## Test Cases

- Unit: approval policy selects orders requiring approval.
- Unit: invalid state transitions are rejected.
- Unit: self-approval policy is enforced.
- Integration: submit order for approval.
- Integration: approve pending order.
- Integration: reject pending order with reason.
- Security: unauthorized approver receives forbidden response.
- Regression: duplicate approve request is idempotent or returns conflict.

## Risks

- Incorrect authorization could allow fraudulent approval.
- Race conditions could produce duplicate or conflicting decisions.
- Notification failure could hide an approval outcome.
- Audit gaps could weaken investigation and compliance.

## Rollback Plan

- Disable approval routing with a feature flag if available.
- Roll back service version if state transitions fail.
- For orders already in `PendingApproval`, provide an operator-reviewed manual resolution path.

## Deployment Notes

- Confirm approver role configuration.
- Confirm audit logging and notification sinks.
- Run smoke tests for submit, approve, reject, and unauthorized approval.
