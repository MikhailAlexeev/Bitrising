using System.Collections.Generic;
using Enums;

namespace Statics
{
    public static class AssetsPaths
    {
        public static readonly Dictionary<PlatformType, string> Platforms = new Dictionary<PlatformType, string>
        {
            {PlatformType.Short, "Platforms/Short"},
            {PlatformType.Medium, "Platforms/Medium"},
            {PlatformType.Long, "Platforms/Long"}
        };
        
        public static readonly Dictionary<TrapType, string> Traps = new Dictionary<TrapType, string>
        {
            {TrapType.Spike, "Traps/Spike"},
            {TrapType.Saw, "Traps/Saw"},
        };
    }
}
