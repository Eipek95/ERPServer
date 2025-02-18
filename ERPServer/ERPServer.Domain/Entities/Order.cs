using ERPServer.Domain.Abstractions;
using ERPServer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ERPServer.Domain.Entities
{
    public sealed class Order:Entity
    {
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int OrderNumberYear { get; set; }
        public int OrderNumber { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public OrderStatusEnum   Status{ get; set; }=OrderStatusEnum.Pending;
        public List<OrderDetail>? Details { get; set; }
        [IgnoreDataMember]
        public string Number => SetNumber();

        private string SetNumber()
        {
            string prefix = "TS";
            string initialString=prefix+OrderNumberYear.ToString() +  OrderNumber.ToString();
            int targetLength = 16;
            int missionLength= targetLength - initialString.Length;
            string finalString = prefix + OrderNumberYear.ToString() + new string('0', missionLength) +OrderNumber.ToString();
            return finalString;
        }
    }
}
