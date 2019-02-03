using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Task07.Entities
{
    public class AwardUser : IEquatable<AwardUser>
    {
        public int UserId { get; set; }
        public int AwardId { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AwardUser);
        }

        public bool Equals(AwardUser awardUser)
        {
            if (ReferenceEquals(awardUser, null))
            {
                return false;
            }

            if (ReferenceEquals(this, awardUser))
            {
                return true;
            }

            if (this.GetType() != awardUser.GetType())
            {
                return false;
            }

            return (this.UserId == awardUser.UserId) && (this.AwardId == awardUser.AwardId);
        }

        public override int GetHashCode()
        {
            int hash = 1488;
            hash = (hash * 228) + UserId.GetHashCode();
            hash = (hash * 228) + AwardId.GetHashCode();
            return hash;
        }

        public static bool operator ==(AwardUser leftObj, AwardUser rightObj)
        {
            if (ReferenceEquals(leftObj, null))
            {
                if (ReferenceEquals(leftObj, null))
                {
                    return true;
                }

                return false;
            }

            return leftObj.Equals(rightObj);
        }

        public static bool operator !=(AwardUser leftObj, AwardUser rightObj)
        {
            return !(leftObj == rightObj);
        }
    }

    
}
