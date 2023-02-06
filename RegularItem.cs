using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedME
{
    public class RegularItem
    {
        private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string itemDescription;

        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        public RegularItem(string itemName, string itemDescription)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
        }
    }

    }

