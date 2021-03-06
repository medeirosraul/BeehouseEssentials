﻿using Beehouse.Essentials.Entities;

namespace Beehouse.Essentials.Identity.Entities
{
    public class IndividualEntity : Entity
    {
        public string CreatedBy { get; set; }
        public string CreatorName { get; set; }
        public string OwnedBy { get; set; }
    }
}