using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppConsumingWebApi
{
    
    public class Show
    {
        public int Id { get; set; }
        public string ShowName { get; set; }
        public string BackGroundImagePath { get; set; }

        //public virtual ICollection<CategoryForShow> CategoryForShowList { get; set; }
        //public virtual ICollection<Vedio> Vedios { get; set; }
    }

    public class Vedio
    {
        public int VedioId { get; set; }
        public string VedioName { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public int? DateToShow { get; set; }
        public decimal ShowDuration { get; set; }
        public string VedioPath { get; set; }

        public int ShowId { get; set; }
        public bool? isLocked { get; set; }
        public virtual Show Show { get; set; }

    }

    public class CategoryForShow
    {
        public int CSId { get; set; }
        public int ShowId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Show Show { get; set; }

    }
}
