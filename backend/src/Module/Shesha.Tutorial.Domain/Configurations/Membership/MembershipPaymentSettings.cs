using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shesha.Tutorial.Domain.Configurations.Membership
{
    public class MembershipPaymentSettings
    {
        /// <summary>
        /// Specific day on which a financial transaction is processed, resulting in the withdrawal of funds from an account.
        /// </summary>
        public int DebitDay { get; set; }

        /// <summary>
        /// Sent a few days before the payment due date to remind the debtor of the upcoming payment.
        /// </summary>
        public int InitialReminder { get; set; }

        /// <summary>
        /// Sent on the due date to remind the debtor that the payment is due today.
        /// </summary>
        public bool DueDateReminder { get; set; }

        /// <summary>
        /// Sent immediately after the payment is overdue, typically 1-3 days after the due date.
        /// </summary>
        public int FirstOverdueReminder { get; set; }

        /// <summary>
        /// Sent at regular intervals (e.g., every 7, 14, or 30 days) until the payment is made or further action is taken.
        /// </summary>
        public int SubsequentOverdueReminder { get; set; }

        /// <summary>
        /// A stern reminder sent when the payment is significantly overdue, often indicating potential legal action or transfer to a collections agency if the payment is not made promptly.
        /// </summary>
        public int FinalNotice { get; set; }
    }
}