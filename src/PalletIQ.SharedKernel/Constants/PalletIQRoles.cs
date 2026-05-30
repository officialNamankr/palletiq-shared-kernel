using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Constants
{
    public static class PalletIQRoles
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string TenantAdmin = "TenantAdmin";
        public const string WarehouseManager = "WarehouseManager";
        public const string WarehouseStaff = "WarehouseStaff";
        public const string Viewer = "Viewer";

        public static IReadOnlyList<string> All =
        [
            SuperAdmin, TenantAdmin, WarehouseManager, WarehouseStaff, Viewer
        ];

    }
}
