using Shesha.Settings;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shesha.Tutorial.Domain.Configurations.Membership
{
    [Category("Membership")]
    public interface IMembershipSettings : ISettingAccessors
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Debit Day", Description = "Specific day on which a financial transaction is processed, resulting in the withdrawal of funds from an account.")]
        [Setting(MembershipSettingNames.DebitDay)]
        ISettingAccessor<int> DebitDay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Membership Payments", Description = "Membership Payment debit days and reminder frequencies which refer to how often reminders are sent to a debtor to notify them about upcoming, due, or overdue payments.")]
        [Setting(MembershipSettingNames.MembershipPayments, EditorFormName = "membership-payment-settings")]
        ISettingAccessor<MembershipPaymentSettings> MembershipPayments { get; set; }

    }
}
