using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
 public class EntitiesConstants
    {
        public class AuctionUser
        {
            public const int FullNameMaxLength = 50;
        }

        public class Category
        {
            public const int NameMaxLength = 50;
        }

        public class Item
        {
            public const int TitleMaxLength = 120;
            public const int DescriptionMaxLength = 500;
        }
    }
}
