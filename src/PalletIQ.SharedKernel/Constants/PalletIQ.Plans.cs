using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.Constants
{
    public static class PalletIQPlans
    {
        public const string Free = "Free";
        public const string Pro = "Pro";
        public const string Enterprise = "Enterprise";
    }

    public static readonly IReadonlyList<string> All = [Free, Pro, Enterprise];
	}
