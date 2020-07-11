using Syp.Command.Delete;
using Syp.Command.Handlers.Delete;
using Syp.Command.Handlers.Insert;
using Syp.Command.Handlers.Update;
using Syp.Command.Insert;
using Syp.Command.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syp.CommandHandlers.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceDetailTypeHandler = new ServiceDetailTypeInsertCommandHandler();
            var result = serviceDetailTypeHandler.Handle(
                new ServiceDetailTypeInsertCommand
                {
                    DetailTypeName = "My First Service",
                    CreatedBy = 1
                });
            var id = result.ResponseCode;
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Thread.Sleep(2000);
            var updateHandler = new ServiceDetailTypeUpdateCommandHandler();
            result = updateHandler.Handle(
                new ServiceDetailTypeUpdateCommand
                {
                    Id = id,
                    DetailTypeName = "My First Service Updated",
                    UpdatedBy = 1
                });
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Thread.Sleep(2000);
            var deleteHandler = new ServiceDetailTypeDeleteCommandHandler();
            result = deleteHandler.Handle(
                new ServiceDetailTypeDeleteCommand
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
