using System;
using System.Linq.Expressions;

namespace Nesco.Upstash.RedisDeveloper
{
    public enum Region
    {
        Global,
        EU_WEST_1,
        EU_CENTRAL_1,
        US_EAST_1,
        US_WEST_1,
        US_WEST_2,
        US_CENTRAL1,
        AP_NORTHEAST_1,
        AP_SOUTHEAST_1,
        AP_SOUTHEAST_2,
        SA_EAST_1
    }

    internal class RegionEndpoints
    {
        internal static string GetRegionString(Region region)
        {
            switch (region)
            {
                case Region.Global:
                    return "global";
                case Region.EU_WEST_1:
                    return "eu-west-1";
                case Region.EU_CENTRAL_1:
                    return "eu-central-1";
                case Region.US_EAST_1:
                    return "us-east-1";
                case Region.US_WEST_1:
                    return "us-west-1";
                case Region.US_WEST_2:
                    return "us-west-2";
                case Region.US_CENTRAL1:
                    return "us-central1";
                case Region.AP_NORTHEAST_1:
                    return "ap-northeast-1";
                case Region.AP_SOUTHEAST_1:
                    return "ap-southeast-1";
                case Region.AP_SOUTHEAST_2:
                    return "ap-southeast-2";
                case Region.SA_EAST_1:
                    return "sa-east-1";
                default:
                    throw new ArgumentException($"selected region endpoint not found");
            }
        }
        internal static Region GetRegion(string regionString)
        {
            switch (regionString)
            {
                case "global":
                    return Region.Global;
                case "eu-west-1":
                    return Region.EU_WEST_1;
                case "eu-central-1":
                    return Region.EU_CENTRAL_1;
                case "us-east-1":
                    return Region.US_EAST_1;
                case "us-west-1":
                    return Region.US_WEST_1;
                case "us-west-2":
                    return Region.US_WEST_2;
                case "us-central1":
                    return Region.US_CENTRAL1;
                case "ap-northeast-1":
                    return Region.AP_NORTHEAST_1;
                case "ap-southeast-1":
                    return Region.AP_SOUTHEAST_1;
                case "ap-southeast-2":
                    return Region.AP_SOUTHEAST_2;
                case "sa-east-1":
                    return Region.SA_EAST_1;
                default:
                    throw new ArgumentException($"selected region endpoint not found");
            }
        }
    }

}
