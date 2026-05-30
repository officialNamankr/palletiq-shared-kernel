using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Results
{
    public record Error(string Code, string Message)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new ("General.Null", "A null value was provided");
        public static readonly Error NotFound = new ("General.NotFound", "The requested resource was not found");
        public static readonly Error Unauthorized = new ("General.Unauthorized", "You are not Unauthorized");
        public static readonly Error Forbidden = new ("General.Forbidden", "You do not have permission to access this resource");
        public static readonly Error Conflict = new ("General.Conflict", "A conflict occurred with the current state of the resource");
        public static readonly Error ValidationFailed = new ("General.ValidationFailed", "One or more validation errors occurred");
        public static readonly Error InternalServerError = new ("General.InternalServerError", "An unexpected error occurred on the server");


        public static readonly Error TenantNotFound = new ("Tenant.NotFound", "The specified tenant was not found");
        public static readonly Error TenantSuspended = new ("Tenant.Suspended", "The tenant is currently suspended");
        public static readonly Error TenantNotResolved = new ("Tenant.NotResolved", "The tenant could not be resolved from the request");


        public static Error Custom(string code, string message) => new(code, message);

        public static Error NotFoundFor (string resource) => new($"{resource}.NotFound", $"{resource} was not found");

        public static Error ConflictFor (string resource) => new($"{resource}.Conflict", $"{resource} already exists");

    }
}
