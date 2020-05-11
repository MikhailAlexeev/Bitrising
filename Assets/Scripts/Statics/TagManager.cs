using System.Collections.Generic;

namespace Statics
{
    public static class TagManager
    {
        private static readonly Dictionary<TagType, string> Tags = new Dictionary<TagType, string>()
        {
            {TagType.Player, "Player"},
            {TagType.Enemy, "Enemy"},
            {TagType.DeathZone, "DeathZone"},
        };

        public static string GetTag(TagType type)
        {
            return Tags[type];
        }
    }
    
    
    
}