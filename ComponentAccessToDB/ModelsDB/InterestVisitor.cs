using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentAccessToDB
{
    public partial class InterestVisitor // Desiredplayer
    {

        public int Id { get; set; }
        public int? VisitorID { get; set; }
        public int? HotelID { get; set; }
        public int? Managementid { get; set; }

        public virtual Management Management { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
