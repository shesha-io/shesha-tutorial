using Shesha.Tutorial.Domain.Enums;
using Shesha.Domain.Attributes;
using Shesha.Domain;
using System;
using Abp.Domain.Entities.Auditing;

namespace Shesha.Tutorial.Domain
{
    /// <summary>
    ///
    /// </summary>
    [Entity(TypeShortAlias = "Tutorial.MembershipPayment")]
    public class MembershipPayment : FullAuditedEntity<Guid>
    {
        /// <summary>
        ///
        /// </summary>
        public virtual Member Member { get; set; }
        /// <summary>
        /// The payment amount
        /// </summary>
        public virtual double Amount { get; set; }
        /// <summary>
        /// The date when the payment was made
        /// </summary>
        public virtual DateTime? PaymentDate { get; set; }
    }
}
