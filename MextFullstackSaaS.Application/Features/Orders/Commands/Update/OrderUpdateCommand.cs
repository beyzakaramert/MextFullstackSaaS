using MediatR;
using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models;
using MextFullstackSaaS.Domain.Entities;
using MextFullstackSaaS.Domain.Enums;
using System;

namespace MextFullstackSaaS.Application.Features.Orders.Commands.Update
{
    public class OrderUpdateCommand : IRequest<ResponseDto<Guid>>
    {
        public Guid Id { get; set; }
        public string IconDescription { get; set; }
        public string ColourCode { get; set; }
        public AIModelType Model { get; set; }
        public DesignType DesignType { get; set; }
        public IconSize Size { get; set; }
        public IconShape Shape { get; set; }
        public int Quantity { get; set; }


        public static Order MapToOrder(OrderUpdateCommand orderUpdateCommand, Order oldorder, Guid modifiedByUserId)
        {
            oldorder.ModifiedByUserId = modifiedByUserId.ToString();
            oldorder.IconDescription = orderUpdateCommand.IconDescription;
            oldorder.ColourCode = orderUpdateCommand.ColourCode;
            oldorder.Model = orderUpdateCommand.Model;
            oldorder.DesignType = orderUpdateCommand.DesignType;
            oldorder.Size = orderUpdateCommand.Size;
            oldorder.Shape = orderUpdateCommand.Shape;
            oldorder.Quantity = orderUpdateCommand.Quantity;
            oldorder.ModifiedOn = DateTimeOffset.UtcNow;

            return oldorder;
        }
        
    }
}
