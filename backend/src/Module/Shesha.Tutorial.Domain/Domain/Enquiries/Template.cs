using Abp.Domain.Entities.Auditing;
using Shesha.Web.FormsDesigner.Domain;
using System;

namespace Shesha.Tutorial.Domain.Domain.Enquiries
{
    /// <summary>
    /// This entity stores the different form templates to be rendered for each enquiry type
    /// </summary>
    public class Template: FullAuditedEntity<Guid>
    {
        public virtual FormConfiguration CaptureForm { get; set; }
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }
    }
}
