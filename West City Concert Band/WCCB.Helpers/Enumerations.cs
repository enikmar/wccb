using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCCB.Helpers
{
    public class Enumerations
    {
        public enum PreferredContactTypes
        {
            Email,
            Post,
            Call,
            Txt,
            Facebook
        }

        public enum RoleTypes
        {
            Administrators,
            CommitteeMembers,
            PlayingMembers,
            NonPlayingMembers,
            LifeMembers,
        }

    }
}
