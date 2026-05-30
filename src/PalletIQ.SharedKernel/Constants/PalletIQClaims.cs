using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Constants
{
    public static class PalletIQClaims
    {
        /// <summary>
        /// Keycloak user id (UUID)
        /// </summary>
        public const string Subject = "sub";

        public const string Email = "email";

        public const string FullName = "name";

        public const string preferredUsername = "preferred_username";

        public const string TenantId = "tenanat_id";
        public const string TenantName = "tenanat_name";
        public const string Plan = "plan";

    }
}
