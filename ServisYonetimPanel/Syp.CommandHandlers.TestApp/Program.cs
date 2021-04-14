using SI.CommandBus;
using SI.CommandBus.Core;
using Syp.Command.Base.Result;
using Syp.Command.Delete;
using Syp.Command.Insert;
using Syp.Command.Update;
using Syp.CommandHandlers.Delete;
using System;
using System.Threading;

namespace Syp.CommandHandlers.TestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ICommandBus commandBus = new CommandBus();
            var cmd = new ServiceDetailTypeInsertCommand
            {
                DetailTypeName = "My First Service",
                CreatedBy = 1
            };

            var result = commandBus.Send<ServiceDetailTypeInsertCommand, LongCommandResult>(cmd);

            //var serviceDetailTypeHandler = new ServiceDetailTypeInsertCommandHandler();

            //var result = serviceDetailTypeHandler.Handle(cmd);
            var id = result.ResponseCode;
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Thread.Sleep(2000);
            //var updateHandler = new ServiceDetailTypeUpdateCommandHandler();
            //result = updateHandler.Handle(
            //    new ServiceDetailTypeUpdateCommand
            //    {
            //        Id = id,
            //        DetailTypeName = "My First Service Updated",
            //        UpdatedBy = 1
            //    });
            result = commandBus.Send<ServiceDetailTypeUpdateCommand, LongCommandResult>(new ServiceDetailTypeUpdateCommand
            {
                Id = id,
                DetailTypeName = "My First Service Updated",
                UpdatedBy = 1
            });
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Thread.Sleep(2000);
            //var deleteHandler = new ServiceDetailTypeDeleteCommandHandler();
            //result = deleteHandler.Handle(
            //    new ServiceDetailTypeDeleteCommand
            //    {
            //        Id = id
            //    });
            result = commandBus.Send<ServiceDetailTypeDeleteCommand, LongCommandResult>(new ServiceDetailTypeDeleteCommand
            {
                Id = id
            });
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Console.ReadKey();
        }
    }
}