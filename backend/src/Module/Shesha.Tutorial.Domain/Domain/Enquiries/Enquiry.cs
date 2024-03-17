using Abp.Domain.Entities.Auditing;
using Shesha.Domain;
using System;

namespace Shesha.Tutorial.Domain.Domain.Enquiries
{
    /// <summary>
    /// Stores the different enquiries made by members
    /// </summary>
    public class Enquiry: FullAuditedEntity<Guid>
    {
        public virtual Template Template { get; set; }
        public virtual Member Member { get; set; }
    }
}
