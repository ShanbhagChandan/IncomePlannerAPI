﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IncomePlannerDB.IncomePlannerModels
{
    public class TaxRegime
    {
        public int Id { get; set; }
        public string RegimeType { get; set; } 
        public bool IsDefault { get; set; }

        public ICollection<UserSalary> UserSalary { get; set; }
        public ICollection<UserHouseRentExcemption> UserHouseRentExcemption { get; set; }
        public ICollection<ChapterVIASection80CC> ChapterVIASection80CC { get; set; }
        public ICollection<ChapterVIAOtherSection> ChapterVIAOtherSection { get; set; }
    }
}
